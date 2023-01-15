using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public interface IWebScraper
    {
        Task<List<Item>> RunScrapingAsync(List<string> itemCodes);
    }
}
