using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using Serilog;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core.Scrapers
{
    public class StatusFrigoWebScraper : IWebScraper
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Vrecool;

        public delegate void ScraperLogHandler(object sender, LogEventArgs e);
        public event ScraperLogHandler LogMessage;

        public StatusFrigoWebScraper()
        {
            client = new HttpClient(new HttpClientHandler { Proxy = null });
            client.BaseAddress = new Uri("https://status-frigo.com/");
        }

        public async Task<List<Item>> RunScrapingAsync(List<string> itemCodes)
        {
            ConcurrentBag<Item> itemsConcurrentBag = new ConcurrentBag<Item>();
            Stopwatch sw = new Stopwatch();

            int codesProcessed = 0;
            int maxSitePerIteration = 5;
            try
            {
                OnLogMessage(new LogEventArgs($">>> Started scraping for {_webSite} site"));

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

                    OnLogMessage(
                        new LogEventArgs(
                            $"    <<< Processed/total codes: {codesProcessed}/{itemCodes.Count}"
                        )
                    );
                }

                sw.Stop();

                OnLogMessage(
                    new LogEventArgs(
                        $"    Total scraping time: {sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}"
                    )
                );
                OnLogMessage(new LogEventArgs($"<<< Finished scraping for {_webSite} site"));
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

                    var productInfoDivs = htmlDocument.DocumentNode
                        .Descendants("div")
                        .Where(li => li.GetAttributeValue("class", "").Equals("product-item-info"))
                        .FirstOrDefault();

                    if (productInfoDivs != null)
                    {
                        var productLink = productInfoDivs
                            .Descendants("a")
                            .Select(a => a.Attributes["href"]?.Value)
                            .FirstOrDefault();

                        if (productLink != null)
                        {
                            html = await GetProductPageSourceAsync(productLink);

                            if (html != null)
                            {
                                htmlDocument.LoadHtml(html);
                                item.Processed = true;

                                var productInfoMainDiv = htmlDocument.DocumentNode
                                    .Descendants("div")
                                    .Where(
                                        div =>
                                            div.GetAttributeValue("class", "")
                                                .Equals("product-info-main")
                                    )
                                    .FirstOrDefault();

                                if (productInfoMainDiv != null)
                                {
                                    var pageTitleWrapperSpan = productInfoMainDiv
                                        .Descendants("h1")
                                        .Where(
                                            div =>
                                                div.GetAttributeValue("class", "")
                                                    .Contains("page-title")
                                        )
                                        .FirstOrDefault();

                                    item.Name = Helper
                                        .DecodeText(pageTitleWrapperSpan?.InnerText)
                                        .Trim();

                                    var priceContainerSpan = productInfoMainDiv
                                        .Descendants("span")
                                        .Where(
                                            span =>
                                                span.GetAttributeValue("class", "")
                                                    .Contains("price-container price-final_price")
                                        )
                                        .FirstOrDefault();

                                    if (priceContainerSpan != null)
                                    {
                                        var priceIncludingTaxSpan = priceContainerSpan
                                            .Descendants("span")
                                            .Where(
                                                span =>
                                                    span.GetAttributeValue("id", "")
                                                        .Contains(
                                                            "price-including-tax-product-price"
                                                        )
                                            )
                                            .FirstOrDefault();

                                        item.Price = priceIncludingTaxSpan?.InnerText
                                            .Replace("din.", "")
                                            .Trim();
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

        private async Task<string> GetProductPageSourceAsync(string link, int retries = 3)
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

        private async Task<string> GetPageSourceAsync(string itemCode, int retries = 3)
        {
            try
            {
                while (retries != 0)
                {
                    var response = await client.GetAsync($"catalogsearch/result/?q={itemCode}");

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

        protected virtual void OnLogMessage(LogEventArgs e)
        {
            LogMessage?.Invoke(this, e);
        }
    }
}
