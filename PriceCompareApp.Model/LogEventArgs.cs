using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Model
{
    public class LogEventArgs
    {
        public string Message { get; set; }

        public LogEventArgs(string message)
        {
            Message = message;
        }
    }
}
