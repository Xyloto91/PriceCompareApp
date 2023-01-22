using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using Serilog;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core.Scrapers
{
    public class ElkondWebScraper : WebScraperBase
    {
        private HttpClient client;
        private readonly WebSite _webSite = WebSite.Elkond;
        private readonly Action<string> _logger;

        public ElkondWebScraper(Action<string> logger)
        {
            _logger = logger;
            client = new HttpClient(new HttpClientHandler() { Proxy = null });
            client.BaseAddress = new Uri("https://elkond.co.rs/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("multipart/form-data")
            );
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

        private async Task<Item> GetItemDataAsync(string itemCode, int retries = 3)
        {
            try
            {
                var values = new Dictionary<string, string> { { "q", itemCode } };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("ajax/search.php", content);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        try
                        {
                            var elkondAutoSearchData =
                                JsonConvert.DeserializeObject<ElkondAutoSearchData>(result);

                            if (
                                elkondAutoSearchData != null
                                && elkondAutoSearchData.products?.items != null
                            )
                            {
                                var data = elkondAutoSearchData.products.items
                                    .Where(p => decimal.Parse(p.relevance) > 0)
                                    .ToList()
                                    .OrderBy(p => decimal.Parse(p.relevance))
                                    .FirstOrDefault();

                                if (data != null)
                                {
                                    return new Item
                                    {
                                        Name = data.name,
                                        Code = data.cikkszam,
                                        Processed = true,
                                        Price = !string.IsNullOrWhiteSpace(data.price_pdv)
                                            ? data.price_pdv.Replace(" ", "")
                                            : "-1"
                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(
                                ex,
                                $"Exception occured on deserialization elkond data for item code: {itemCode}"
                            );
                            return null;
                        }
                    }
                    return null;
                }
                else
                {
                    await Task.Delay(Helper.GetDefaultConnectionLossTimeout());
                    return await GetItemDataAsync(itemCode);
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
                return await GetItemDataAsync(itemCode);
            }
        }
    }
}
