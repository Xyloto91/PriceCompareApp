using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core
{
    public class WebScraper
    {
        private readonly WebScraperFactory _webScraperFactory;

        public WebScraper()
        {
            _webScraperFactory = new WebScraperFactory();
        }

        public async Task<List<Item>> Execute(WebSite webSite, List<string> itemCodes) =>
            await _webScraperFactory.Create(webSite).RunScrapingAsync(itemCodes);
    }
}
