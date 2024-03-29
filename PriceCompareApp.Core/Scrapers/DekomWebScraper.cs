﻿using System;
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
    public class DekomWebScraper : WebScraperBase
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Dekom;
        private readonly Action<string> _logger;

        public DekomWebScraper(Action<string> logger)
        {
            _logger = logger;
            client = new HttpClient(new HttpClientHandler() { Proxy = null });
            client.BaseAddress = new Uri("https://dekom.co.rs");
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
            string html;

            try
            {
                html = await GetPageSourceAsync(itemCode);
                return await ExtractDataFromHtml(itemCode, html);
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                Log.Error(ex, $"Exception encountered for item code: {itemCode}");
                throw ex;
            }
        }

        private async Task<Item> ExtractDataFromHtml(string itemCode, string html)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            Item item = new Item();
            item.Code = itemCode;

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

                    if (product == null)
                    {
                        var paginationLi = htmlDocument.DocumentNode
                            .Descendants("li")
                            .Where(ul => ul.GetAttributeValue("id", "").Equals("pagination_next"))
                            .FirstOrDefault();

                        if (paginationLi != null)
                        {
                            var nextPageLink = paginationLi
                                .Descendants("a")
                                .Select(a => a.Attributes["href"].Value)
                                .FirstOrDefault();

                            if (nextPageLink != null)
                            {
                                nextPageLink = Helper.DecodeText(nextPageLink);
                                html = await GetPageSourceNextPageAsync(nextPageLink);
                                return await ExtractDataFromHtml(itemCode, html);
                            }
                        }
                    }

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
                            var priceText = rightBlock
                                .Descendants("span")
                                .Where(
                                    span =>
                                        span.GetAttributeValue("class", "")
                                            .Equals("cena-za-porucivanje")
                                )
                                .FirstOrDefault()
                                ?.InnerText.Replace("RSD", "")
                                .Replace(" ", "");

                            double.TryParse(priceText.Replace(" ", ""), out var price);

                            price = price / 1.2; //računam cijenu bez PDV-a

                            item.Price = price.ToString("N");
                        }
                    }
                }
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

        private async Task<string> GetPageSourceNextPageAsync(string url, int retries = 3)
        {
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                    return await GetPageSourceNextPageAsync(url, --retries);
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                if (retries == 3)
                    Log.Error(ex, $"Exception occured for supplier search next page url: '{url}'");
                else if (retries == 1)
                    throw ex;

                await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                return await GetPageSourceNextPageAsync(url, --retries);
            }
        }
    }
}
