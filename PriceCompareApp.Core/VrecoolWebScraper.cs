﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using Serilog;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core
{
    public class VrecoolWebScraper
    {
        private static HttpClient client;
        public List<string> ItemCodes { get; set; }
        public WebSite WebSite = WebSite.Vrecool;

        public delegate void ScraperLogHandler(object sender, LogEventArgs e);
        public event ScraperLogHandler LogMessage;

        public VrecoolWebScraper(List<string> itemCodes)
        {
            client = new HttpClient(new HttpClientHandler() { Proxy = null });
            client.BaseAddress = new Uri("http://www.vrecool.com/");

            ItemCodes = itemCodes;
        }

        public async Task<List<Item>> RunScrapingAsync()
        {
            ConcurrentBag<Item> itemsConcurrentBag = new ConcurrentBag<Item>();
            Stopwatch sw = new Stopwatch();

            int codesProcessed = 0;
            int maxSitePerIteration = 5;
            try
            {
                OnLogMessage(new LogEventArgs($">>> Started scraping for {WebSite} site"));

                sw.Start();

                while (codesProcessed < ItemCodes.Count)
                {
                    int take =
                        ItemCodes.Count - codesProcessed >= maxSitePerIteration
                            ? maxSitePerIteration
                            : ItemCodes.Count % maxSitePerIteration;

                    var t = ItemCodes
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
                            $"    <<< Processed/total codes: {codesProcessed}/{ItemCodes.Count}"
                        )
                    );
                }

                sw.Stop();

                OnLogMessage(
                    new LogEventArgs(
                        $"    Total scraping time: {sw.Elapsed.Hours}:{sw.Elapsed.Minutes}:{sw.Elapsed.Seconds}.{sw.Elapsed.Milliseconds}"
                    )
                );
                OnLogMessage(new LogEventArgs($"<<< Finished scraping for {WebSite} site"));
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

                    var nameDiv = htmlDocument.DocumentNode
                        .Descendants("div")
                        .Where(
                            div => div.GetAttributeValue("class", "").Equals("page_artdet_name_2")
                        )
                        .FirstOrDefault();

                    if (nameDiv != null)
                    {
                        var textBiggestH1 = nameDiv
                            .Descendants("h1")
                            .Where(
                                span => span.GetAttributeValue("class", "").Equals("text_biggest")
                            )
                            .FirstOrDefault();

                        if (textBiggestH1 != null)
                            item.Name = Helper.DecodeText(textBiggestH1.InnerText.Trim());
                    }

                    var priceDiv = htmlDocument.DocumentNode
                        .Descendants("div")
                        .Where(div => div.GetAttributeValue("id", "").Equals("page_artdet_price"))
                        .FirstOrDefault();

                    if (priceDiv != null)
                    {
                        var priceSpan = priceDiv
                            .Descendants("span")
                            .Where(
                                span =>
                                    span.GetAttributeValue("id", "")
                                        .Equals($"price_net_brutto_{itemCode}")
                            )
                            .FirstOrDefault();

                        if (priceSpan != null)
                        {
                            double price = 0D;
                            double.TryParse(priceSpan.InnerText.Replace(" ", ""), out price);

                            price = price / 1.2; //računam cijenu bez PDV-a

                            item.Price = price.ToString("N");
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
                        $"shop_search.php?complex=ok&search={itemCode}&type=2&subcat=0&in_what=01000000"
                    );

                    if (response.IsSuccessStatusCode)
                    {
                        string html = await response.Content.ReadAsStringAsync();
                        if (CheckIfHasMoreResults(html, itemCode))
                        {
                            string productUrl = GetUrlForFoundProduct(html, itemCode);
                            response = await client.GetAsync(productUrl);

                            if (response.IsSuccessStatusCode)
                                return await response.Content.ReadAsStringAsync();
                            else
                            {
                                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                                return await GetPageSourceAsync(itemCode, --retries);
                            }
                        }

                        return html;
                    }
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

        private bool CheckIfHasMoreResults(string html, string itemCode)
        {
            HtmlDocument htmlDocument = new HtmlDocument();

            if (html != null)
            {
                htmlDocument.LoadHtml(html);

                var tempListForm = htmlDocument.DocumentNode
                    .Descendants("form")
                    .Where(form => form.GetAttributeValue("name", "").Equals("form_temp_artlist"))
                    .FirstOrDefault();

                if (tempListForm != null)
                {
                    var pageArtListItem2 = tempListForm
                        .Descendants("div")
                        .Where(
                            div =>
                                div.GetAttributeValue("class", "").Contains("page_artlist_item_2")
                        );

                    return pageArtListItem2?.Count() > 0;
                }
            }

            return false;
        }

        private string GetUrlForFoundProduct(string html, string itemCode)
        {
            HtmlDocument htmlDocument = new HtmlDocument();

            if (html != null)
            {
                htmlDocument.LoadHtml(html);

                var tempListForm = htmlDocument.DocumentNode
                    .Descendants("form")
                    .Where(form => form.GetAttributeValue("name", "").Equals("form_temp_artlist"))
                    .FirstOrDefault();

                if (tempListForm != null)
                {
                    var pageArtListItem2 = tempListForm
                        .Descendants("div")
                        .Where(
                            div =>
                                div.GetAttributeValue("class", "").Contains("page_artlist_item_2")
                        )
                        .ToList();

                    if (pageArtListItem2 != null)
                    {
                        return pageArtListItem2
                            .Select(
                                el =>
                                    el.Descendants("a")
                                        .Where(
                                            a =>
                                                a.GetAttributeValue("data-sku", "").Equals(itemCode)
                                        )
                                        .Select(a => a.Attributes["href"].Value)
                                        .FirstOrDefault()
                            )
                            .FirstOrDefault();
                    }
                }
            }

            return null;
        }

        protected virtual void OnLogMessage(LogEventArgs e)
        {
            LogMessage?.Invoke(this, e);
        }
    }
}
