using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public abstract class WebScraperBase
    {
        public delegate void ScraperLogHandler(object sender, LogEventArgs e);
        public event ScraperLogHandler LogMessage;

        public WebScraperBase() { }

        public abstract Task<List<Item>> RunScrapingAsync(List<string> itemCodes);

        protected virtual void OnLogMessage(LogEventArgs e)
        {
            LogMessage?.Invoke(this, e);
        }
    }
}
