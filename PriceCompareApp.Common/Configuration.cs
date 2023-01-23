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
        private static string _connectionLossTimeout;
        public static string ConnectionLossTimeout
        {
            get
            {
                _connectionLossTimeout = "00:02:00";
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("ConnectionLossTimeout")?.ToString()))
                    _connectionLossTimeout = Helper.GetValueFromIniFile("ConnectionLossTimeout").ToString();
                return _connectionLossTimeout;
            }
            set
            {
                _connectionLossTimeout = value;
            }
        }

        private static string _vrecoolDefaultPath;
        public static string VrecoolDefaultPath
        {
            get 
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("VrecoolDefaultPath")?.ToString()))
                    _vrecoolDefaultPath = Helper.GetValueFromIniFile("VrecoolDefaultPath").ToString();
                return _vrecoolDefaultPath;
            }
            set
            {
                _vrecoolDefaultPath = value;
            }
        }

        private static string _lorenDefaultPath;
        public static string LorenDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("LorenDefaultPath")?.ToString()))
                    _lorenDefaultPath = Helper.GetValueFromIniFile("LorenDefaultPath").ToString();
                return _lorenDefaultPath;
            }
            set
            {
                _lorenDefaultPath = value;
            }
        }

        private static string _dekomDefaultPath;
        public static string DekomDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("DekomDefaultPath")?.ToString()))
                    _dekomDefaultPath = Helper.GetValueFromIniFile("DekomDefaultPath").ToString();
                return _dekomDefaultPath;
            }
            set
            {
                _dekomDefaultPath = value;
            }
        }

        private static string _eltomDefaultPath;
        public static string EltomDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("EltomDefaultPath")?.ToString()))
                    _eltomDefaultPath = Helper.GetValueFromIniFile("EltomDefaultPath").ToString();
                return _eltomDefaultPath;
            }
            set
            {
                _eltomDefaultPath = value;
            }
        }

        private static string _elkondDefaultPath;
        public static string ElkondDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("ElkondDefaultPath")?.ToString()))
                    _elkondDefaultPath = Helper.GetValueFromIniFile("ElkondDefaultPath").ToString();
                return _elkondDefaultPath;
            }
            set
            {
                _elkondDefaultPath = value;
            }
        }

        private static string _statusFrigoDefaultPath;
        public static string StatusFrigoDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("StatusFrigoDefaultPath")?.ToString()))
                    _statusFrigoDefaultPath = Helper.GetValueFromIniFile("StatusFrigoDefaultPath").ToString();
                return _statusFrigoDefaultPath;
            }
            set
            {
                _statusFrigoDefaultPath = value;
            }
        }

        private static string _stelaxDefaultPath;
        public static string StelaxDefaultPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("StelaxDefaultPath")?.ToString()))
                    _stelaxDefaultPath = Helper.GetValueFromIniFile("StelaxDefaultPath").ToString();
                return _stelaxDefaultPath;
            }
            set
            {
                _stelaxDefaultPath = value;
            }
        }

        private static string _outputDefaultDirectoryPath;
        public static string OutputDefaultDirectoryPath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Helper.GetValueFromIniFile("OutputDefaultDirectoryPath")?.ToString()))
                    _outputDefaultDirectoryPath = Helper.GetValueFromIniFile("OutputDefaultDirectoryPath").ToString();
                return _outputDefaultDirectoryPath;
            }
            set
            {
                _outputDefaultDirectoryPath = value;
            }
        }

        private static Helper.ExcelFileFormat _fileFormat;
        public static Helper.ExcelFileFormat FileFormat
        {
            get
            {
                //Excel file format
                if (Helper.GetValueFromIniFile("FileFormat") != null)
                {
                    int.TryParse(Helper.GetValueFromIniFile("FileFormat")?.ToString(), out int enumVal);
                    return (Helper.ExcelFileFormat)enumVal;
                }

                return _fileFormat;
            }
            set
            {
                _fileFormat = value;
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
