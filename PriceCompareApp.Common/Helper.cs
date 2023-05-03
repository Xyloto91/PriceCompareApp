using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ExcelDataReader;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using PriceCompareApp.Model;
using static PriceCompareApp.Common.Helper;

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
            Loren,
            Vrecool,
            StatusFrigo
        }

        public enum ExcelFileFormat
        {
            Xls,
            Xlsx
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

        public static void DeleteOlderLogFiles(int days = 3)
        {
            try
            {
                Directory.GetFiles(LogDirectoryPath, "*.json")
                                 .Select(f => new FileInfo(f))
                                 .Where(f => f.CreationTime < DateTime.Now.AddDays(-days))
                                 .ToList()
                                 .ForEach(f => f.Delete());
            }
            catch (Exception)
            {
            }
        }

        public static string DecodeText(string text)
        {
            return WebUtility.HtmlDecode(text);
        }

        public static bool IsFileExistsOrNotEmpty(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
                return fileInfo.Length > 0;
            else
                return false;
        }

        public static List<string> ReadCodesFromExcelFile(string filePath)
        {
            List<string> itemCodes = new List<string>();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(fileStream, new ExcelReaderConfiguration { }))
            {
                if (excelDataReader.RowCount == 0)
                    throw new Exception("Excel file is empty!");
                else
                {
                    ExcelDataTableConfiguration excelConfig = new ExcelDataTableConfiguration { UseHeaderRow = false };

                    using (DataSet ds = excelDataReader.AsDataSet(new ExcelDataSetConfiguration { ConfigureDataTable = (_) => excelConfig }))
                    using (DataTable dt = ds.Tables[0])
                    {
                        bool foundItemCodes = false;
                        int unknownIdCnt = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i != 0 && dt.Rows[i - 1][0].ToString().Trim().ToUpper() == "ŠIFRA")
                                foundItemCodes = true;

                            if (foundItemCodes)
                            {
                                if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                                {
                                    var code = dt.Rows[i][0].ToString().Trim();
                                    if(code.ToLower().StartsWith("xxx")) //if code starts with xxx - unknown code append id number
                                        code = $"{code}{++unknownIdCnt}";
                                    itemCodes.Add(code);
                                }
                                else
                                    foundItemCodes = false;
                            }
                        }
                    }
                }
            }

            return itemCodes;
        }

        public static List<Item> ReadItemDataFromExcel(string filePath)
        {
            List<Item> itemCodes = new List<Item>();

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            using (IExcelDataReader excelDataReader = ExcelReaderFactory.CreateReader(fileStream, new ExcelReaderConfiguration { }))
            {
                if (excelDataReader.RowCount == 0)
                    throw new Exception("Excel file is empty!");
                else
                {
                    ExcelDataTableConfiguration excelConfig = new ExcelDataTableConfiguration { UseHeaderRow = false };

                    using (DataSet ds = excelDataReader.AsDataSet(new ExcelDataSetConfiguration { ConfigureDataTable = (_) => excelConfig }))
                    using (DataTable dt = ds.Tables[0])
                    {
                        bool foundItemCodes = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i != 0 && dt.Rows[i - 1][0].ToString().Trim().ToUpper() == "ŠIFRA")
                                foundItemCodes = true;

                            if (foundItemCodes)
                            {
                                if (!string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                                    itemCodes.Add( 
                                        new Item
                                        {
                                            Code = dt.Rows[i][0].ToString().Trim(),
                                            Name = dt.Rows[i][1].ToString().Trim(),
                                            Price = dt.Rows[i][4].ToString().Trim().Replace(".", ",").Replace(" ", ".")
                                        }
                                    );
                                else
                                    foundItemCodes = false;
                            }
                        }
                    }
                }
            }

            return itemCodes;
        }

        public static void CreateExcelFileWithPrice(List<Item> sourceItemData, Dictionary<WebSite, List<Item>> itemDataByWebSite, string directory, string fileName, ExcelFileFormat excelFileFormat = ExcelFileFormat.Xls)
        {
            try
            {
                using (var fs = new FileStream(Path.Combine(directory, $"{fileName}.{(excelFileFormat == ExcelFileFormat.Xls ? "xls" : "xlsx")}"), FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook;

                    if (excelFileFormat == ExcelFileFormat.Xls)
                        workbook = new HSSFWorkbook();
                    else
                        workbook = new XSSFWorkbook();

                    ISheet excelSheet = workbook.CreateSheet("Cene artikala");

                    ICellStyle codeCellStyle = workbook.CreateCellStyle();
                    ICellStyle nameCellStyle = workbook.CreateCellStyle();
                    ICellStyle priceCellStyle = workbook.CreateCellStyle();

                    excelSheet.SetColumnWidth(0, 15 * 256);
                    excelSheet.SetColumnWidth(1, 55 * 256);
                    excelSheet.SetColumnWidth(2, 12 * 256);
                    excelSheet.SetColumnWidth(3, 12 * 256);
                    excelSheet.SetColumnWidth(4, 12 * 256);
                    excelSheet.SetColumnWidth(5, 12 * 256);
                    excelSheet.SetColumnWidth(6, 12 * 256);
                    excelSheet.SetColumnWidth(7, 12 * 256);

                    List<string> columns = new List<string>() { "Šifra proizvoda", "Naziv proizvoda", "Cena", "Dekom", "Elkond", "Eltom", "Loren", "Status frigo", "Vrecool" };
                    IRow row = excelSheet.CreateRow(0);

                    foreach (var columnData in columns.Select((v, i) => new { Column = v, Index = i }).ToList())
                        row.CreateCell(columnData.Index).SetCellValue(columnData.Column);

                    codeCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("@");
                    nameCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("@");
                    priceCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("#,#0.00");

                    int rowIndex = 1;

                    foreach (var item in sourceItemData)
                    {
                        row = excelSheet.CreateRow(rowIndex);
                        row.CreateCell(0).SetCellValue(item.Code);
                        row.Cells[0].CellStyle = codeCellStyle;
                        row.CreateCell(1).SetCellValue(item.Name);
                        row.Cells[1].CellStyle = codeCellStyle;

                        ICell priceCell = row.CreateCell(2);
                        priceCell.CellStyle = priceCellStyle;

                        priceCell.SetCellValue(double.Parse(item.Price));
                        priceCell.SetCellType(CellType.Numeric);

                        foreach (var webSite in itemDataByWebSite)
                        {
                            InsertWebSiteDataInCoulumn(
                                webSite: webSite.Key, 
                                webSiteData: webSite.Value[rowIndex - 1], 
                                row: row, 
                                cellStyle: priceCellStyle);
                        }

                        rowIndex++;
                    }

                    workbook.Write(fs);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached) Debugger.Break();
                Serilog.Log.Error(ex, "Exception occured while creating excel file!");
                throw ex;
            }
        }

        private static void InsertWebSiteDataInCoulumn(WebSite webSite, Item webSiteData, IRow row, ICellStyle cellStyle)
        {
            switch (webSite)
            {
                case WebSite.Dekom:
                    InsertPriceDataInColumn(row, 3, webSiteData, cellStyle);
                    break;

                case WebSite.Elkond:
                    InsertPriceDataInColumn(row, 4, webSiteData, cellStyle);
                    break;

                case WebSite.Eltom:
                    InsertPriceDataInColumn(row, 5, webSiteData, cellStyle);
                    break;

                case WebSite.Loren:
                    InsertPriceDataInColumn(row, 6, webSiteData, cellStyle);
                    break;

                case WebSite.StatusFrigo:
                    InsertPriceDataInColumn(row, 7, webSiteData, cellStyle);
                    break;

                case WebSite.Vrecool:
                    InsertPriceDataInColumn(row, 8, webSiteData, cellStyle);
                    break;

                default:
                    throw new NotImplementedException($"Not implemented for website {webSite}!");
            }
        }

        private static void InsertPriceDataInColumn(IRow row, int column, Item item, ICellStyle priceCellStyle)
        {
            ICell priceCell = row.CreateCell(column);
            priceCell.CellStyle = priceCellStyle;

            if (item.HasData)
            {
                if (item.Price == "NA UPIT")
                {
                    row.CreateCell(column).SetCellValue(item.Price);
                }
                else
                {
                    priceCell.SetCellValue(double.Parse(item.Price));
                    priceCell.SetCellType(CellType.Numeric);
                }
            }
            else
            {
                row.CreateCell(column).SetCellValue("");
            }
        }
    }
}
