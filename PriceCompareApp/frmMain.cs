using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PriceCompareApp.Common;
using PriceCompareApp.Core;
using PriceCompareApp.Model;
using Serilog;
using Serilog.Formatting.Compact;
using static PriceCompareApp.Common.Helper;

namespace PriceCompareApp.UI
{
    public partial class frmMain : Form
    {
        public string DekomFilePath { get; set; }
        public string ElkondFilePath { get; set; }
        public string EltomFilePath { get; set; }
        public string LorenFilePath { get; set; }
        public string StatusFrigoFilePath { get; set; }
        public string VrecoolFilePath { get; set; }
        public string StelaxFilePath { get; set; }
        public string OutputDirectory { get; set; }

        public bool DekomChecked => chkRunDekomScraping.Checked;
        public bool ElkondChecked => chkRunElkondScraping.Checked;
        public bool EltomChecked => chkRunEltomScraping.Checked;
        public bool LorenChecked => chkRunLorenScraping.Checked;
        public bool StatusFrigoChecked => chkRunStatusFrigoScraping.Checked;
        public bool VrecoolChecked => chkRunVrecoolScraping.Checked;

        private delegate void SetOutputTextCallback(string text);
        private bool IsAnyScrapingOptionChecked
        {
            get
            {
                return DekomChecked
                    || ElkondChecked
                    || EltomChecked
                    || LorenChecked
                    || StatusFrigoChecked
                    || VrecoolChecked;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void LoadIcons()
        {
            Stream stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("PriceCompareApp.Icons.opened-folder-16.png");
            if (stream != null)
            {
                btnDekomFilePath.Image = Image.FromStream(stream);
                btnElkondFilePath.Image = Image.FromStream(stream);
                btnEltomFilePath.Image = Image.FromStream(stream);
                btnLorenFilePath.Image = Image.FromStream(stream);
                btnStatusFrigoFilePath.Image = Image.FromStream(stream);
                btnVrecoolFilePath.Image = Image.FromStream(stream);
                btnStelaxFilePath.Image = Image.FromStream(stream);
                btnOutputDirectory.Image = Image.FromStream(stream);
            }

            stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("PriceCompareApp.Icons.price-tag.ico");
            if (stream != null)
                this.Icon = new Icon(stream);

            stream.Close();
            stream.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string logDirectoryPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "PriceCompareAppLogs"
            );
            string iniFilePath = Path.Combine(logDirectoryPath, "PriceCompareAppConfiguration.ini");

            LoadIcons();
            ConfigureLogger();
            CreateIniFileIfDoesntExists(iniFilePath);
            LoadDefaultValues();
            WriteDefaultConnectionLossTimeout();
        }

        private async void btnRunWebScrapingProcess_Click(object sender, EventArgs e)
        {
            DekomFilePath = txtDekomFilePath.Text.Trim();
            ElkondFilePath = txtElkondFilePath.Text.Trim();
            EltomFilePath = txtEltomFilePath.Text.Trim();
            LorenFilePath = txtLorenFilePath.Text.Trim();
            StatusFrigoFilePath = txtStatusFrigoFilePath.Text.Trim();
            VrecoolFilePath = txtVrecoolFilePath.Text.Trim();
            StelaxFilePath = txtStelaxFilePath.Text.Trim();

            if (
                DekomChecked
                && (
                    string.IsNullOrEmpty(DekomFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(DekomFilePath)
                )
            )
            {
                MessageBox.Show("Dekom file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                ElkondChecked
                && (
                    string.IsNullOrEmpty(ElkondFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(ElkondFilePath)
                )
            )
            {
                MessageBox.Show("Elknod file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                EltomChecked
                && (
                    string.IsNullOrEmpty(EltomFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(EltomFilePath)
                )
            )
            {
                MessageBox.Show("Eltom file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                LorenChecked
                && (
                    string.IsNullOrEmpty(LorenFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(LorenFilePath)
                )
            )
            {
                MessageBox.Show("Loren file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                StatusFrigoChecked
                && (
                    string.IsNullOrEmpty(StatusFrigoFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(StatusFrigoFilePath)
                )
            )
            {
                MessageBox.Show("Status Frigo file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                VrecoolChecked
                && (
                    string.IsNullOrEmpty(VrecoolFilePath)
                    || !Helper.IsFileExistsOrNotEmpty(VrecoolFilePath)
                )
            )
            {
                MessageBox.Show("Vrecool file is empty or doesn't exists!", "Warning");
                return;
            }
            else if (
                string.IsNullOrEmpty(StelaxFilePath)
                || !Helper.IsFileExistsOrNotEmpty(StelaxFilePath)
            )
            {
                MessageBox.Show("Stelax file is empty or doesn't exists!", "Warning");
                return;
            }

            if (IsAnyScrapingOptionChecked == false)
            {
                MessageBox.Show("Please check at least one site to scrap!", "Warning");
                return;
            }

            try
            {
                List<string> vrecoolItemCodes;
                List<string> lorenItemCodes;
                List<string> dekomItemCodes;
                List<string> eltomItemCodes;
                List<string> elkondItemCodes;
                List<string> statusFrigoItemCodes;

                List<Item> vrecoolItemData;
                List<Item> lorenItemData;
                List<Item> dekomItemData;
                List<Item> eltomItemData;
                List<Item> elkondItemData;
                List<Item> statusFrigoItemData;
                List<Item> stelaxItemData;

                ExcelFileFormat excelFileFormat = Configuration.FileFormat;

                txtLog.Clear();
                btnRunWebScrapingProcess.Enabled = false;

                LogMessage(
                    $"Default connection loss timeout: {GetDefaultConnectionLossTimeout().ToString().Trim()}"
                );

                LogMessage("> Scraping operation started");

                var scrapedDataByWebSite = new Dictionary<WebSite, List<Item>>();
                var webScraper = WebScraper.InitializeWebScraper(LogMessage);

                if (VrecoolChecked)
                {
                    vrecoolItemCodes = Helper.ReadCodesFromExcelFile(VrecoolFilePath);

                    if (vrecoolItemCodes?.Count > 0)
                    {
                        vrecoolItemData = await webScraper.Execute(
                            WebSite.Vrecool,
                            vrecoolItemCodes
                        );
                        scrapedDataByWebSite.Add(WebSite.Vrecool, vrecoolItemData);

                        if (LorenChecked)
                            LogMessage("");
                    }
                }

                if (LorenChecked)
                {
                    lorenItemCodes = ReadCodesFromExcelFile(LorenFilePath);

                    if (lorenItemCodes?.Count > 0)
                    {
                        lorenItemData = await webScraper.Execute(WebSite.Loren, lorenItemCodes);
                        scrapedDataByWebSite.Add(WebSite.Loren, lorenItemData);

                        if (DekomChecked)
                            LogMessage("");
                    }
                }

                if (DekomChecked)
                {
                    dekomItemCodes = ReadCodesFromExcelFile(DekomFilePath);

                    if (dekomItemCodes?.Count > 0)
                    {
                        dekomItemData = await webScraper.Execute(WebSite.Dekom, dekomItemCodes);
                        scrapedDataByWebSite.Add(WebSite.Dekom, dekomItemData);

                        if (ElkondChecked)
                            LogMessage("");
                    }
                }

                if (ElkondChecked)
                {
                    elkondItemCodes = ReadCodesFromExcelFile(ElkondFilePath);

                    if (elkondItemCodes?.Count > 0)
                    {
                        elkondItemData = await webScraper.Execute(WebSite.Elkond, elkondItemCodes);
                        scrapedDataByWebSite.Add(WebSite.Elkond, elkondItemData);

                        if (EltomChecked)
                            LogMessage("");
                    }
                }

                if (EltomChecked)
                {
                    eltomItemCodes = ReadCodesFromExcelFile(EltomFilePath);

                    if (eltomItemCodes?.Count > 0)
                    {
                        eltomItemData = await webScraper.Execute(WebSite.Eltom, eltomItemCodes);
                        scrapedDataByWebSite.Add(WebSite.Eltom, eltomItemData);

                        if (StatusFrigoChecked)
                            LogMessage("");
                    }
                }

                if (StatusFrigoChecked)
                {
                    statusFrigoItemCodes = ReadCodesFromExcelFile(StatusFrigoFilePath);

                    if (statusFrigoItemCodes?.Count > 0)
                    {
                        statusFrigoItemData = await webScraper.Execute(
                            WebSite.StatusFrigo,
                            statusFrigoItemCodes
                        );
                        scrapedDataByWebSite.Add(WebSite.StatusFrigo, statusFrigoItemData);
                    }
                }

                stelaxItemData = ReadItemDataFromExcel(StelaxFilePath);

                string fileName = $"Cene artikala";
                string destinationFolder = !string.IsNullOrEmpty(txtOutputDirectoryPath.Text.Trim())
                    ? txtOutputDirectoryPath.Text.Trim()
                    : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                CreateExcelFileWithPrice(
                    sourceItemData: stelaxItemData,
                    itemDataByWebSite: scrapedDataByWebSite,
                    directory: destinationFolder,
                    fileName: fileName,
                    excelFileFormat: Configuration.FileFormat
                );

                LogMessage("< Scraping operation finished");
                btnRunWebScrapingProcess.Enabled = true;
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                MessageBox.Show(
                    $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Log.Error(ex, "Exception occured while running scraper!");
                btnRunWebScrapingProcess.Enabled = true;
                throw;
            }
        }

        private void btnDekomFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDekomFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtDekomFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.DekomDefaultPath = txtDekomFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnElknodFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtElkondFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtElkondFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.ElkondDefaultPath = txtElkondFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnEltomFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtEltomFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtEltomFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.EltomDefaultPath = txtEltomFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnLorenFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtLorenFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtLorenFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.LorenDefaultPath = txtLorenFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnStatusFrigoFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtStatusFrigoFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtStatusFrigoFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.StatusFrigoDefaultPath =
                                txtStatusFrigoFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnVrecoolFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtVrecoolFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtVrecoolFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.VrecoolDefaultPath = txtVrecoolFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnStelaxFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel Files (*.xls,*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtStelaxFilePath.Text = fileDialog.FileName;

                    if (!string.IsNullOrEmpty(txtStelaxFilePath.Text.Trim()))
                    {
                        if (
                            MessageBox.Show(
                                "Would you like to set choosen path as default path?",
                                "Default path",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            ) == DialogResult.Yes
                        )
                        {
                            Configuration.StelaxDefaultPath = txtStelaxFilePath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtOutputDirectoryPath.Text = folderDialog.SelectedPath.Trim();

                    if (!string.IsNullOrEmpty(txtOutputDirectoryPath.Text.Trim()))
                    {
                        if (MessageBox.Show("Would you like to set choosen path as default path?", "Default path", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Configuration.OutputDefaultDirectoryPath = txtOutputDirectoryPath.Text.Trim();
                            Configuration.SaveSettings();
                        }
                    }
                }
            }
        }

        private void LogMessage(string text)
        {
            if (text != null)
            {
                Log.Information(text);
                if (this.txtLog.InvokeRequired)
                {
                    SetOutputTextCallback d = new SetOutputTextCallback(LogMessage);
                    try
                    {
                        this.Invoke(d, new object[] { text });
                    }
                    catch (ObjectDisposedException) //if you close program during execution ignore this exception
                    { }
                }
                else
                {
                    this.txtLog.AppendText(text + Environment.NewLine);
                    this.txtLog.Refresh();
                }
            }
        }

        private void ConfigureLogger()
        {
            Helper.DeleteOlderLogFiles(days: 3);

            Log.Logger = new LoggerConfiguration().MinimumLevel
                .Debug()
                .WriteTo.Logger(
                    l =>
                        l.WriteTo
                            .File(
                                new CustomCompactJsonFormatter(),
                                $"{Helper.LogDirectoryPath}/PriceCompareAppLog_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.json"
                            )
                            .Filter.ByExcluding(
                                le => le.Level == Serilog.Events.LogEventLevel.Debug
                            )
                            
                )
                .CreateLogger();
        }

        private void LoadDefaultValues()
        {
            txtVrecoolFilePath.Text = Configuration.VrecoolDefaultPath;
            txtLorenFilePath.Text = Configuration.LorenDefaultPath;
            txtDekomFilePath.Text = Configuration.DekomDefaultPath;
            txtElkondFilePath.Text = Configuration.ElkondDefaultPath;
            txtEltomFilePath.Text = Configuration.EltomDefaultPath;
            txtStatusFrigoFilePath.Text = Configuration.StatusFrigoDefaultPath;
            txtStelaxFilePath.Text = Configuration.StelaxDefaultPath;
            txtOutputDirectoryPath.Text = Configuration.OutputDefaultDirectoryPath;
        }

        private void WriteDefaultConnectionLossTimeout()
        {
            Configuration.ConnectionLossTimeout = "00:01:00";
        }
    }
}
