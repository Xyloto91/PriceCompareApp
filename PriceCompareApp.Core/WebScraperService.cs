using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;
using static PriceCompareApp.Model.WebScraperBase;

namespace PriceCompareApp.Core
{
    public class WebScraperService
    {
        private readonly WebScraperFactory _webScraperFactory;
        private readonly Action<string> _logger;

        private WebScraperService(Action<string> logger)
        {
            _webScraperFactory = new WebScraperFactory();
            _logger = logger;
        }

        public static WebScraperService Initialize(Action<string> logger) => new WebScraperService(logger);

        public async Task<List<Item>> Execute(WebSite webSite, List<string> itemCodes) =>
            await _webScraperFactory.Create(webSite, _logger).RunScrapingAsync(itemCodes);
    }
}
