﻿namespace PriceCompareApp.UI
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
            this.chkRunStelaxScraping = new System.Windows.Forms.CheckBox();
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
            this.chkRunElknodScraping = new System.Windows.Forms.CheckBox();
            this.btnElknodFilePath = new System.Windows.Forms.Button();
            this.txtElknodFilePath = new System.Windows.Forms.TextBox();
            this.lblElknodFilePath = new System.Windows.Forms.Label();
            this.chkRunDekomScraping = new System.Windows.Forms.CheckBox();
            this.btnDekomFilePath = new System.Windows.Forms.Button();
            this.txtDekomFilePath = new System.Windows.Forms.TextBox();
            this.lblDekomlFilePath = new System.Windows.Forms.Label();
            this.pnlOutputLog = new System.Windows.Forms.Panel();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbRun = new System.Windows.Forms.GroupBox();
            this.btnRunWebScrapingProcess = new System.Windows.Forms.Button();
            this.pnlFile.SuspendLayout();
            this.gbOutputDirectory.SuspendLayout();
            this.gbFiles.SuspendLayout();
            this.pnlOutputLog.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(747, 270);
            this.pnlFile.TabIndex = 0;
            // 
            // gbOutputDirectory
            // 
            this.gbOutputDirectory.Controls.Add(this.btnOutputDirectory);
            this.gbOutputDirectory.Controls.Add(this.txtOutputDirectoryPath);
            this.gbOutputDirectory.Controls.Add(this.lblOutputDirectory);
            this.gbOutputDirectory.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOutputDirectory.Location = new System.Drawing.Point(0, 207);
            this.gbOutputDirectory.Name = "gbOutputDirectory";
            this.gbOutputDirectory.Size = new System.Drawing.Size(747, 63);
            this.gbOutputDirectory.TabIndex = 0;
            this.gbOutputDirectory.TabStop = false;
            this.gbOutputDirectory.Text = "Output directory";
            // 
            // btnOutputDirectory
            // 
            this.btnOutputDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputDirectory.Location = new System.Drawing.Point(692, 20);
            this.btnOutputDirectory.Name = "btnOutputDirectory";
            this.btnOutputDirectory.Size = new System.Drawing.Size(25, 23);
            this.btnOutputDirectory.TabIndex = 31;
            this.btnOutputDirectory.UseVisualStyleBackColor = true;
            this.btnOutputDirectory.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // txtOutputDirectoryPath
            // 
            this.txtOutputDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDirectoryPath.Location = new System.Drawing.Point(123, 22);
            this.txtOutputDirectoryPath.Name = "txtOutputDirectoryPath";
            this.txtOutputDirectoryPath.Size = new System.Drawing.Size(560, 20);
            this.txtOutputDirectoryPath.TabIndex = 30;
            // 
            // lblOutputDirectory
            // 
            this.lblOutputDirectory.AutoSize = true;
            this.lblOutputDirectory.Location = new System.Drawing.Point(9, 25);
            this.lblOutputDirectory.Name = "lblOutputDirectory";
            this.lblOutputDirectory.Size = new System.Drawing.Size(68, 13);
            this.lblOutputDirectory.TabIndex = 29;
            this.lblOutputDirectory.Text = "Save files to ";
            // 
            // gbFiles
            // 
            this.gbFiles.Controls.Add(this.chkRunStelaxScraping);
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
            this.gbFiles.Controls.Add(this.chkRunElknodScraping);
            this.gbFiles.Controls.Add(this.btnElknodFilePath);
            this.gbFiles.Controls.Add(this.txtElknodFilePath);
            this.gbFiles.Controls.Add(this.lblElknodFilePath);
            this.gbFiles.Controls.Add(this.chkRunDekomScraping);
            this.gbFiles.Controls.Add(this.btnDekomFilePath);
            this.gbFiles.Controls.Add(this.txtDekomFilePath);
            this.gbFiles.Controls.Add(this.lblDekomlFilePath);
            this.gbFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiles.Location = new System.Drawing.Point(0, 0);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Size = new System.Drawing.Size(747, 207);
            this.gbFiles.TabIndex = 0;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Files";
            // 
            // chkRunStelaxScraping
            // 
            this.chkRunStelaxScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunStelaxScraping.AutoSize = true;
            this.chkRunStelaxScraping.Location = new System.Drawing.Point(726, 181);
            this.chkRunStelaxScraping.Name = "chkRunStelaxScraping";
            this.chkRunStelaxScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunStelaxScraping.TabIndex = 29;
            this.chkRunStelaxScraping.UseVisualStyleBackColor = true;
            // 
            // btnStelaxFilePath
            // 
            this.btnStelaxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStelaxFilePath.Location = new System.Drawing.Point(695, 176);
            this.btnStelaxFilePath.Name = "btnStelaxFilePath";
            this.btnStelaxFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnStelaxFilePath.TabIndex = 28;
            this.btnStelaxFilePath.UseVisualStyleBackColor = true;
            this.btnStelaxFilePath.Click += new System.EventHandler(this.btnStelaxFilePath_Click);
            // 
            // txtStelaxFilePath
            // 
            this.txtStelaxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStelaxFilePath.Location = new System.Drawing.Point(126, 178);
            this.txtStelaxFilePath.Name = "txtStelaxFilePath";
            this.txtStelaxFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtStelaxFilePath.TabIndex = 27;
            // 
            // lblStelaxFilePath
            // 
            this.lblStelaxFilePath.AutoSize = true;
            this.lblStelaxFilePath.Location = new System.Drawing.Point(12, 181);
            this.lblStelaxFilePath.Name = "lblStelaxFilePath";
            this.lblStelaxFilePath.Size = new System.Drawing.Size(76, 13);
            this.lblStelaxFilePath.TabIndex = 26;
            this.lblStelaxFilePath.Text = "Stelax file path";
            // 
            // chkRunVrecoolScraping
            // 
            this.chkRunVrecoolScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunVrecoolScraping.AutoSize = true;
            this.chkRunVrecoolScraping.Location = new System.Drawing.Point(726, 155);
            this.chkRunVrecoolScraping.Name = "chkRunVrecoolScraping";
            this.chkRunVrecoolScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunVrecoolScraping.TabIndex = 25;
            this.chkRunVrecoolScraping.UseVisualStyleBackColor = true;
            // 
            // btnVrecoolFilePath
            // 
            this.btnVrecoolFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVrecoolFilePath.Location = new System.Drawing.Point(695, 150);
            this.btnVrecoolFilePath.Name = "btnVrecoolFilePath";
            this.btnVrecoolFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnVrecoolFilePath.TabIndex = 24;
            this.btnVrecoolFilePath.UseVisualStyleBackColor = true;
            this.btnVrecoolFilePath.Click += new System.EventHandler(this.btnVrecoolFilePath_Click);
            // 
            // txtVrecoolFilePath
            // 
            this.txtVrecoolFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVrecoolFilePath.Location = new System.Drawing.Point(126, 152);
            this.txtVrecoolFilePath.Name = "txtVrecoolFilePath";
            this.txtVrecoolFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtVrecoolFilePath.TabIndex = 23;
            // 
            // lblVrecoolFilePath
            // 
            this.lblVrecoolFilePath.AutoSize = true;
            this.lblVrecoolFilePath.Location = new System.Drawing.Point(12, 155);
            this.lblVrecoolFilePath.Name = "lblVrecoolFilePath";
            this.lblVrecoolFilePath.Size = new System.Drawing.Size(83, 13);
            this.lblVrecoolFilePath.TabIndex = 22;
            this.lblVrecoolFilePath.Text = "Vrecool file path";
            // 
            // chkRunStatusFrigoScraping
            // 
            this.chkRunStatusFrigoScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunStatusFrigoScraping.AutoSize = true;
            this.chkRunStatusFrigoScraping.Location = new System.Drawing.Point(726, 129);
            this.chkRunStatusFrigoScraping.Name = "chkRunStatusFrigoScraping";
            this.chkRunStatusFrigoScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunStatusFrigoScraping.TabIndex = 21;
            this.chkRunStatusFrigoScraping.UseVisualStyleBackColor = true;
            // 
            // btnStatusFrigoFilePath
            // 
            this.btnStatusFrigoFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusFrigoFilePath.Location = new System.Drawing.Point(695, 124);
            this.btnStatusFrigoFilePath.Name = "btnStatusFrigoFilePath";
            this.btnStatusFrigoFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnStatusFrigoFilePath.TabIndex = 20;
            this.btnStatusFrigoFilePath.UseVisualStyleBackColor = true;
            this.btnStatusFrigoFilePath.Click += new System.EventHandler(this.btnStatusFrigoFilePath_Click);
            // 
            // txtStatusFrigoFilePath
            // 
            this.txtStatusFrigoFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStatusFrigoFilePath.Location = new System.Drawing.Point(126, 126);
            this.txtStatusFrigoFilePath.Name = "txtStatusFrigoFilePath";
            this.txtStatusFrigoFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtStatusFrigoFilePath.TabIndex = 19;
            // 
            // lblStatusFrigoFilePath
            // 
            this.lblStatusFrigoFilePath.AutoSize = true;
            this.lblStatusFrigoFilePath.Location = new System.Drawing.Point(12, 129);
            this.lblStatusFrigoFilePath.Name = "lblStatusFrigoFilePath";
            this.lblStatusFrigoFilePath.Size = new System.Drawing.Size(100, 13);
            this.lblStatusFrigoFilePath.TabIndex = 18;
            this.lblStatusFrigoFilePath.Text = "StatusFrigo file path";
            // 
            // chkRunLorenScraping
            // 
            this.chkRunLorenScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunLorenScraping.AutoSize = true;
            this.chkRunLorenScraping.Location = new System.Drawing.Point(726, 103);
            this.chkRunLorenScraping.Name = "chkRunLorenScraping";
            this.chkRunLorenScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunLorenScraping.TabIndex = 17;
            this.chkRunLorenScraping.UseVisualStyleBackColor = true;
            // 
            // btnLorenFilePath
            // 
            this.btnLorenFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLorenFilePath.Location = new System.Drawing.Point(695, 98);
            this.btnLorenFilePath.Name = "btnLorenFilePath";
            this.btnLorenFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnLorenFilePath.TabIndex = 16;
            this.btnLorenFilePath.UseVisualStyleBackColor = true;
            this.btnLorenFilePath.Click += new System.EventHandler(this.btnLorenFilePath_Click);
            // 
            // txtLorenFilePath
            // 
            this.txtLorenFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLorenFilePath.Location = new System.Drawing.Point(126, 100);
            this.txtLorenFilePath.Name = "txtLorenFilePath";
            this.txtLorenFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtLorenFilePath.TabIndex = 15;
            // 
            // lblLorenFilePath
            // 
            this.lblLorenFilePath.AutoSize = true;
            this.lblLorenFilePath.Location = new System.Drawing.Point(12, 103);
            this.lblLorenFilePath.Name = "lblLorenFilePath";
            this.lblLorenFilePath.Size = new System.Drawing.Size(74, 13);
            this.lblLorenFilePath.TabIndex = 14;
            this.lblLorenFilePath.Text = "Loren file path";
            // 
            // chkRunEltomScraping
            // 
            this.chkRunEltomScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunEltomScraping.AutoSize = true;
            this.chkRunEltomScraping.Location = new System.Drawing.Point(726, 77);
            this.chkRunEltomScraping.Name = "chkRunEltomScraping";
            this.chkRunEltomScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunEltomScraping.TabIndex = 13;
            this.chkRunEltomScraping.UseVisualStyleBackColor = true;
            // 
            // btnEltomFilePath
            // 
            this.btnEltomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEltomFilePath.Location = new System.Drawing.Point(695, 72);
            this.btnEltomFilePath.Name = "btnEltomFilePath";
            this.btnEltomFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnEltomFilePath.TabIndex = 12;
            this.btnEltomFilePath.UseVisualStyleBackColor = true;
            this.btnEltomFilePath.Click += new System.EventHandler(this.btnEltomFilePath_Click);
            // 
            // txtEltomFilePath
            // 
            this.txtEltomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEltomFilePath.Location = new System.Drawing.Point(126, 74);
            this.txtEltomFilePath.Name = "txtEltomFilePath";
            this.txtEltomFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtEltomFilePath.TabIndex = 11;
            // 
            // lblEltomFilePath
            // 
            this.lblEltomFilePath.AutoSize = true;
            this.lblEltomFilePath.Location = new System.Drawing.Point(12, 77);
            this.lblEltomFilePath.Name = "lblEltomFilePath";
            this.lblEltomFilePath.Size = new System.Drawing.Size(73, 13);
            this.lblEltomFilePath.TabIndex = 10;
            this.lblEltomFilePath.Text = "Eltom file path";
            // 
            // chkRunElknodScraping
            // 
            this.chkRunElknodScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunElknodScraping.AutoSize = true;
            this.chkRunElknodScraping.Location = new System.Drawing.Point(726, 51);
            this.chkRunElknodScraping.Name = "chkRunElknodScraping";
            this.chkRunElknodScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunElknodScraping.TabIndex = 9;
            this.chkRunElknodScraping.UseVisualStyleBackColor = true;
            // 
            // btnElknodFilePath
            // 
            this.btnElknodFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElknodFilePath.Location = new System.Drawing.Point(695, 46);
            this.btnElknodFilePath.Name = "btnElknodFilePath";
            this.btnElknodFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnElknodFilePath.TabIndex = 8;
            this.btnElknodFilePath.UseVisualStyleBackColor = true;
            this.btnElknodFilePath.Click += new System.EventHandler(this.btnElknodFilePath_Click);
            // 
            // txtElknodFilePath
            // 
            this.txtElknodFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtElknodFilePath.Location = new System.Drawing.Point(126, 48);
            this.txtElknodFilePath.Name = "txtElknodFilePath";
            this.txtElknodFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtElknodFilePath.TabIndex = 7;
            // 
            // lblElknodFilePath
            // 
            this.lblElknodFilePath.AutoSize = true;
            this.lblElknodFilePath.Location = new System.Drawing.Point(12, 51);
            this.lblElknodFilePath.Name = "lblElknodFilePath";
            this.lblElknodFilePath.Size = new System.Drawing.Size(80, 13);
            this.lblElknodFilePath.TabIndex = 6;
            this.lblElknodFilePath.Text = "Elknod file path";
            // 
            // chkRunDekomScraping
            // 
            this.chkRunDekomScraping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRunDekomScraping.AutoSize = true;
            this.chkRunDekomScraping.Location = new System.Drawing.Point(726, 25);
            this.chkRunDekomScraping.Name = "chkRunDekomScraping";
            this.chkRunDekomScraping.Size = new System.Drawing.Size(15, 14);
            this.chkRunDekomScraping.TabIndex = 5;
            this.chkRunDekomScraping.UseVisualStyleBackColor = true;
            // 
            // btnDekomFilePath
            // 
            this.btnDekomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDekomFilePath.Location = new System.Drawing.Point(695, 20);
            this.btnDekomFilePath.Name = "btnDekomFilePath";
            this.btnDekomFilePath.Size = new System.Drawing.Size(25, 23);
            this.btnDekomFilePath.TabIndex = 4;
            this.btnDekomFilePath.UseVisualStyleBackColor = true;
            this.btnDekomFilePath.Click += new System.EventHandler(this.btnDekomFilePath_Click);
            // 
            // txtDekomFilePath
            // 
            this.txtDekomFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDekomFilePath.Location = new System.Drawing.Point(126, 22);
            this.txtDekomFilePath.Name = "txtDekomFilePath";
            this.txtDekomFilePath.Size = new System.Drawing.Size(560, 20);
            this.txtDekomFilePath.TabIndex = 3;
            // 
            // lblDekomlFilePath
            // 
            this.lblDekomlFilePath.AutoSize = true;
            this.lblDekomlFilePath.Location = new System.Drawing.Point(12, 25);
            this.lblDekomlFilePath.Name = "lblDekomlFilePath";
            this.lblDekomlFilePath.Size = new System.Drawing.Size(81, 13);
            this.lblDekomlFilePath.TabIndex = 1;
            this.lblDekomlFilePath.Text = "Dekom file path";
            // 
            // pnlOutputLog
            // 
            this.pnlOutputLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOutputLog.Controls.Add(this.gbLog);
            this.pnlOutputLog.Location = new System.Drawing.Point(0, 270);
            this.pnlOutputLog.Name = "pnlOutputLog";
            this.pnlOutputLog.Size = new System.Drawing.Size(747, 152);
            this.pnlOutputLog.TabIndex = 2;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.txtLog);
            this.gbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLog.Location = new System.Drawing.Point(0, 0);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(747, 152);
            this.gbLog.TabIndex = 0;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(741, 133);
            this.txtLog.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 65);
            this.panel1.TabIndex = 3;
            // 
            // gbRun
            // 
            this.gbRun.Controls.Add(this.btnRunWebScrapingProcess);
            this.gbRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRun.Location = new System.Drawing.Point(0, 0);
            this.gbRun.Name = "gbRun";
            this.gbRun.Size = new System.Drawing.Size(747, 65);
            this.gbRun.TabIndex = 0;
            this.gbRun.TabStop = false;
            this.gbRun.Text = "Run";
            // 
            // btnRunWebScrapingProcess
            // 
            this.btnRunWebScrapingProcess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRunWebScrapingProcess.Location = new System.Drawing.Point(336, 30);
            this.btnRunWebScrapingProcess.Name = "btnRunWebScrapingProcess";
            this.btnRunWebScrapingProcess.Size = new System.Drawing.Size(75, 23);
            this.btnRunWebScrapingProcess.TabIndex = 7;
            this.btnRunWebScrapingProcess.Text = "Run";
            this.btnRunWebScrapingProcess.UseVisualStyleBackColor = true;
            this.btnRunWebScrapingProcess.Click += new System.EventHandler(this.btnRunWebScrapingProcess_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 494);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlOutputLog);
            this.Controls.Add(this.pnlFile);
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
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox chkRunElknodScraping;
        private System.Windows.Forms.Button btnElknodFilePath;
        private System.Windows.Forms.TextBox txtElknodFilePath;
        private System.Windows.Forms.Label lblElknodFilePath;
        private System.Windows.Forms.CheckBox chkRunDekomScraping;
        private System.Windows.Forms.Button btnDekomFilePath;
        private System.Windows.Forms.TextBox txtDekomFilePath;
        private System.Windows.Forms.CheckBox chkRunStelaxScraping;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbRun;
        private System.Windows.Forms.Button btnRunWebScrapingProcess;
    }
}

