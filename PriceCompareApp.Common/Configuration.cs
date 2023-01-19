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
            set
            {
                ConnectionLossTimeout= value;
            }
        }

        public static string VrecoolDefaultPath
        {
            get 
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("VrecoolDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("VrecoolDefaultPath").ToString();
                return filePath;
            }
            set
            {
                VrecoolDefaultPath = value;
            }
        }

        public static string LorenDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("LorenDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("LorenDefaultPath").ToString();
                return filePath;
            }
            set
            {
                LorenDefaultPath = value;
            }
        }

        public static string DekomDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("DekomDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("DekomDefaultPath").ToString();
                return filePath;
            }
            set
            {
                DekomDefaultPath = value;
            }
        }

        public static string EltomDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("EltomDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("EltomDefaultPath").ToString();
                return filePath;
            }
            set
            {
                EltomDefaultPath = value;
            }
        }

        public static string ElkondDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("ElkondDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("ElkondDefaultPath").ToString();
                return filePath;
            }
            set
            {
                ElkondDefaultPath = value;
            }
        }

        public static string StatusFrigoDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("StatusFrigoDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("StatusFrigoDefaultPath").ToString();
                return filePath;
            }
            set
            {
                StatusFrigoDefaultPath = value;
            }
        }

        public static string StelaxDefaultPath
        {
            get
            {
                string filePath = "";
                if (Helper.GetValueFromIniFile("StelaxDefaultPath") != null)
                    filePath = Helper.GetValueFromIniFile("StelaxDefaultPath").ToString();
                return filePath;
            }
            set
            {
                StelaxDefaultPath = value;
            }
        }

        public static string OutputDefaultDirectoryPath
        {
            get
            {
                string path = "";
                if (Helper.GetValueFromIniFile("OutputDefaultDirectoryPath") != null)
                    path = Helper.GetValueFromIniFile("OutputDefaultDirectoryPath").ToString();
                return path;
            }
            set
            {
                OutputDefaultDirectoryPath = value;
            }
        }

        public static Helper.ExcelFileFormat FileFormat
        {
            get
            {
                //Excel file format
                if (Helper.GetValueFromIniFile("FileFormat") != null)
                {
                    int.TryParse(Helper.GetValueFromIniFile("FileFormat").ToString(), out int enumVal);
                    return (Helper.ExcelFileFormat)enumVal;
                }

                return Helper.ExcelFileFormat.Xls;
            }
            set
            {
                FileFormat = value;
            }
        }

        public static void SaveSettings()
        {
            //Connection
            Helper.WriteValueToIniFile("Settings", "ConnectionLossTimeout", ConnectionLossTimeout);

            //Paths
            Helper.WriteValueToIniFile("Paths", "VrecoolDefaultPath", VrecoolDefaultPath);
            Helper.WriteValueToIniFile("Paths", "LorenDefaultPath", LorenDefaultPath);
            Helper.WriteValueToIniFile("Paths", "DekomDefaultPath", DekomDefaultPath);
            Helper.WriteValueToIniFile("Paths", "EltomDefaultPath", EltomDefaultPath);
            Helper.WriteValueToIniFile("Paths", "ElkondDefaultPath", ElkondDefaultPath);
            Helper.WriteValueToIniFile("Paths", "StatusFrigoDefaultPath", StatusFrigoDefaultPath);
            Helper.WriteValueToIniFile("Paths", "StelaxDefaultPath", StelaxDefaultPath);
            Helper.WriteValueToIniFile("Paths", "OutputDefaultDirectoryPath", OutputDefaultDirectoryPath);

            //Excel file format
            Helper.WriteValueToIniFile("ExcelFileFormat", "FileFormat", FileFormat.ToString("D"));
        }
    }
}
