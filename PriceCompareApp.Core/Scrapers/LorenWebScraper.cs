using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Serilog;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core.Scrapers
{
    public class LorenWebScraper : WebScraperBase
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Loren;
        private readonly Action<string> _logger;

        public LorenWebScraper(Action<string> logger)
        {
            _logger = logger;
            client = new HttpClient(new HttpClientHandler { Proxy = null });
            client.BaseAddress = new Uri("http://www.loren.co.rs/");
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

            return itemsConcurrentBag.ToList();
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

                    var captionDiv = htmlDocument.DocumentNode
                        .Descendants("div")
                        .Where(
                            div =>
                                div.GetAttributeValue("class", "").Equals("caption")
                                && div.InnerHtml.Trim().Contains($"<b>{itemCode}</b>")
                        )
                        .FirstOrDefault();

                    if (captionDiv != null)
                    {
                        var productLink = captionDiv.Descendants("a").FirstOrDefault().Attributes[
                            "href"
                        ].Value;

                        if (productLink != null)
                        {
                            html = await GetPageSourceFromSearchLinkAsync(productLink);

                            if (!string.IsNullOrEmpty(html.Trim()))
                            {
                                htmlDocument.LoadHtml(html);
                                item.Processed = true;

                                var contentDiv = htmlDocument.DocumentNode
                                    .Descendants("div")
                                    .Where(
                                        div =>
                                            div.GetAttributeValue("id", "").Equals("content")
                                            && div.GetAttributeValue("class", "").Equals("col-sm-9")
                                    )
                                    .FirstOrDefault();

                                if (contentDiv != null)
                                {
                                    var productName = contentDiv
                                        .Descendants("h1")
                                        .Where(
                                            h1 =>
                                                h1.GetAttributeValue("itemprop", "").Equals("name")
                                        )
                                        .FirstOrDefault();

                                    if (productName != null)
                                        item.Name = Helper.DecodeText(productName.InnerText.Trim());

                                    var rowProductInfo = contentDiv
                                        .Descendants("div")
                                        .Where(
                                            div =>
                                                div.GetAttributeValue("class", "")
                                                    .Contains("product-info")
                                        )
                                        .FirstOrDefault();

                                    var priceBox = contentDiv
                                        .Descendants("ul")
                                        .Where(
                                            ul =>
                                                ul.Attributes
                                                    .Where(li => li.Value.Equals("price-box"))
                                                    .Any()
                                        )
                                        .FirstOrDefault();

                                    if (priceBox != null)
                                    {
                                        var priceLi = contentDiv
                                            .Descendants("li")
                                            .Where(
                                                li =>
                                                    li.GetAttributeValue("class", "")
                                                        .Equals("price")
                                            )
                                            .FirstOrDefault();

                                        if (priceLi != null)
                                        {
                                            var priceSpan = priceLi
                                                .Descendants("span")
                                                .Where(
                                                    span =>
                                                        span.GetAttributeValue("itemprop", "")
                                                            .Equals("price")
                                                )
                                                .FirstOrDefault();

                                            if (priceSpan != null)
                                            {
                                                double price = 0D;

                                                if (priceSpan.InnerText.ToUpper().Contains("UPIT"))
                                                    item.Price = "NA UPIT";
                                                else
                                                {
                                                    double.TryParse(
                                                        Regex
                                                            .Match(
                                                                priceSpan.InnerText,
                                                                @"\d*[.]?[,]?\d+"
                                                            )
                                                            .Value,
                                                        out price
                                                    );

                                                    price = price / 1.2; //računam cijenu bez PDV-a

                                                    item.Price = price.ToString("N");
                                                }
                                            }
                                        }
                                    }
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

        private async Task<string> GetPageSourceAsync(string itemCode, int retries = 3)
        {
            try
            {
                while (retries != 0)
                {
                    var response = await client.GetAsync(
                        $"index.php?route=product/search&search={itemCode}"
                    );

                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                    {
                        await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                        return await GetPageSourceAsync(itemCode, --retries);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                if (retries == 3)
                    Log.Error(ex, $"Exception encountered for item code: {itemCode}");
                else if (retries == 1)
                    throw ex;

                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                return await GetPageSourceAsync(itemCode, --retries);
            }

            return null;
        }

        private async Task<string> GetPageSourceFromSearchLinkAsync(string link, int retries = 3)
        {
            try
            {
                while (retries != 0)
                {
                    Uri uri = new Uri(link);
                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                    {
                        Thread.Sleep(Helper.GetDefaultConnectionLossTimeout());
                        return await GetPageSourceAsync(link, --retries);
                    }
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                if (retries == 3)
                    Log.Error(ex, $"Exception encountered for link: '{link}'");
                else if (retries == 1)
                    throw ex;

                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                return await GetPageSourceAsync(link, --retries);
            }

            return null;
        }
    }
}
