using System;
using PriceCompareApp.Core.Scrapers;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.Core
{
    public class WebScraperFactory
    {
        public WebScraperBase Create(WebSite website)
        {
            switch (website)
            {
                case WebSite.Dekom:
                    return new DekomWebScraper();
                case WebSite.Eltom:
                    return new EltomWebScraper();
                case WebSite.Elkond:
                    return new ElkondWebScraper();
                case WebSite.Loren:
                    return new LorenWebScraper();
                case WebSite.Vrecool:
                    return new VrecoolWebScraper();
                case WebSite.StatusFrigo:
                    return new StatusFrigoWebScraper();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
