using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Model;
using PriceCompareApp.Core.Scrapers;

namespace PriceCompareApp.Core.Factories
{
    public class ElkondWebScraperFactory : WebScraperFactory
    {
        public override IWebScraper Create() => new ElkondWebScraper();
    }
}
