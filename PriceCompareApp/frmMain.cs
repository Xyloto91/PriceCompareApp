using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceCompareApp.UI
{
    public partial class frmMain : Form
    {

        public string DekomFilePath { get; set; }
        public string ElknodFilePath {get; set;}
        public string EltomFilePath { get; set; }
        public string LorenFilePath { get; set; }
        public string StatusFrigoFilePath { get; set; }
        public string VrecoolFilePath { get; set; }
        public string StelaxFilePath { get; set; }
        public string OutputDirectory   { get; set; }

        public bool DekomChecked => chkRunDekomScraping.Checked;
        public bool ElknodChecked => chkRunElknodScraping.Checked;
        public bool EltomChecked => chkRunEltomScraping.Checked;
        public bool LorenChecked => chkRunLorenScraping.Checked;
        public bool StatusFrigoChecked => chkRunStatusFrigoScraping.Checked;
        public bool VrecoolChecked => chkRunVrecoolScraping.Checked;
        public bool StelaxChecked => chkRunStelaxScraping.Checked;

        public frmMain()
        {
            InitializeComponent();
        }

        private void LoadIcons()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PriceCompareApp.Icons.opened-folder-16.png");
            if (stream != null)
            {
                btnDekomFilePath.Image = Image.FromStream(stream);
                btnElknodFilePath.Image = Image.FromStream(stream);
                btnEltomFilePath.Image = Image.FromStream(stream);
                btnLorenFilePath.Image = Image.FromStream(stream);
                btnStatusFrigoFilePath.Image = Image.FromStream(stream);
                btnVrecoolFilePath.Image = Image.FromStream(stream);
                btnStelaxFilePath.Image = Image.FromStream(stream);
                btnOutputDirectory.Image = Image.FromStream(stream);

            }

            stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PriceCompareApp.Icons.price-tag.ico");
            if (stream != null)
                this.Icon = new Icon(stream);

            stream.Close();
            stream.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadIcons();
        }

        private void btnRunWebScrapingProcess_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            DekomFilePath = txtDekomFilePath.Text.Trim();
            ElknodFilePath = txtElknodFilePath.Text.Trim();
            EltomFilePath = txtEltomFilePath.Text.Trim();
            LorenFilePath = txtLorenFilePath.Text.Trim();
            StatusFrigoFilePath = txtStatusFrigoFilePath.Text.Trim();
            VrecoolFilePath = txtVrecoolFilePath.Text.Trim();
            StelaxFilePath = txtStelaxFilePath.Text.Trim();

            if (DekomChecked && string.IsNullOrEmpty(DekomFilePath)) //|| !Helpers.IsFileExistsOrNotEmpty(VrecoolFilePath))))
            {
                MessageBox.Show("Dekom file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (ElknodChecked && string.IsNullOrEmpty(ElknodFilePath))
            {
                MessageBox.Show("Elknod file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (EltomChecked && string.IsNullOrEmpty(EltomFilePath))
            {
                MessageBox.Show("Eltom file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (LorenChecked && string.IsNullOrEmpty(LorenFilePath))
            {
                MessageBox.Show("Loren file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (StatusFrigoChecked && string.IsNullOrEmpty(StatusFrigoFilePath))
            {
                MessageBox.Show("Status Frigo file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (VrecoolChecked && string.IsNullOrEmpty(VrecoolFilePath))
            {
                MessageBox.Show("Vrecool file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
            else if (StelaxChecked && string.IsNullOrEmpty(StelaxFilePath))
            {
                MessageBox.Show("Stelax file is empty or doesn't exists!", "Warning");
                isValid = false;
            }
        }

        private void btnDekomFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnElknodFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnEltomFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnLorenFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnStatusFrigoFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnVrecoolFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnStelaxFilePath_Click(object sender, EventArgs e)
        {

        }

        private void btnOutputDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}
