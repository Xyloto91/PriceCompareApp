using System;
using PriceCompareApp.Core.Scrapers;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core
{
    public class WebScraperFactory
    {
        public WebScraperBase Create(WebSite website, Action<string> logger)
        {
            switch (website)
            {
                case WebSite.Dekom:
                    return new DekomWebScraper(logger);
                case WebSite.Eltom:
                    return new EltomWebScraper(logger);
                case WebSite.Elkond:
                    return new ElkondWebScraper(logger);
                case WebSite.Loren:
                    return new LorenWebScraper(logger);
                case WebSite.Vrecool:
                    return new VrecoolWebScraper(logger);
                case WebSite.StatusFrigo:
                    return new StatusFrigoWebScraper(logger);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
