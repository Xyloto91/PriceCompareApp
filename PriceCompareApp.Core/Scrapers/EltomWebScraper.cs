using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using Serilog;
using Serilog.Core;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core.Scrapers
{
    public class EltomWebScraper : WebScraperBase
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Eltom;
        private readonly Action<string> _logger;

        public EltomWebScraper(Action<string> logger)
        {
            _logger = logger;
            client = new HttpClient(new HttpClientHandler() { Proxy = null });
            client.BaseAddress = new Uri("https://eltom.rs");
        }

        public override async Task<List<Item>> RunScrapingAsync(List<string> itemCodes)
        {
            ConcurrentBag<Item> itemsConcurrentBag = new ConcurrentBag<Item>();
            Stopwatch sw = new Stopwatch();

            int codesProcessed = 0;
            int maxSitePerIteration = 5;
            try
            {
                _logger?.Invoke($">>> Started scraping for {_webSite} site");

                sw.Start();

                while (codesProcessed < itemCodes.Count)
                {
                    int take =
                        itemCodes.Count - codesProcessed >= maxSitePerIteration
                            ? maxSitePerIteration
                            : itemCodes.Count % maxSitePerIteration;

                    var t = itemCodes
                        .Skip(codesProcessed)
                        .Take(take)
                        .Select(async itemCode =>
                        {
                            itemsConcurrentBag.Add(await GetItemDataAsync(itemCode));
                        });

                    await Task.WhenAll(t);

                    codesProcessed += take;

                    _logger?.Invoke(
                        $"    <<< Processed/total codes: {codesProcessed}/{itemCodes.Count}"
                    );
                }

                sw.Stop();

                _logger?.Invoke(
                    $"    Total scraping time: {sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}"
                );
                _logger?.Invoke($"<<< Finished scraping for {_webSite} site");
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }

            //sort data by order from input list
            return itemsConcurrentBag
                .OrderBy(x => itemCodes.IndexOf(x.Code))
                .ToList();
        }

        private async Task<Item> GetItemDataAsync(string itemCode)
        {
            Item item = new Item();
            HtmlDocument htmlDocument = new HtmlDocument();
            string html;

            try
            {
                item.Code = itemCode;
                html = await GetPageSourceAsync(itemCode);

                if (html != null)
                {
                    htmlDocument.LoadHtml(html);
                    item.Processed = true;

                    var productLinkDiv = htmlDocument.DocumentNode
                        .Descendants("div")
                        .Where(
                            div =>
                                div.GetAttributeValue("class", "")
                                    .Equals("xs-product-holder pos product")
                                && div.GetAttributeValue("productid", "").Equals(itemCode)
                        )
                        .ToList();

                    if (productLinkDiv.Count == 0)
                    {
                        var pagination = htmlDocument.DocumentNode
                            .Descendants("ul")
                            .Where(div => div.GetAttributeValue("class", "").Equals("pagination"))
                            .FirstOrDefault();

                        var lastPageAnchor = pagination
                            .Descendants("a")
                            .Where(a => a.GetAttributeValue("aria-label", "").Equals("Sledeća"))
                            .FirstOrDefault();

                        if (lastPageAnchor != null)
                        {
                            var href = lastPageAnchor.Attributes["href"]?.Value;
                            var totalPages = int.Parse(
                                Regex.Match(href, "(?<=&p=)(\\d+)(?=#)").Value
                            );

                            if (totalPages > 1)
                            {
                                for (int page = 2; page <= totalPages; page++)
                                {
                                    productLinkDiv = await GetProductLinkFromPage(
                                        $"pretraga?q={itemCode}&p={page}#",
                                        itemCode
                                    );
                                    if (productLinkDiv != null)
                                        break;
                                }
                            }
                        }
                    }

                    if (productLinkDiv.Count > 0)
                    {
                        var link = productLinkDiv
                            .FirstOrDefault()
                            ?.Descendants("a")
                            .Where(a => !string.IsNullOrWhiteSpace(a.GetAttributeValue("href", "")))
                            .Select(a => a.Attributes["href"]?.Value)
                            .FirstOrDefault();

                        if (link != null)
                        {
                            html = await GetPageSourceFromSearchLinkAsync(link);

                            if (html != null)
                            {
                                htmlDocument.LoadHtml(html);
                                item.Processed = true;

                                var productInfo = htmlDocument.DocumentNode
                                    .Descendants("div")
                                    .Where(
                                        div =>
                                            div.GetAttributeValue("class", "")
                                                .Equals("product-info pos")
                                    )
                                    .FirstOrDefault();

                                if (productInfo != null)
                                {
                                    item.Name = Helper.DecodeText(
                                        productInfo.Descendants("h2").FirstOrDefault()?.InnerText
                                    );

                                    var priceText = productInfo
                                        .Descendants("p")
                                        .Where(
                                            p =>
                                                p.GetAttributeValue("class", "")
                                                    .Equals("discount-price")
                                        )
                                        .FirstOrDefault()
                                        ?.Attributes["content"].Value;

                                    double.TryParse(priceText.Replace(" ", "").Replace(",", "").Replace(".", ","), out var price);

                                    price = price / 1.2; //računam cijenu bez PDV-a

                                    item.Price = price.ToString("N");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                Log.Error(ex, $"Exception encountered for item code: {itemCode}");
                throw ex;
            }

            return item;
        }

        private async Task<string> GetPageSourceFromSearchLinkAsync(string link, int retries = 3)
        {
            try
            {
                while (retries != 0)
                {
                    var response = await client.GetAsync(link);

                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                    {
                        await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                        return await GetPageSourceFromSearchLinkAsync(link, --retries);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                if (retries == 3)
                    Log.Error(ex, $"Exception occured for supplier web link: {link}");
                else if (retries == 1)
                    throw ex;

                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                return await GetPageSourceFromSearchLinkAsync(link, --retries);
            }

            return null;
        }

        private async Task<string> GetPageSourceAsync(string itemCode, int retries = 3)
        {
            try
            {
                var response = await client.GetAsync($"pretraga?q={itemCode}&cat=0");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                    return await GetPageSourceAsync(itemCode, --retries);
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                if (retries == 3)
                    Log.Error(ex, $"Exception occured for supplier search result code: {itemCode}");
                else if (retries == 1)
                    throw ex;

                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                return await GetPageSourceAsync(itemCode, --retries);
            }
        }

        private async Task<List<HtmlNode>> GetProductLinkFromPage(string link, string itemCode)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            string html;

            html = await GetPageSourceFromSearchLinkAsync(link);

            if (html != null)
            {
                htmlDocument.LoadHtml(html);

                var productLinkDiv = htmlDocument.DocumentNode
                    .Descendants("div")
                    .Where(
                        div =>
                            div.GetAttributeValue("class", "")
                                .Equals("xs-product-holder pos product")
                            && div.GetAttributeValue("productid", "").Equals(itemCode)
                    )
                    .ToList();

                return productLinkDiv;
            }

            return null;
        }
    }
}
