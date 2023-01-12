using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Common
{
    public static class Configuration
    {
        public static string ConnectionLossTimeout
        {
            get
            {
                string timeout = "00:02:00";
                if (Helper.GetValueFromIniFile("ConnectionLossTimeout") != null)
                    timeout = Helper.GetValueFromIniFile("ConnectionLossTimeout").ToString();
                return timeout;
            }
        }

        public static void SaveSettings()
        {
            Helper.WriteValueToIniFile("Settings", "ConnectionLossTimeout", ConnectionLossTimeout);
        }
    }
}
