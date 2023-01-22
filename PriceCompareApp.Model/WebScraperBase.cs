using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public abstract class WebScraperBase
    {
        public abstract Task<List<Item>> RunScrapingAsync(List<string> itemCodes);
    }
}
