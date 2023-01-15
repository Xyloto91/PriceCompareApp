using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareApp.Common;
using PriceCompareApp.Model;
using PriceCompareApp.Core.Scrapers;

namespace PriceCompareApp.Core.Factories
{
    public class DekomWebScraperFactory : WebScraperFactory
    {
        public override IWebScraper Create() => new DekomWebScraper();
    }
}
