namespace PriceCompareApp.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlFile = new System.Windows.Forms.Panel();
            this.gbOutputDirectory = new System.Windows.Forms.GroupBox();
            this.btnOutputDirectory = new System.Windows.Forms.Button();
            this.txtOutputDirectoryPath = new System.Windows.Forms.TextBox();
            this.lblOutputDirectory = new System.Windows.Forms.Label();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.btnStelaxFilePath = new System.Windows.Forms.Button();
            this.txtStelaxFilePath = new System.Windows.Forms.TextBox();
            this.lblStelaxFilePath = new System.Windows.Forms.Label();
            this.chkRunVrecoolScraping = new System.Windows.Forms.CheckBox();
            this.btnVrecoolFilePath = new System.Windows.Forms.Button();
            this.txtVrecoolFilePath = new System.Windows.Forms.TextBox();
            this.lblVrecoolFilePath = new System.Windows.Forms.Label();
            this.chkRunStatusFrigoScraping = new System.Windows.Forms.CheckBox();
            this.btnStatusFrigoFilePath = new System.Windows.Forms.Button();
            this.txtStatusFrigoFilePath = new System.Windows.Forms.TextBox();
            this.lblStatusFrigoFilePath = new System.Windows.Forms.Label();
            this.chkRunLorenScraping = new System.Windows.Forms.CheckBox();
            this.btnLorenFilePath = new System.Windows.Forms.Button();
            this.txtLorenFilePath = new System.Windows.Forms.TextBox();
            this.lblLorenFilePath = new System.Windows.Forms.Label();
            this.chkRunEltomScraping = new System.Windows.Forms.CheckBox();
            this.btnEltomFilePath = new System.Windows.Forms.Button();
            this.txtEltomFilePath = new System.Windows.Forms.TextBox();
            this.lblEltomFilePath = new System.Windows.Forms.Label();
            this.chkRunElkondScraping = new System.Windows.Forms.CheckBox();
            this.btnElkondFilePath = new System.Windows.Forms.Button();
            this.txtElkondFilePath = new System.Windows.Forms.TextBox();
            this.lblElkondFilePath = new System.Windows.Forms.Label();
            this.chkRunDekomScraping = new System.Windows.Forms.CheckBox();
            this.btnDekomFilePath = new System.Windows.Forms.Button();
            this.txtDekomFilePath = new System.Windows.Forms.TextBox();
            this.lblDekomlFilePath = new System.Windows.Forms.Label();
            this.pnlOutputLog = new System.Windows.Forms.Panel();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnlRun = new System.Windows.Forms.Panel();
            this.gbRun = new System.Windows.Forms.GroupBox();
            this.btnRunWebScrapingProcess = new System.Windows.Forms.Button();
            this.pnlFile.SuspendLayout();
            this.gbOutputDirectory.SuspendLayout();
            this.gbFiles.SuspendLayout();
            this.pnlOutputLog.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.pnlRun.SuspendLayout();
            this.gbRun.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFile
            // 
            this.pnlFile.AutoSize = true;
            this.pnlFile.Controls.Add(this.gbOutputDirectory);
            this.pnlFile.Controls.Add(this.gbFiles);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFile.Location = new System.Drawing.Point(0, 0);
            this.pnlFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(1244, 333);
            this.pnlFile.TabIndex = 0;
            // 
            // gbOutputDirectory
            // 
            this.gbOutputDirectory.Controls.Add(this.btnOutputDirectory);
            this.gbOutputDirectory.Controls.Add(this.txtOutputDirectoryPath);
            this.gbOutputDirectory.Controls.Add(this.lblOutputDirectory);
            this.gbOutputDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOutputDirectory.Location = new System.Drawing.Point(0, 255);
            this.gbOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputDirectory.Name = "gbOutputDirectory";
            this.gbOutputDirectory.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbOutputDirectory.Size = new System.Drawing.Size(1244, 78);
            this.gbOutputDirectory.TabIndex = 0;
            this.gbOutputDirectory.TabStop = false;
            this.gbOutputDirectory.Text = "Output directory";
            // 
            // btnOutputDirectory
            // 
            this.btnOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputDirectory.Location = new System.Drawing.Point(1170, 25);
            this.btnOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOutputDirectory.Name = "btnOutputDirectory";
            this.btnOutputDirectory.Size = new System.Drawing.Size(33, 28);
            this.btnOutputDirectory.TabIndex = 31;
            this.btnOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOutputDirectory.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // txtOutputDirectoryPath
            // 
            this.txtOutputDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDirectoryPath.Location = new System.Drawing.Point(168, 28);
            this.txtOutputDirectoryPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputDirectoryPath.Name = "txtOutputDirectoryPath";
            this.txtOutputDirectoryPath.Size = new System.Drawing.Size(993, 22);
            this.txtOutputDirectoryPath.TabIndex = 30;
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoSize = true;
            this.lblOutputDirectory.Location = new System.Drawing.Point(12, 31);
            this.lblOutputDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(83, 16);
            this.lblOutputDirectory.TabIndex = 29;
            this.lblOutputDirectory.Text = "Save files to ";
            // 
            // gbFiles
            // 
            this.gbFiles.Controls.Add(this.btnStelaxFilePath);
            this.gbFiles.Controls.Add(this.txtStelaxFilePath);
            this.gbFiles.Controls.Add(this.lblStelaxFilePath);
            this.gbFiles.Controls.Add(this.chkRunVrecoolScraping);
            this.gbFiles.Controls.Add(this.btnVrecoolFilePath);
            this.gbFiles.Controls.Add(this.txtVrecoolFilePath);
            this.gbFiles.Controls.Add(this.lblVrecoolFilePath);
            this.gbFiles.Controls.Add(this.chkRunStatusFrigoScraping);
            this.gbFiles.Controls.Add(this.btnStatusFrigoFilePath);
            this.gbFiles.Controls.Add(this.txtStatusFrigoFilePath);
            this.gbFiles.Controls.Add(this.lblStatusFrigoFilePath);
            this.gbFiles.Controls.Add(this.chkRunLorenScraping);
            this.gbFiles.Controls.Add(this.btnLorenFilePath);
            this.gbFiles.Controls.Add(this.txtLorenFilePath);
            this.gbFiles.Controls.Add(this.lblLorenFilePath);
            this.gbFiles.Controls.Add(this.chkRunEltomScraping);
            this.gbFiles.Controls.Add(this.btnEltomFilePath);
            this.gbFiles.Controls.Add(this.txtEltomFilePath);
            this.gbFiles.Controls.Add(this.lblEltomFilePath);
            this.gbFiles.Controls.Add(this.chkRunElkondScraping);
            this.gbFiles.Controls.Add(this.btnElkondFilePath);
            this.gbFiles.Controls.Add(this.txtElkondFilePath);
            this.gbFiles.Controls.Add(this.lblElkondFilePath);
            this.gbFiles.Controls.Add(this.chkRunDekomScraping);
            this.gbFiles.Controls.Add(this.btnDekomFilePath);
            this.gbFiles.Controls.Add(this.txtDekomFilePath);
            this.gbFiles.Controls.Add(this.lblDekomlFilePath);
            this.gbFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiles.Location = new System.Drawing.Point(0, 0);
            this.gbFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbFiles.Size = new System.Drawing.Size(1244, 255);
            this.gbFiles.TabIndex = 0;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files";
            // 
            // btnStelaxFilePath
            // 
            this.btnStelaxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStelaxFilePath.Location = new System.Drawing.Point(1174, 222);
            this.btnStelaxFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStelaxFilePath.Name = "btnStelaxFilePath";
            this.btnStelaxFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnStelaxFilePath.TabIndex = 28;
            this.btnStelaxFilePath.UseVisualStyleBackColor = true;
            this.btnStelaxFilePath.Click += new System.EventHandler(this.btnStelaxFilePath_Click);
            // 
            // txtStelaxFilePath
            // 
            this.txtStelaxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStelaxFilePath.Location = new System.Drawing.Point(168, 224);
            this.txtStelaxFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStelaxFilePath.Name = "txtStelaxFilePath";
            this.txtStelaxFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtStelaxFilePath.TabIndex = 27;
            // 
            // lblStelaxFilePath
            // 
            this.lblStelaxFilePath.AutoSize = true;
            this.lblStelaxFilePath.Location = new System.Drawing.Point(16, 228);
            this.lblStelaxFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStelaxFilePath.Name = "lblStelaxFilePath";
            this.lblStelaxFilePath.Size = new System.Drawing.Size(93, 16);
            this.lblStelaxFilePath.TabIndex = 26;
            this.lblStelaxFilePath.Text = "Stelax file path";
            // 
            // chkRunVrecoolScraping
            // 
            this.chkRunVrecoolScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunVrecoolScraping.AutoSize = true;
            this.chkRunVrecoolScraping.Location = new System.Drawing.Point(1218, 192);
            this.chkRunVrecoolScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunVrecoolScraping.Name = "chkRunVrecoolScraping";
            this.chkRunVrecoolScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunVrecoolScraping.TabIndex = 25;
            this.chkRunVrecoolScraping.UseVisualStyleBackColor = true;
            // 
            // btnVrecoolFilePath
            // 
            this.btnVrecoolFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVrecoolFilePath.Location = new System.Drawing.Point(1174, 185);
            this.btnVrecoolFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVrecoolFilePath.Name = "btnVrecoolFilePath";
            this.btnVrecoolFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnVrecoolFilePath.TabIndex = 24;
            this.btnVrecoolFilePath.UseVisualStyleBackColor = true;
            this.btnVrecoolFilePath.Click += new System.EventHandler(this.btnVrecoolFilePath_Click);
            // 
            // txtVrecoolFilePath
            // 
            this.txtVrecoolFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVrecoolFilePath.Location = new System.Drawing.Point(168, 187);
            this.txtVrecoolFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVrecoolFilePath.Name = "txtVrecoolFilePath";
            this.txtVrecoolFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtVrecoolFilePath.TabIndex = 23;
            // 
            // lblVrecoolFilePath
            // 
            this.lblVrecoolFilePath.AutoSize = true;
            this.lblVrecoolFilePath.Location = new System.Drawing.Point(16, 191);
            this.lblVrecoolFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVrecoolFilePath.Name = "lblVrecoolFilePath";
            this.lblVrecoolFilePath.Size = new System.Drawing.Size(103, 16);
            this.lblVrecoolFilePath.TabIndex = 22;
            this.lblVrecoolFilePath.Text = "Vrecool file path";
            // 
            // chkRunStatusFrigoScraping
            // 
            this.chkRunStatusFrigoScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunStatusFrigoScraping.AutoSize = true;
            this.chkRunStatusFrigoScraping.Location = new System.Drawing.Point(1219, 160);
            this.chkRunStatusFrigoScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunStatusFrigoScraping.Name = "chkRunStatusFrigoScraping";
            this.chkRunStatusFrigoScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunStatusFrigoScraping.TabIndex = 21;
            this.chkRunStatusFrigoScraping.UseVisualStyleBackColor = true;
            // 
            // btnStatusFrigoFilePath
            // 
            this.btnStatusFrigoFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusFrigoFilePath.Location = new System.Drawing.Point(1174, 153);
            this.btnStatusFrigoFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStatusFrigoFilePath.Name = "btnStatusFrigoFilePath";
            this.btnStatusFrigoFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnStatusFrigoFilePath.TabIndex = 20;
            this.btnStatusFrigoFilePath.UseVisualStyleBackColor = true;
            this.btnStatusFrigoFilePath.Click += new System.EventHandler(this.btnStatusFrigoFilePath_Click);
            // 
            // txtStatusFrigoFilePath
            // 
            this.txtStatusFrigoFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusFrigoFilePath.Location = new System.Drawing.Point(168, 155);
            this.txtStatusFrigoFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatusFrigoFilePath.Name = "txtStatusFrigoFilePath";
            this.txtStatusFrigoFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtStatusFrigoFilePath.TabIndex = 19;
            // 
            // lblStatusFrigoFilePath
            // 
            this.lblStatusFrigoFilePath.AutoSize = true;
            this.lblStatusFrigoFilePath.Location = new System.Drawing.Point(16, 159);
            this.lblStatusFrigoFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusFrigoFilePath.Name = "lblStatusFrigoFilePath";
            this.lblStatusFrigoFilePath.Size = new System.Drawing.Size(124, 16);
            this.lblStatusFrigoFilePath.TabIndex = 18;
            this.lblStatusFrigoFilePath.Text = "StatusFrigo file path";
            // 
            // chkRunLorenScraping
            // 
            this.chkRunLorenScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunLorenScraping.AutoSize = true;
            this.chkRunLorenScraping.Location = new System.Drawing.Point(1218, 128);
            this.chkRunLorenScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunLorenScraping.Name = "chkRunLorenScraping";
            this.chkRunLorenScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunLorenScraping.TabIndex = 17;
            this.chkRunLorenScraping.UseVisualStyleBackColor = true;
            // 
            // btnLorenFilePath
            // 
            this.btnLorenFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLorenFilePath.Location = new System.Drawing.Point(1174, 121);
            this.btnLorenFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLorenFilePath.Name = "btnLorenFilePath";
            this.btnLorenFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnLorenFilePath.TabIndex = 16;
            this.btnLorenFilePath.UseVisualStyleBackColor = true;
            this.btnLorenFilePath.Click += new System.EventHandler(this.btnLorenFilePath_Click);
            // 
            // txtLorenFilePath
            // 
            this.txtLorenFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLorenFilePath.Location = new System.Drawing.Point(168, 123);
            this.txtLorenFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLorenFilePath.Name = "txtLorenFilePath";
            this.txtLorenFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtLorenFilePath.TabIndex = 15;
            // 
            // lblLorenFilePath
            // 
            this.lblLorenFilePath.AutoSize = true;
            this.lblLorenFilePath.Location = new System.Drawing.Point(16, 127);
            this.lblLorenFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLorenFilePath.Name = "lblLorenFilePath";
            this.lblLorenFilePath.Size = new System.Drawing.Size(90, 16);
            this.lblLorenFilePath.TabIndex = 14;
            this.lblLorenFilePath.Text = "Loren file path";
            // 
            // chkRunEltomScraping
            // 
            this.chkRunEltomScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunEltomScraping.AutoSize = true;
            this.chkRunEltomScraping.Location = new System.Drawing.Point(1218, 96);
            this.chkRunEltomScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunEltomScraping.Name = "chkRunEltomScraping";
            this.chkRunEltomScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunEltomScraping.TabIndex = 13;
            this.chkRunEltomScraping.UseVisualStyleBackColor = true;
            // 
            // btnEltomFilePath
            // 
            this.btnEltomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEltomFilePath.Location = new System.Drawing.Point(1174, 89);
            this.btnEltomFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEltomFilePath.Name = "btnEltomFilePath";
            this.btnEltomFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnEltomFilePath.TabIndex = 12;
            this.btnEltomFilePath.UseVisualStyleBackColor = true;
            this.btnEltomFilePath.Click += new System.EventHandler(this.btnEltomFilePath_Click);
            // 
            // txtEltomFilePath
            // 
            this.txtEltomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEltomFilePath.Location = new System.Drawing.Point(168, 91);
            this.txtEltomFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEltomFilePath.Name = "txtEltomFilePath";
            this.txtEltomFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtEltomFilePath.TabIndex = 11;
            // 
            // lblEltomFilePath
            // 
            this.lblEltomFilePath.AutoSize = true;
            this.lblEltomFilePath.Location = new System.Drawing.Point(16, 95);
            this.lblEltomFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEltomFilePath.Name = "lblEltomFilePath";
            this.lblEltomFilePath.Size = new System.Drawing.Size(90, 16);
            this.lblEltomFilePath.TabIndex = 10;
            this.lblEltomFilePath.Text = "Eltom file path";
            // 
            // chkRunElkondScraping
            // 
            this.chkRunElkondScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunElkondScraping.AutoSize = true;
            this.chkRunElkondScraping.Location = new System.Drawing.Point(1218, 64);
            this.chkRunElkondScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunElkondScraping.Name = "chkRunElkondScraping";
            this.chkRunElkondScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunElkondScraping.TabIndex = 9;
            this.chkRunElkondScraping.UseVisualStyleBackColor = true;
            // 
            // btnElkondFilePath
            // 
            this.btnElkondFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElkondFilePath.Location = new System.Drawing.Point(1174, 57);
            this.btnElkondFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnElkondFilePath.Name = "btnElkondFilePath";
            this.btnElkondFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnElkondFilePath.TabIndex = 8;
            this.btnElkondFilePath.UseVisualStyleBackColor = true;
            this.btnElkondFilePath.Click += new System.EventHandler(this.btnElknodFilePath_Click);
            // 
            // txtElkondFilePath
            // 
            this.txtElkondFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElkondFilePath.Location = new System.Drawing.Point(168, 59);
            this.txtElkondFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtElkondFilePath.Name = "txtElkondFilePath";
            this.txtElkondFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtElkondFilePath.TabIndex = 7;
            // 
            // lblElkondFilePath
            // 
            this.lblElkondFilePath.AutoSize = true;
            this.lblElkondFilePath.Location = new System.Drawing.Point(16, 63);
            this.lblElkondFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblElkondFilePath.Name = "lblElkondFilePath";
            this.lblElkondFilePath.Size = new System.Drawing.Size(98, 16);
            this.lblElkondFilePath.TabIndex = 6;
            this.lblElkondFilePath.Text = "Elkond file path";
            // 
            // chkRunDekomScraping
            // 
            this.chkRunDekomScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunDekomScraping.AutoSize = true;
            this.chkRunDekomScraping.Location = new System.Drawing.Point(1218, 32);
            this.chkRunDekomScraping.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRunDekomScraping.Name = "chkRunDekomScraping";
            this.chkRunDekomScraping.Size = new System.Drawing.Size(18, 17);
            this.chkRunDekomScraping.TabIndex = 5;
            this.chkRunDekomScraping.UseVisualStyleBackColor = true;
            // 
            // btnDekomFilePath
            // 
            this.btnDekomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDekomFilePath.Location = new System.Drawing.Point(1174, 24);
            this.btnDekomFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDekomFilePath.Name = "btnDekomFilePath";
            this.btnDekomFilePath.Size = new System.Drawing.Size(33, 28);
            this.btnDekomFilePath.TabIndex = 4;
            this.btnDekomFilePath.UseVisualStyleBackColor = true;
            this.btnDekomFilePath.Click += new System.EventHandler(this.btnDekomFilePath_Click);
            // 
            // txtDekomFilePath
            // 
            this.txtDekomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDekomFilePath.Location = new System.Drawing.Point(168, 27);
            this.txtDekomFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDekomFilePath.Name = "txtDekomFilePath";
            this.txtDekomFilePath.Size = new System.Drawing.Size(993, 22);
            this.txtDekomFilePath.TabIndex = 3;
            // 
            // lblDekomlFilePath
            // 
            this.lblDekomlFilePath.AutoSize = true;
            this.lblDekomlFilePath.Location = new System.Drawing.Point(16, 31);
            this.lblDekomlFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDekomlFilePath.Name = "lblDekomlFilePath";
            this.lblDekomlFilePath.Size = new System.Drawing.Size(100, 16);
            this.lblDekomlFilePath.TabIndex = 1;
            this.lblDekomlFilePath.Text = "Dekom file path";
            // 
            // pnlOutputLog
            // 
            this.pnlOutputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutputLog.Controls.Add(this.gbLog);
            this.pnlOutputLog.Location = new System.Drawing.Point(0, 332);
            this.pnlOutputLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOutputLog.Name = "pnlOutputLog";
            this.pnlOutputLog.Size = new System.Drawing.Size(1241, 355);
            this.pnlOutputLog.TabIndex = 2;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.txtLog);
            this.gbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLog.Location = new System.Drawing.Point(0, 0);
            this.gbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLog.Name = "gbLog";
            this.gbLog.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbLog.Size = new System.Drawing.Size(1241, 355);
            this.gbLog.TabIndex = 0;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(4, 19);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1233, 332);
            this.txtLog.TabIndex = 0;
            // 
            // pnlRun
            // 
            this.pnlRun.Controls.Add(this.gbRun);
            this.pnlRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRun.Location = new System.Drawing.Point(0, 695);
            this.pnlRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlRun.Name = "pnlRun";
            this.pnlRun.Size = new System.Drawing.Size(1244, 64);
            this.pnlRun.TabIndex = 3;
            // 
            // gbRun
            // 
            this.gbRun.Controls.Add(this.btnRunWebScrapingProcess);
            this.gbRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRun.Location = new System.Drawing.Point(0, 0);
            this.gbRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRun.Name = "gbRun";
            this.gbRun.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRun.Size = new System.Drawing.Size(1244, 64);
            this.gbRun.TabIndex = 0;
            this.gbRun.TabStop = false;
            this.gbRun.Text = "Run";
            // 
            // btnRunWebScrapingProcess
            // 
            this.btnRunWebScrapingProcess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRunWebScrapingProcess.Location = new System.Drawing.Point(573, 23);
            this.btnRunWebScrapingProcess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRunWebScrapingProcess.Name = "btnRunWebScrapingProcess";
            this.btnRunWebScrapingProcess.Size = new System.Drawing.Size(100, 28);
            this.btnRunWebScrapingProcess.TabIndex = 7;
            this.btnRunWebScrapingProcess.Text = "Run";
            this.btnRunWebScrapingProcess.UseVisualStyleBackColor = true;
            this.btnRunWebScrapingProcess.Click += new System.EventHandler(this.btnRunWebScrapingProcess_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 759);
            this.Controls.Add(this.pnlRun);
            this.Controls.Add(this.pnlOutputLog);
            this.Controls.Add(this.pnlFile);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "Price Compare";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlFile.ResumeLayout(false);
            this.gbOutputDirectory.ResumeLayout(false);
            this.gbOutputDirectory.PerformLayout();
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.pnlOutputLog.ResumeLayout(false);
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.pnlRun.ResumeLayout(false);
            this.gbRun.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFile;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.Label lblDekomlFilePath;
        private System.Windows.Forms.CheckBox chkRunVrecoolScraping;
        private System.Windows.Forms.Button btnVrecoolFilePath;
        private System.Windows.Forms.TextBox txtVrecoolFilePath;
        private System.Windows.Forms.Label lblVrecoolFilePath;
        private System.Windows.Forms.CheckBox chkRunStatusFrigoScraping;
        private System.Windows.Forms.Button btnStatusFrigoFilePath;
        private System.Windows.Forms.TextBox txtStatusFrigoFilePath;
        private System.Windows.Forms.Label lblStatusFrigoFilePath;
        private System.Windows.Forms.CheckBox chkRunLorenScraping;
        private System.Windows.Forms.Button btnLorenFilePath;
        private System.Windows.Forms.TextBox txtLorenFilePath;
        private System.Windows.Forms.Label lblLorenFilePath;
        private System.Windows.Forms.CheckBox chkRunEltomScraping;
        private System.Windows.Forms.Button btnEltomFilePath;
        private System.Windows.Forms.TextBox txtEltomFilePath;
        private System.Windows.Forms.Label lblEltomFilePath;
        private System.Windows.Forms.CheckBox chkRunElkondScraping;
        private System.Windows.Forms.Button btnElkondFilePath;
        private System.Windows.Forms.TextBox txtElkondFilePath;
        private System.Windows.Forms.Label lblElkondFilePath;
        private System.Windows.Forms.CheckBox chkRunDekomScraping;
        private System.Windows.Forms.Button btnDekomFilePath;
        private System.Windows.Forms.TextBox txtDekomFilePath;
        private System.Windows.Forms.Button btnStelaxFilePath;
        private System.Windows.Forms.TextBox txtStelaxFilePath;
        private System.Windows.Forms.Label lblStelaxFilePath;
        private System.Windows.Forms.GroupBox gbOutputDirectory;
        private System.Windows.Forms.Button btnOutputDirectory;
        private System.Windows.Forms.TextBox txtOutputDirectoryPath;
        private System.Windows.Forms.Label lblOutputDirectory;
        private System.Windows.Forms.Panel pnlOutputLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel pnlRun;
        private System.Windows.Forms.GroupBox gbRun;
        private System.Windows.Forms.Button btnRunWebScrapingProcess;
    }
}

