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
        private readonly Dictionary<WebSite, WebScraperFactory> _factories;

        public WebScraper()
        {
            _factories = new Dictionary<WebSite, WebScraperFactory>();

            foreach (WebSite webSite in Enum.GetValues(typeof(WebSite)))
            {
                _factories.Add(
                    webSite,
                    (WebScraperFactory)
                        Activator.CreateInstance(
                            Type.GetType(
                                $"PriceCompareApp.Core.Factories.{webSite}WebScraperFactory, PriceCompareApp.Core"
                            )
                        )
                );
            }
        }

        public static WebScraper InitializeWebScraper => new WebScraper();

        public async Task<List<Item>> Execute(WebSite website, List<string> itemCodes) =>
            await _factories[website].Create().RunScrapingAsync(itemCodes);
    }
}
