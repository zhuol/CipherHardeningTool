using System.Windows.Forms;

namespace CipherHardeningTool
{
    partial class CipherHardeningTool
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
            this.groupProtocolsEnabled = new System.Windows.Forms.GroupBox();
            this.checkedListProtocolsEnabled = new System.Windows.Forms.CheckedListBox();
            this.groupCiphersEnabled = new System.Windows.Forms.GroupBox();
            this.checkedListCipherEnabled = new System.Windows.Forms.CheckedListBox();
            this.groupHashesEnabled = new System.Windows.Forms.GroupBox();
            this.checkedListHashesEnabled = new System.Windows.Forms.CheckedListBox();
            this.groupKeyExchangesEnabled = new System.Windows.Forms.GroupBox();
            this.checkedListKeyExchangesEnabled = new System.Windows.Forms.CheckedListBox();
            this.groupSSLCipherSuiteOrder = new System.Windows.Forms.GroupBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.MoveItemDown = new System.Windows.Forms.Button();
            this.MoveItemUp = new System.Windows.Forms.Button();
            this.checkedListSSLCipherSuiteOrder = new System.Windows.Forms.CheckedListBox();
            this.checkedListSSLCipherSuiteOrderForDisable = new System.Windows.Forms.CheckedListBox();
            this.groupSSLScan = new System.Windows.Forms.GroupBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.SSLScan = new System.Windows.Forms.Button();
            this.labelUrl = new System.Windows.Forms.Label();
            this.urlForSSLScan = new System.Windows.Forms.TextBox();
            this.labelPoweredBy = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.menuStripWeakCipherTool = new System.Windows.Forms.MenuStrip();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestPracticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Run = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkAbout = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.groupProtocolsEnabled.SuspendLayout();
            this.groupCiphersEnabled.SuspendLayout();
            this.groupHashesEnabled.SuspendLayout();
            this.groupKeyExchangesEnabled.SuspendLayout();
            this.groupSSLCipherSuiteOrder.SuspendLayout();
            this.groupSSLScan.SuspendLayout();
            this.menuStripWeakCipherTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupProtocolsEnabled
            // 
            this.groupProtocolsEnabled.Controls.Add(this.checkedListProtocolsEnabled);
            this.groupProtocolsEnabled.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupProtocolsEnabled.Location = new System.Drawing.Point(560, 48);
            this.groupProtocolsEnabled.Name = "groupProtocolsEnabled";
            this.groupProtocolsEnabled.Size = new System.Drawing.Size(260, 268);
            this.groupProtocolsEnabled.TabIndex = 0;
            this.groupProtocolsEnabled.TabStop = false;
            this.groupProtocolsEnabled.Text = "Protocols Enabled";
            // 
            // checkedListProtocolsEnabled
            // 
            this.checkedListProtocolsEnabled.CheckOnClick = true;
            this.checkedListProtocolsEnabled.FormattingEnabled = true;
            this.checkedListProtocolsEnabled.Items.AddRange(new object[] {
            "SSL 2.0",
            "SSL 3.0",
            "TLS 1.0",
            "TLS 1.1",
            "TLS 1.2"});
            this.checkedListProtocolsEnabled.Location = new System.Drawing.Point(20, 20);
            this.checkedListProtocolsEnabled.Name = "checkedListProtocolsEnabled";
            this.checkedListProtocolsEnabled.Size = new System.Drawing.Size(224, 225);
            this.checkedListProtocolsEnabled.TabIndex = 0;
            this.checkedListProtocolsEnabled.SelectedIndexChanged += new System.EventHandler(this.CheckedListProtocolsEnabledSelectedIndexChanged);
            // 
            // groupCiphersEnabled
            // 
            this.groupCiphersEnabled.Controls.Add(this.checkedListCipherEnabled);
            this.groupCiphersEnabled.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupCiphersEnabled.Location = new System.Drawing.Point(847, 48);
            this.groupCiphersEnabled.Name = "groupCiphersEnabled";
            this.groupCiphersEnabled.Size = new System.Drawing.Size(260, 268);
            this.groupCiphersEnabled.TabIndex = 1;
            this.groupCiphersEnabled.TabStop = false;
            this.groupCiphersEnabled.Text = "Ciphers Enabled";
            // 
            // checkedListCipherEnabled
            // 
            this.checkedListCipherEnabled.CheckOnClick = true;
            this.checkedListCipherEnabled.FormattingEnabled = true;
            this.checkedListCipherEnabled.Items.AddRange(new object[] {
            "NULL",
            "DES 56/56",
            "RC2 40/128",
            "RC2 56/128",
            "RC2 128/128",
            "RC4 40/128",
            "RC4 56/128",
            "RC4 64/128",
            "RC4 128/128",
            "Triple DES 168/168",
            "AES 128/128",
            "AES 256/256"});
            this.checkedListCipherEnabled.Location = new System.Drawing.Point(20, 20);
            this.checkedListCipherEnabled.Name = "checkedListCipherEnabled";
            this.checkedListCipherEnabled.Size = new System.Drawing.Size(224, 225);
            this.checkedListCipherEnabled.TabIndex = 0;
            this.checkedListCipherEnabled.SelectedIndexChanged += new System.EventHandler(this.CheckedListCipherEnabledSelectedIndexChanged);
            // 
            // groupHashesEnabled
            // 
            this.groupHashesEnabled.Controls.Add(this.checkedListHashesEnabled);
            this.groupHashesEnabled.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupHashesEnabled.Location = new System.Drawing.Point(560, 334);
            this.groupHashesEnabled.Name = "groupHashesEnabled";
            this.groupHashesEnabled.Size = new System.Drawing.Size(260, 182);
            this.groupHashesEnabled.TabIndex = 2;
            this.groupHashesEnabled.TabStop = false;
            this.groupHashesEnabled.Text = "Hashes Enabled";
            // 
            // checkedListHashesEnabled
            // 
            this.checkedListHashesEnabled.CheckOnClick = true;
            this.checkedListHashesEnabled.FormattingEnabled = true;
            this.checkedListHashesEnabled.Items.AddRange(new object[] {
            "MD5",
            "SHA"});
            this.checkedListHashesEnabled.Location = new System.Drawing.Point(20, 20);
            this.checkedListHashesEnabled.Name = "checkedListHashesEnabled";
            this.checkedListHashesEnabled.Size = new System.Drawing.Size(224, 140);
            this.checkedListHashesEnabled.TabIndex = 0;
            this.checkedListHashesEnabled.SelectedIndexChanged += new System.EventHandler(this.CheckedListHashesEnabledSelectedIndexChanged);
            // 
            // groupKeyExchangesEnabled
            // 
            this.groupKeyExchangesEnabled.Controls.Add(this.checkedListKeyExchangesEnabled);
            this.groupKeyExchangesEnabled.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupKeyExchangesEnabled.Location = new System.Drawing.Point(847, 334);
            this.groupKeyExchangesEnabled.Name = "groupKeyExchangesEnabled";
            this.groupKeyExchangesEnabled.Size = new System.Drawing.Size(260, 182);
            this.groupKeyExchangesEnabled.TabIndex = 3;
            this.groupKeyExchangesEnabled.TabStop = false;
            this.groupKeyExchangesEnabled.Text = "Key Exchanges Enabled";
            // 
            // checkedListKeyExchangesEnabled
            // 
            this.checkedListKeyExchangesEnabled.CheckOnClick = true;
            this.checkedListKeyExchangesEnabled.FormattingEnabled = true;
            this.checkedListKeyExchangesEnabled.Items.AddRange(new object[] {
            "Diffle-Hellman",
            "PKCS",
            "SRP",
            "PSK",
            "CAMELLIA"});
            this.checkedListKeyExchangesEnabled.Location = new System.Drawing.Point(20, 20);
            this.checkedListKeyExchangesEnabled.Name = "checkedListKeyExchangesEnabled";
            this.checkedListKeyExchangesEnabled.Size = new System.Drawing.Size(224, 140);
            this.checkedListKeyExchangesEnabled.TabIndex = 0;
            this.checkedListKeyExchangesEnabled.SelectedIndexChanged += new System.EventHandler(this.CheckedListKeyExchangesEnabledSelectedIndexChanged);
            // 
            // groupSSLCipherSuiteOrder
            // 
            this.groupSSLCipherSuiteOrder.Controls.Add(this.buttonClearAll);
            this.groupSSLCipherSuiteOrder.Controls.Add(this.buttonSelectAll);
            this.groupSSLCipherSuiteOrder.Controls.Add(this.MoveItemDown);
            this.groupSSLCipherSuiteOrder.Controls.Add(this.MoveItemUp);
            this.groupSSLCipherSuiteOrder.Controls.Add(this.checkedListSSLCipherSuiteOrder);
            this.groupSSLCipherSuiteOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupSSLCipherSuiteOrder.Location = new System.Drawing.Point(26, 48);
            this.groupSSLCipherSuiteOrder.Name = "groupSSLCipherSuiteOrder";
            this.groupSSLCipherSuiteOrder.Size = new System.Drawing.Size(509, 535);
            this.groupSSLCipherSuiteOrder.TabIndex = 4;
            this.groupSSLCipherSuiteOrder.TabStop = false;
            this.groupSSLCipherSuiteOrder.Text = "SSL Cipher Suite Order";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonClearAll.Location = new System.Drawing.Point(433, 437);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(70, 54);
            this.buttonClearAll.TabIndex = 4;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.ButtonClearAllClick);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSelectAll.Location = new System.Drawing.Point(433, 377);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(70, 54);
            this.buttonSelectAll.TabIndex = 3;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.ButtonSelectAllClick);
            // 
            // MoveItemDown
            // 
            this.MoveItemDown.Image = global::CipherHardeningTool.Properties.Resources.Untitled2;
            this.MoveItemDown.Location = new System.Drawing.Point(443, 277);
            this.MoveItemDown.Name = "MoveItemDown";
            this.MoveItemDown.Size = new System.Drawing.Size(45, 45);
            this.MoveItemDown.TabIndex = 2;
            this.MoveItemDown.UseVisualStyleBackColor = true;
            this.MoveItemDown.Click += new System.EventHandler(this.MoveItemDownClick);
            // 
            // MoveItemUp
            // 
            this.MoveItemUp.Image = global::CipherHardeningTool.Properties.Resources.Untitled;
            this.MoveItemUp.Location = new System.Drawing.Point(443, 213);
            this.MoveItemUp.Name = "MoveItemUp";
            this.MoveItemUp.Size = new System.Drawing.Size(45, 45);
            this.MoveItemUp.TabIndex = 1;
            this.MoveItemUp.TabStop = false;
            this.MoveItemUp.UseVisualStyleBackColor = true;
            this.MoveItemUp.Click += new System.EventHandler(this.MoveItemUpClick);
            // 
            // checkedListSSLCipherSuiteOrder
            // 
            this.checkedListSSLCipherSuiteOrder.CheckOnClick = true;
            this.checkedListSSLCipherSuiteOrder.FormattingEnabled = true;
            this.checkedListSSLCipherSuiteOrder.Location = new System.Drawing.Point(20, 22);
            this.checkedListSSLCipherSuiteOrder.Name = "checkedListSSLCipherSuiteOrder";
            this.checkedListSSLCipherSuiteOrder.Size = new System.Drawing.Size(407, 497);
            this.checkedListSSLCipherSuiteOrder.TabIndex = 0;
            this.checkedListSSLCipherSuiteOrder.SelectedIndexChanged += new System.EventHandler(this.CheckedListSslCipherSuiteOrderSelectedIndexChanged);
            // 
            // checkedListSSLCipherSuiteOrderForDisable
            // 
            this.checkedListSSLCipherSuiteOrderForDisable.Location = new System.Drawing.Point(0, 0);
            this.checkedListSSLCipherSuiteOrderForDisable.Name = "checkedListSSLCipherSuiteOrderForDisable";
            this.checkedListSSLCipherSuiteOrderForDisable.Size = new System.Drawing.Size(120, 89);
            this.checkedListSSLCipherSuiteOrderForDisable.TabIndex = 0;
            // 
            // groupSSLScan
            // 
            this.groupSSLScan.Controls.Add(this.textBoxFilter);
            this.groupSSLScan.Controls.Add(this.labelFilter);
            this.groupSSLScan.Controls.Add(this.labelPort);
            this.groupSSLScan.Controls.Add(this.textBoxPort);
            this.groupSSLScan.Controls.Add(this.SSLScan);
            this.groupSSLScan.Controls.Add(this.labelUrl);
            this.groupSSLScan.Controls.Add(this.urlForSSLScan);
            this.groupSSLScan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupSSLScan.Location = new System.Drawing.Point(560, 522);
            this.groupSSLScan.Name = "groupSSLScan";
            this.groupSSLScan.Size = new System.Drawing.Size(547, 61);
            this.groupSSLScan.TabIndex = 6;
            this.groupSSLScan.TabStop = false;
            this.groupSSLScan.Text = "SSL Scan";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(393, 24);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(84, 22);
            this.textBoxFilter.TabIndex = 7;
            this.textBoxFilter.TabStop = false;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(348, 27);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(39, 17);
            this.labelFilter.TabIndex = 6;
            this.labelFilter.Text = "Filter";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(265, 27);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 5;
            this.labelPort.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(305, 24);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(37, 22);
            this.textBoxPort.TabIndex = 4;
            // 
            // SSLScan
            // 
            this.SSLScan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SSLScan.Location = new System.Drawing.Point(482, 22);
            this.SSLScan.Name = "SSLScan";
            this.SSLScan.Size = new System.Drawing.Size(48, 26);
            this.SSLScan.TabIndex = 3;
            this.SSLScan.Text = "Scan";
            this.SSLScan.UseVisualStyleBackColor = true;
            this.SSLScan.Click += new System.EventHandler(this.SslScanClick);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(20, 27);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(26, 17);
            this.labelUrl.TabIndex = 2;
            this.labelUrl.Text = "Url";
            // 
            // urlForSSLScan
            // 
            this.urlForSSLScan.Location = new System.Drawing.Point(52, 24);
            this.urlForSSLScan.Name = "urlForSSLScan";
            this.urlForSSLScan.Size = new System.Drawing.Size(207, 22);
            this.urlForSSLScan.TabIndex = 1;
            // 
            // labelPoweredBy
            // 
            this.labelPoweredBy.AutoSize = true;
            this.labelPoweredBy.Location = new System.Drawing.Point(23, 608);
            this.labelPoweredBy.Name = "labelPoweredBy";
            this.labelPoweredBy.Size = new System.Drawing.Size(82, 17);
            this.labelPoweredBy.TabIndex = 9;
            this.labelPoweredBy.Text = "Powered by";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(324, 608);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(129, 17);
            this.labelCopyright.TabIndex = 11;
            this.labelCopyright.Text = "Copyright@ 2013 | ";
            // 
            // menuStripWeakCipherTool
            // 
            this.menuStripWeakCipherTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStripWeakCipherTool.Location = new System.Drawing.Point(0, 0);
            this.menuStripWeakCipherTool.Name = "menuStripWeakCipherTool";
            this.menuStripWeakCipherTool.Size = new System.Drawing.Size(1133, 28);
            this.menuStripWeakCipherTool.TabIndex = 13;
            this.menuStripWeakCipherTool.Text = "menuStripWeakCipherTool";
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestPracticesToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.templateToolStripMenuItem.Text = "Template";
            // 
            // bestPracticesToolStripMenuItem
            // 
            this.bestPracticesToolStripMenuItem.Name = "bestPracticesToolStripMenuItem";
            this.bestPracticesToolStripMenuItem.Size = new System.Drawing.Size(257, 24);
            this.bestPracticesToolStripMenuItem.Text = "Recommend Configuration";
            this.bestPracticesToolStripMenuItem.Click += new System.EventHandler(this.BestPracticesToolStripMenuItemClick);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(257, 24);
            this.customerToolStripMenuItem.Text = "Customer Configuration";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.CustomerToolStripMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpDocumentToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // helpDocumentToolStripMenuItem
            // 
            this.helpDocumentToolStripMenuItem.Name = "helpDocumentToolStripMenuItem";
            this.helpDocumentToolStripMenuItem.Size = new System.Drawing.Size(223, 24);
            this.helpDocumentToolStripMenuItem.Text = "Open Help Document";
            this.helpDocumentToolStripMenuItem.Click += new System.EventHandler(this.HelpDocumentToolStripMenuItemClick);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(223, 24);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.AboutToolStripMenuItem1Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(1025, 598);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(82, 37);
            this.Run.TabIndex = 14;
            this.Run.Text = "Apply";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.RunClick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(459, 608);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(48, 17);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "2hu01";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkAbout
            // 
            this.linkAbout.AutoSize = true;
            this.linkAbout.Location = new System.Drawing.Point(111, 608);
            this.linkAbout.Name = "linkAbout";
            this.linkAbout.Size = new System.Drawing.Size(48, 17);
            this.linkAbout.TabIndex = 16;
            this.linkAbout.TabStop = true;
            this.linkAbout.Text = "2hu01";
            this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(560, 608);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(242, 17);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Email Me:zhuozhuozhuol@gmail.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // CipherHardeningTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(163)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1133, 644);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkAbout);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelPoweredBy);
            this.Controls.Add(this.groupSSLScan);
            this.Controls.Add(this.groupSSLCipherSuiteOrder);
            this.Controls.Add(this.groupKeyExchangesEnabled);
            this.Controls.Add(this.groupHashesEnabled);
            this.Controls.Add(this.groupCiphersEnabled);
            this.Controls.Add(this.groupProtocolsEnabled);
            this.Controls.Add(this.menuStripWeakCipherTool);
            this.MainMenuStrip = this.menuStripWeakCipherTool;
            this.Name = "CipherHardeningTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CipherHardeningTool";
            this.Load += new System.EventHandler(this.WeakCipherToolLoad);
            this.groupProtocolsEnabled.ResumeLayout(false);
            this.groupCiphersEnabled.ResumeLayout(false);
            this.groupHashesEnabled.ResumeLayout(false);
            this.groupKeyExchangesEnabled.ResumeLayout(false);
            this.groupSSLCipherSuiteOrder.ResumeLayout(false);
            this.groupSSLScan.ResumeLayout(false);
            this.groupSSLScan.PerformLayout();
            this.menuStripWeakCipherTool.ResumeLayout(false);
            this.menuStripWeakCipherTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupProtocolsEnabled;
        private System.Windows.Forms.CheckedListBox checkedListProtocolsEnabled;
        private System.Windows.Forms.GroupBox groupCiphersEnabled;
        private System.Windows.Forms.CheckedListBox checkedListCipherEnabled;
        private System.Windows.Forms.GroupBox groupHashesEnabled;
        private System.Windows.Forms.CheckedListBox checkedListHashesEnabled;
        private System.Windows.Forms.GroupBox groupKeyExchangesEnabled;
        private System.Windows.Forms.CheckedListBox checkedListKeyExchangesEnabled;
        private System.Windows.Forms.GroupBox groupSSLCipherSuiteOrder;
        private System.Windows.Forms.CheckedListBox checkedListSSLCipherSuiteOrder;
        private System.Windows.Forms.CheckedListBox checkedListSSLCipherSuiteOrderForDisable;
        private System.Windows.Forms.GroupBox groupSSLScan;
        private System.Windows.Forms.Button SSLScan;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox urlForSSLScan;
        private System.Windows.Forms.Label labelPoweredBy;
        private System.Windows.Forms.Button MoveItemDown;
        private System.Windows.Forms.Button MoveItemUp;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;

        // Cipher Suites of SSL
        private readonly string[] SSLCipherSuite = new string[] { "SSL_RSA_WITH_NULL_MD5"                   /*NULL-MD5*/,
                                                                    "SSL_RSA_WITH_NULL_SHA"                   /*NULL-SHA*/,
                                                                    "SSL_RSA_EXPORT_WITH_RC4_40_MD5"          /*EXP-RC4-MD5*/,
                                                                    "SSL_RSA_WITH_RC4_128_MD5"                /*RC4-MD5*/,
                                                                    "SSL_RSA_WITH_RC4_128_SHA"                /*RC4-SHA*/,
                                                                    "SSL_RSA_EXPORT_WITH_RC2_CBC_40_MD5"      /*EXP-RC2-CBC-MD5*/,
                                                                    "SSL_RSA_WITH_IDEA_CBC_SHA"               /*IDEA-CBC-SHA*/,
                                                                    "SSL_RSA_EXPORT_WITH_DES40_CBC_SHA"       /*EXP-DES-CBC-SHA*/,
                                                                    "SSL_RSA_WITH_DES_CBC_SHA"                /*DES-CBC-SHA*/,
                                                                    "SSL_RSA_WITH_3DES_EDE_CBC_SHA"           /*DES-CBC3-SHA*/,
                                                                    "SSL_DH_DSS_EXPORT_WITH_DES40_CBC_SHA"    /*EXP-DH-DSS-DES-CBC-SHA*/,
                                                                    "SSL_DH_DSS_WITH_DES_CBC_SHA"             /*DH-DSS-DES-CBC-SHA*/,
                                                                    "SSL_DH_DSS_WITH_3DES_EDE_CBC_SHA"        /*DH-DSS-DES-CBC3-SHA*/,
                                                                    "SSL_DH_RSA_EXPORT_WITH_DES40_CBC_SHA"    /*EXP-DH-RSA-DES-CBC-SHA*/,
                                                                    "SSL_DH_RSA_WITH_DES_CBC_SHA"             /*DH-RSA-DES-CBC-SHA*/,
                                                                    "SSL_DH_RSA_WITH_3DES_EDE_CBC_SHA"        /*DH-RSA-DES-CBC3-SHA*/,
                                                                    "SSL_DHE_DSS_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-EDH-DSS-DES-CBC-SHA*/,
                                                                    "SSL_DHE_DSS_WITH_DES_CBC_SHA"            /*EDH-DSS-CBC-SHA*/,
                                                                    "SSL_DHE_DSS_WITH_3DES_EDE_CBC_SHA"       /*EDH-DSS-DES-CBC3-SHA*/,
                                                                    "SSL_DHE_RSA_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-EDH-RSA-DES-CBC-SHA*/,
                                                                    "SSL_DHE_RSA_WITH_DES_CBC_SHA"            /*EDH-RSA-DES-CBC-SHA*/,
                                                                    "SSL_DHE_RSA_WITH_3DES_EDE_CBC_SHA"       /*EDH-RSA-DES-CBC3-SHA*/,
                                                                    "SSL_DH_anon_EXPORT_WITH_RC4_40_MD5"      /*EXP-ADH-RC4-MD5*/,
                                                                    "SSL_DH_anon_WITH_RC4_128_MD5"            /*ADH-RC4-MD5*/,
                                                                    "SSL_DH_anon_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-ADH-DES-CBC-SHA*/,
                                                                    "SSL_DH_anon_WITH_DES_CBC_SHA"            /*ADH-DES-CBC-SHA*/,
                                                                    "SSL_DH_anon_WITH_3DES_EDE_CBC_SHA"       /*ADH-DES-CBC3-SHA*/,
                                                                    "SSL_FORTEZZA_KEA_WITH_NULL_SHA"          /*Not implemented.*/,
                                                                    "SSL_FORTEZZA_KEA_WITH_FORTEZZA_CBC_SHA"  /*Not implemented.*/,
                                                                    "SSL_FORTEZZA_KEA_WITH_RC4_128_SHA"       /*Not implemented.*/};

        // Cipher Suites of TLS
        private readonly string[] TLSCipherSuite = new string[] {"TLS_RSA_WITH_NULL_MD5"                      /*NULL-MD5*/,
                                                                    "TLS_RSA_WITH_NULL_SHA"                   /*NULL-SHA*/,
                                                                    "TLS_RSA_EXPORT_WITH_RC4_40_MD5"          /*EXP-RC4-MD5*/,
                                                                    "TLS_RSA_WITH_RC4_128_MD5"                /*RC4-MD5*/,
                                                                    "TLS_RSA_WITH_RC4_128_SHA"                /*RC4-SHA*/,
                                                                    "TLS_RSA_EXPORT_WITH_RC2_CBC_40_MD5"      /*EXP-RC2-CBC-MD5*/,
                                                                    "TLS_RSA_WITH_IDEA_CBC_SHA"               /*IDEA-CBC-SHA*/,
                                                                    "TLS_RSA_EXPORT_WITH_DES40_CBC_SHA"       /*EXP-DES-CBC-SHA*/,
                                                                    "TLS_RSA_WITH_DES_CBC_SHA"                /*DES-CBC-SHA*/,
                                                                    "TLS_RSA_WITH_3DES_EDE_CBC_SHA"           /*DES-CBC3-SHA*/,
                                                                    "TLS_DH_DSS_EXPORT_WITH_DES40_CBC_SHA"    /*Not implemented.*/,
                                                                    "TLS_DH_DSS_WITH_DES_CBC_SHA"             /*Not implemented.*/,
                                                                    "TLS_DH_DSS_WITH_3DES_EDE_CBC_SHA"        /*Not implemented.*/,
                                                                    "TLS_DH_RSA_EXPORT_WITH_DES40_CBC_SHA"    /*Not implemented.*/,
                                                                    "TLS_DH_RSA_WITH_DES_CBC_SHA"             /*Not implemented.*/,
                                                                    "TLS_DH_RSA_WITH_3DES_EDE_CBC_SHA"        /*Not implemented.*/,
                                                                    "TLS_DHE_DSS_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-EDH-DSS-DES-CBC-SHA*/,
                                                                    "TLS_DHE_DSS_WITH_DES_CBC_SHA"            /*EDH-DSS-CBC-SHA*/,
                                                                    "TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA"       /*EDH-DSS-DES-CBC3-SHA*/,
                                                                    "TLS_DHE_RSA_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-EDH-RSA-DES-CBC-SHA*/,
                                                                    "TLS_DHE_RSA_WITH_DES_CBC_SHA"            /*EDH-RSA-DES-CBC-SHA*/,
                                                                    "TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA"       /*EDH-RSA-DES-CBC3-SHA*/,
                                                                    "TLS_DH_anon_EXPORT_WITH_RC4_40_MD5"      /*EXP-ADH-RC4-MD5*/,
                                                                    "TLS_DH_anon_WITH_RC4_128_MD5"            /*ADH-RC4-MD5*/,
                                                                    "TLS_DH_anon_EXPORT_WITH_DES40_CBC_SHA"   /*EXP-ADH-DES-CBC-SHA*/,
                                                                    "TLS_DH_anon_WITH_DES_CBC_SHA"            /*ADH-DES-CBC-SHA*/,
                                                                    "TLS_DH_anon_WITH_3DES_EDE_CBC_SHA"       /*ADH-DES-CBC3-SHA*/,
                                                                    "TLS_RSA_WITH_AES_128_CBC_SHA"            /*AES128-SHA*/,
                                                                    "TLS_RSA_WITH_AES_256_CBC_SHA"            /*AES256-SHA*/,
                                                                    "TLS_DH_DSS_WITH_AES_128_CBC_SHA"         /*DH-DSS-AES128-SHA*/,
                                                                    "TLS_DH_DSS_WITH_AES_256_CBC_SHA"         /*DH-DSS-AES256-SHA*/,
                                                                    "TLS_DH_RSA_WITH_AES_128_CBC_SHA"         /*DH-RSA-AES128-SHA*/,
                                                                    "TLS_DH_RSA_WITH_AES_256_CBC_SHA"         /*DH-RSA-AES256-SHA*/,
                                                                    "TLS_DHE_DSS_WITH_AES_128_CBC_SHA"        /*DHE-DSS-AES128-SHA*/,
                                                                    "TLS_DHE_DSS_WITH_AES_256_CBC_SHA"        /*DHE-DSS-AES256-SHA*/,
                                                                    "TLS_DHE_RSA_WITH_AES_128_CBC_SHA"        /*DHE-RSA-AES128-SHA*/,
                                                                    "TLS_DHE_RSA_WITH_AES_256_CBC_SHA"        /*DHE-RSA-AES256-SHA*/,
                                                                    "TLS_DH_anon_WITH_AES_128_CBC_SHA"        /*ADH-AES128-SHA*/,
                                                                    "TLS_DH_anon_WITH_AES_256_CBC_SHA"        /*ADH-AES256-SHA*/,
                                                                    "TLS_RSA_WITH_CAMELLIA_256_CBC_SHA"       /*CAMELLIA_256_CBC*/,
                                                                    "TLS_DH_DSS_WITH_CAMELLIA_256_CBC_SHA",
                                                                    "TLS_DH_RSA_WITH_CAMELLIA_256_CBC_SHA",
                                                                    "TLS_DHE_DSS_WITH_CAMELLIA_256_CBC_SHA", 
                                                                    "TLS_DHE_RSA_WITH_CAMELLIA_256_CBC_SHA",
                                                                    "TLS_DH_Anon_WITH_CAMELLIA_256_CBC_SHA",
                                                                    "TLS_DHE_PSK_WITH_RC4_128_SHA",
                                                                    "TLS_DHE_PSK_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_DHE_PSK_WITH_AES_128_CBC_SHA",
                                                                    "TLS_RSA_PSK_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_RSA_PSK_WITH_AES_128_CBC_SHA",
                                                                    "TLS_RSA_PSK_WITH_AES_256_CBC_SHA", 
                                                                    "TLS_RSA_WITH_AES_256_GCM_SHA384", 
                                                                    "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256", 
                                                                    "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384", 
                                                                    "TLS_DH_RSA_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_DH_RSA_WITH_AES_256_GCM_SHA384",
                                                                    "TLS_DHE_DSS_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_DHE_DSS_WITH_AES_256_GCM_SHA384",
                                                                    "TLS_DH_DSS_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_DHE_PSK_WITH_AES_256_CBC_SHA",
                                                                    "TLS_ECDH_ECDSA_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA",
                                                                    "TLS_ECDH_Anon_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_ECDH_Anon_WITH_AES_128_CBC_SHA",
                                                                    "TLS_ECDH_Anon_WITH_AES_256_CBC_SHA",
                                                                    "TLS_SRP_SHA_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_SRP_SHA_RSA_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_SRP_SHA_DSS_WITH_3DES_EDE_CBC_SHA",
                                                                    "TLS_SRP_SHA_WITH_AES_256_CBC_SHA",
                                                                    "TLS_SRP_SHA_RSA_WITH_AES_256_CBC_SHA",
                                                                    "TLS_SRP_SHA_DSS_WITH_AES_256_CBC_SHA",
                                                                    "TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256",
                                                                    "TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_128_CBC_SHA256",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_256_CBC_SHA384",
                                                                    "TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256",
                                                                    "TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384",
                                                                    "TLS_ECDH_RSA_WITH_AES_128_CBC_SHA256",
                                                                    "TLS_ECDH_RSA_WITH_AES_256_CBC_SHA384",
                                                                    "TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_ECDH_ECDSA_WITH_AES_256_GCM_SHA384",
                                                                    "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384",
                                                                    "TLS_ECDH_RSA_WITH_AES_128_GCM_SHA256",
                                                                    "TLS_ECDH_RSA_WITH_AES_256_GCM_SHA384"};

        private System.Windows.Forms.MenuStrip menuStripWeakCipherTool;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestPracticesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private ToolStripMenuItem customerToolStripMenuItem;
        private Button Run;
        private Button buttonClearAll;
        private Button buttonSelectAll;
        private ToolStripMenuItem helpDocumentToolStripMenuItem;
        private LinkLabel linkLabel1;
        private LinkLabel linkAbout;
        private LinkLabel linkLabel2;            
    }
}

