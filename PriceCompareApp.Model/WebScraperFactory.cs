using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public abstract class WebScraperFactory
    {
        public abstract IWebScraper Create();
    }
}
