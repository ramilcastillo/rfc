namespace ENMT_V2.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLibraries = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelLibraries = new System.Windows.Forms.Panel();
            this.btnWaterfall = new System.Windows.Forms.Button();
            this.btnSiteMaster = new System.Windows.Forms.Button();
            this.btnLALTE = new System.Windows.Forms.Button();
            this.btnCI004RFDS = new System.Windows.Forms.Button();
            this.btnCI004Waterfall = new System.Windows.Forms.Button();
            this.siteMasterView11 = new ENMT_V2.App.Library.Resources.SiteMasterView1();
            this.homeView11 = new ENMT_V2.App.Home.HomeView1();
            this.cI004RFDSView11 = new ENMT_V2.App.Library.Resources.CI004RFDSView1();
            this.cI004WaterfallView11 = new ENMT_V2.App.Library.Resources.CI004WaterfallView1();
            this.lalteView11 = new ENMT_V2.App.Library.Resources.LALTEView1();
            this.waterfallView11 = new ENMT_V2.App.Library.Resources.WaterfallView1();
            this.process1 = new ENMT_V2.App.Process.Process();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLibraries.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnLibraries);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 749);
            this.panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(2, 413);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(209, 90);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLibraries
            // 
            this.btnLibraries.FlatAppearance.BorderSize = 0;
            this.btnLibraries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibraries.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibraries.ForeColor = System.Drawing.Color.White;
            this.btnLibraries.Image = ((System.Drawing.Image)(resources.GetObject("btnLibraries.Image")));
            this.btnLibraries.Location = new System.Drawing.Point(3, 221);
            this.btnLibraries.Name = "btnLibraries";
            this.btnLibraries.Size = new System.Drawing.Size(209, 90);
            this.btnLibraries.TabIndex = 4;
            this.btnLibraries.Text = "Library";
            this.btnLibraries.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLibraries.UseVisualStyleBackColor = true;
            this.btnLibraries.Click += new System.EventHandler(this.btnLibraries_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.White;
            this.btnProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnProcess.Image")));
            this.btnProcess.Location = new System.Drawing.Point(2, 317);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(209, 90);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnModule1_Click);
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(3, 125);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(209, 90);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gold;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 95);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(56, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label1.Location = new System.Drawing.Point(90, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ENMT";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(221, 486);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1206, 100);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1348, -9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 89);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Gold;
            this.panelLeft.Location = new System.Drawing.Point(218, 144);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(7, 72);
            this.panelLeft.TabIndex = 4;
            // 
            // panelLibraries
            // 
            this.panelLibraries.Controls.Add(this.btnWaterfall);
            this.panelLibraries.Controls.Add(this.btnSiteMaster);
            this.panelLibraries.Controls.Add(this.btnLALTE);
            this.panelLibraries.Controls.Add(this.btnCI004RFDS);
            this.panelLibraries.Controls.Add(this.btnCI004Waterfall);
            this.panelLibraries.Location = new System.Drawing.Point(222, 4);
            this.panelLibraries.Name = "panelLibraries";
            this.panelLibraries.Size = new System.Drawing.Size(700, 92);
            this.panelLibraries.TabIndex = 4;
            this.panelLibraries.Visible = false;
            // 
            // btnWaterfall
            // 
            this.btnWaterfall.FlatAppearance.BorderSize = 0;
            this.btnWaterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaterfall.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnWaterfall.ForeColor = System.Drawing.Color.White;
            this.btnWaterfall.Image = ((System.Drawing.Image)(resources.GetObject("btnWaterfall.Image")));
            this.btnWaterfall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWaterfall.Location = new System.Drawing.Point(523, 2);
            this.btnWaterfall.Name = "btnWaterfall";
            this.btnWaterfall.Size = new System.Drawing.Size(124, 87);
            this.btnWaterfall.TabIndex = 9;
            this.btnWaterfall.Text = "Waterfall";
            this.btnWaterfall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWaterfall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWaterfall.UseVisualStyleBackColor = true;
            this.btnWaterfall.Click += new System.EventHandler(this.btnWaterfall_Click);
            // 
            // btnSiteMaster
            // 
            this.btnSiteMaster.FlatAppearance.BorderSize = 0;
            this.btnSiteMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiteMaster.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnSiteMaster.ForeColor = System.Drawing.Color.White;
            this.btnSiteMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnSiteMaster.Image")));
            this.btnSiteMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiteMaster.Location = new System.Drawing.Point(393, 2);
            this.btnSiteMaster.Name = "btnSiteMaster";
            this.btnSiteMaster.Size = new System.Drawing.Size(124, 87);
            this.btnSiteMaster.TabIndex = 8;
            this.btnSiteMaster.Text = "Site Master";
            this.btnSiteMaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiteMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSiteMaster.UseVisualStyleBackColor = true;
            this.btnSiteMaster.Click += new System.EventHandler(this.btnSiteMaster_Click);
            // 
            // btnLALTE
            // 
            this.btnLALTE.FlatAppearance.BorderSize = 0;
            this.btnLALTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLALTE.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnLALTE.ForeColor = System.Drawing.Color.White;
            this.btnLALTE.Image = ((System.Drawing.Image)(resources.GetObject("btnLALTE.Image")));
            this.btnLALTE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLALTE.Location = new System.Drawing.Point(263, 2);
            this.btnLALTE.Name = "btnLALTE";
            this.btnLALTE.Size = new System.Drawing.Size(124, 87);
            this.btnLALTE.TabIndex = 7;
            this.btnLALTE.Text = "L.A. LTE";
            this.btnLALTE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLALTE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLALTE.UseVisualStyleBackColor = true;
            this.btnLALTE.Click += new System.EventHandler(this.btnLALTE_Click);
            // 
            // btnCI004RFDS
            // 
            this.btnCI004RFDS.FlatAppearance.BorderSize = 0;
            this.btnCI004RFDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCI004RFDS.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnCI004RFDS.ForeColor = System.Drawing.Color.White;
            this.btnCI004RFDS.Image = ((System.Drawing.Image)(resources.GetObject("btnCI004RFDS.Image")));
            this.btnCI004RFDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCI004RFDS.Location = new System.Drawing.Point(133, 3);
            this.btnCI004RFDS.Name = "btnCI004RFDS";
            this.btnCI004RFDS.Size = new System.Drawing.Size(124, 87);
            this.btnCI004RFDS.TabIndex = 6;
            this.btnCI004RFDS.Text = "CI004 RFDS";
            this.btnCI004RFDS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCI004RFDS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCI004RFDS.UseVisualStyleBackColor = true;
            this.btnCI004RFDS.Click += new System.EventHandler(this.btnCI004RFDS_Click);
            // 
            // btnCI004Waterfall
            // 
            this.btnCI004Waterfall.FlatAppearance.BorderSize = 0;
            this.btnCI004Waterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCI004Waterfall.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.btnCI004Waterfall.ForeColor = System.Drawing.Color.White;
            this.btnCI004Waterfall.Image = ((System.Drawing.Image)(resources.GetObject("btnCI004Waterfall.Image")));
            this.btnCI004Waterfall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCI004Waterfall.Location = new System.Drawing.Point(3, 2);
            this.btnCI004Waterfall.Name = "btnCI004Waterfall";
            this.btnCI004Waterfall.Size = new System.Drawing.Size(124, 87);
            this.btnCI004Waterfall.TabIndex = 5;
            this.btnCI004Waterfall.Text = "CI004 Waterfall";
            this.btnCI004Waterfall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCI004Waterfall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCI004Waterfall.UseVisualStyleBackColor = true;
            this.btnCI004Waterfall.Click += new System.EventHandler(this.btnCI004Waterfall_Click);
            // 
            // siteMasterView11
            // 
            this.siteMasterView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.siteMasterView11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.siteMasterView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.siteMasterView11.Location = new System.Drawing.Point(228, 99);
            this.siteMasterView11.Name = "siteMasterView11";
            this.siteMasterView11.Size = new System.Drawing.Size(1200, 648);
            this.siteMasterView11.TabIndex = 6;
            // 
            // homeView11
            // 
            this.homeView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.homeView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.homeView11.Location = new System.Drawing.Point(227, 99);
            this.homeView11.Name = "homeView11";
            this.homeView11.Size = new System.Drawing.Size(1200, 648);
            this.homeView11.TabIndex = 5;
            // 
            // cI004RFDSView11
            // 
            this.cI004RFDSView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.cI004RFDSView11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.cI004RFDSView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.cI004RFDSView11.Location = new System.Drawing.Point(228, 99);
            this.cI004RFDSView11.Name = "cI004RFDSView11";
            this.cI004RFDSView11.Size = new System.Drawing.Size(1200, 648);
            this.cI004RFDSView11.TabIndex = 7;
            // 
            // cI004WaterfallView11
            // 
            this.cI004WaterfallView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.cI004WaterfallView11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.cI004WaterfallView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.cI004WaterfallView11.Location = new System.Drawing.Point(227, 99);
            this.cI004WaterfallView11.Name = "cI004WaterfallView11";
            this.cI004WaterfallView11.Size = new System.Drawing.Size(1200, 648);
            this.cI004WaterfallView11.TabIndex = 8;
            // 
            // lalteView11
            // 
            this.lalteView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.lalteView11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.lalteView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lalteView11.Location = new System.Drawing.Point(227, 99);
            this.lalteView11.Name = "lalteView11";
            this.lalteView11.Size = new System.Drawing.Size(1200, 648);
            this.lalteView11.TabIndex = 9;
            // 
            // waterfallView11
            // 
            this.waterfallView11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.waterfallView11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.waterfallView11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.waterfallView11.Location = new System.Drawing.Point(227, 99);
            this.waterfallView11.Name = "waterfallView11";
            this.waterfallView11.Size = new System.Drawing.Size(1200, 648);
            this.waterfallView11.TabIndex = 10;
            // 
            // process1
            // 
            this.process1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.process1.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.process1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.process1.Location = new System.Drawing.Point(227, 99);
            this.process1.Name = "process1";
            this.process1.Size = new System.Drawing.Size(1200, 648);
            this.process1.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(1430, 751);
            this.Controls.Add(this.process1);
            this.Controls.Add(this.waterfallView11);
            this.Controls.Add(this.lalteView11);
            this.Controls.Add(this.cI004WaterfallView11);
            this.Controls.Add(this.cI004RFDSView11);
            this.Controls.Add(this.siteMasterView11);
            this.Controls.Add(this.homeView11);
            this.Controls.Add(this.panelLibraries);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLibraries.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnLibraries;
        private System.Windows.Forms.Panel panelLibraries;
        private System.Windows.Forms.Button btnCI004Waterfall;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCI004RFDS;
        private System.Windows.Forms.Button btnLALTE;
        private System.Windows.Forms.Button btnSiteMaster;
        private System.Windows.Forms.Button btnWaterfall;
        private Home.HomeView1 homeView11;
        private Library.Resources.SiteMasterView1 siteMasterView11;
        private Library.Resources.CI004RFDSView1 cI004RFDSView11;
        private Library.Resources.CI004WaterfallView1 cI004WaterfallView11;
        private Library.Resources.LALTEView1 lalteView11;
        private Library.Resources.WaterfallView1 waterfallView11;
        private Process.Process process1;
    }
}