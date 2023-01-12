using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareApp.Common
{
    public class Helper
    {
        public const string LogFolder = "PriceCompareAppLogs";
        public const string ConfigurationIniFile = "PriceCompareAppConfiguration";

        public static string LogDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), LogFolder);
        public static string IniFilePath = Path.Combine(LogDirectoryPath, $"{ConfigurationIniFile}.ini");

        public enum WebSite
        {
            Dekom,
            Eltom,
            Elkond,
            Loren
        }

        public static TimeSpan GetDefaultConnectionLossTimeout()
        {
            string value = Configuration.ConnectionLossTimeout.Trim();

            if (!TimeSpan.TryParse(value, out TimeSpan timeout))
                timeout = new TimeSpan(0, 1, 0);

            return timeout;
        }

        public static object GetValueFromIniFile(string key)
        {
            if (!File.Exists(IniFilePath))
            {
                return null;
            }
            else
            {
                string[] iniFileText = File.ReadAllLines(IniFilePath);

                if (iniFileText != null && iniFileText.Length != 0)
                {
                    for (int i = 0; i < iniFileText.Length; i++)
                    {
                        if (iniFileText[i].Contains($"{key}="))
                        {
                            return iniFileText[i].Trim().Replace($"{key}=", "");
                        }
                    }
                }

                return null;
            }
        }

        public static void WriteValueToIniFile(string section, string key, string value)
        {
            CreateIniFileIfDoesntExists(IniFilePath);

            string[] iniFileText = File.ReadAllLines(IniFilePath);

            if (iniFileText != null && iniFileText.Length != 0)
            {
                if (iniFileText.AsEnumerable().Any(s => s.Contains($"[{section}]") && iniFileText.AsEnumerable().Any(k => k.Contains($"{key}="))))
                {
                    for (int i = 0; i < iniFileText.Length; i++)
                    {
                        if (iniFileText[i].Contains($"{key}="))
                        {
                            iniFileText[i] = $"{key}={value}";
                        }
                    }
                }
                else if (iniFileText.AsEnumerable().Any(s => s.Contains($"[{section}]")))
                {
                    Array.Resize<string>(ref iniFileText, iniFileText.Length + 1);
                    iniFileText[iniFileText.Length - 1] = $"{key}={value}";
                }
                else
                {
                    Array.Resize<string>(ref iniFileText, iniFileText.Length + 1);
                    iniFileText[iniFileText.Length - 1] = $"[{section}]";
                    Array.Resize<string>(ref iniFileText, iniFileText.Length + 1);
                    iniFileText[iniFileText.Length - 1] = $"{key}={value}";
                }
                File.WriteAllLines(IniFilePath, iniFileText, System.Text.Encoding.GetEncoding(1250));
            }
            else
            {
                File.WriteAllLines(IniFilePath, new string[] { $"[{section}]{Environment.NewLine}{key}={value}" }, Encoding.GetEncoding(1250));
            }
        }

        public static void CreateIniFileIfDoesntExists(string iniFilePath)
        {
            if (!File.Exists(iniFilePath))
            {
                using (FileStream fs = File.Create(iniFilePath)) { }
            }
        }

        public static string DecodeText(string text)
        {
            return WebUtility.HtmlDecode(text);
        }

    }
}
