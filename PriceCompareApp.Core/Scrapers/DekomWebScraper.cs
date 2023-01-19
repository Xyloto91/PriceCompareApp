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
    public class DekomWebScraper : IWebScraper
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Dekom;

        public delegate void ScraperLogHandler(object sender, LogEventArgs e);
        public event ScraperLogHandler LogMessage;

        public DekomWebScraper()
        {
            client = new HttpClient(new HttpClientHandler() { Proxy = null });
            client.BaseAddress = new Uri("https://dekom.co.rs");
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
                    item.Processed = true;

                    var productListUl = htmlDocument.DocumentNode
                        .Descendants("ul")
                        .Where(ul => ul.GetAttributeValue("id", "").Equals("product_list"))
                        .FirstOrDefault();

                    if (productListUl != null)
                    {
                        var productsLi = productListUl
                            .Descendants("li")
                            .Where(
                                li =>
                                    li.GetAttributeValue("class", "").Contains("ajax_block_product")
                            )
                            .ToList();

                        var product = productsLi
                            .Where(
                                li =>
                                    li.Descendants("span")
                                        .Any(
                                            span =>
                                                span.GetAttributeValue("class", "")
                                                    .Equals("sifra-za-porucivanje")
                                                && span.InnerText.Trim().Equals(itemCode)
                                        )
                            )
                            .FirstOrDefault();

                        if (product != null)
                        {
                            var centerBlock = product
                                .Descendants("div")
                                .Where(
                                    div => div.GetAttributeValue("class", "").Equals("center_block")
                                )
                                .FirstOrDefault();

                            if (centerBlock != null)
                            {
                                item.Name = Helper.DecodeText(
                                    centerBlock
                                        .Descendants("a")
                                        .Where(
                                            a =>
                                                !string.IsNullOrWhiteSpace(
                                                    a.GetAttributeValue("title", "")
                                                )
                                        )
                                        .FirstOrDefault()
                                        ?.Attributes["title"]?.Value
                                );
                            }

                            var rightBlock = product
                                .Descendants("div")
                                .Where(
                                    div => div.GetAttributeValue("class", "").Equals("right_block")
                                )
                                .FirstOrDefault();

                            if (rightBlock != null)
                            {
                                item.Price = rightBlock
                                    .Descendants("span")
                                    .Where(
                                        span =>
                                            span.GetAttributeValue("class", "")
                                                .Equals("cena-za-porucivanje")
                                    )
                                    .FirstOrDefault()
                                    ?.InnerText.Replace("RSD", "")
                                    .Replace(" ", "");
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
                var response = await client.GetAsync(
                    $"pretraga?controller=search&orderby=position&orderway=desc&search_query={itemCode}&submit_search=Pronađi"
                );
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

        protected virtual void OnLogMessage(LogEventArgs e)
        {
            LogMessage?.Invoke(this, e);
        }
    }
}
