using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;
using static PriceCompareApp.Model.WebScraperBase;

namespace PriceCompareApp.Core
{
    public class WebScraper
    {
        private readonly WebScraperFactory _webScraperFactory;
        public event ScraperLogHandler WebScraperLogHandler;

        public WebScraper(ScraperLogHandler scraperLogHandler)
        {
            _webScraperFactory = new WebScraperFactory();
            WebScraperLogHandler = scraperLogHandler;
        }

        public async Task<List<Item>> Execute(WebSite webSite, List<string> itemCodes)
        {
            var webScraper = _webScraperFactory.Create(webSite);
            webScraper.LogMessage += WebScraperLogHandler;
            return await webScraper.RunScrapingAsync(itemCodes);
        }
    }
}
