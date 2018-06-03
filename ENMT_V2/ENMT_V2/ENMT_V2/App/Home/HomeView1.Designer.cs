namespace ENMT_V2.App.Home
{
    partial class HomeView1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxCI004Waterfall = new System.Windows.Forms.TextBox();
            this.lblUpload = new System.Windows.Forms.Label();
            this.gBoxResource = new System.Windows.Forms.GroupBox();
            this.btnClearRFDS = new System.Windows.Forms.Button();
            this.btnClearWaterfall = new System.Windows.Forms.Button();
            this.btnCI004RFDS = new System.Windows.Forms.Button();
            this.txtBoxUploadCI004RFDS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadCI004Waterfall = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.homeView21 = new ENMT_V2.App.Home.HomeView2();
            this.gBoxResource.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resources";
            // 
            // txtBoxCI004Waterfall
            // 
            this.txtBoxCI004Waterfall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxCI004Waterfall.Location = new System.Drawing.Point(153, 46);
            this.txtBoxCI004Waterfall.Name = "txtBoxCI004Waterfall";
            this.txtBoxCI004Waterfall.ReadOnly = true;
            this.txtBoxCI004Waterfall.Size = new System.Drawing.Size(628, 23);
            this.txtBoxCI004Waterfall.TabIndex = 5;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.ForeColor = System.Drawing.Color.White;
            this.lblUpload.Location = new System.Drawing.Point(33, 49);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(114, 19);
            this.lblUpload.TabIndex = 4;
            this.lblUpload.Text = "CI004 Waterfall";
            // 
            // gBoxResource
            // 
            this.gBoxResource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxResource.Controls.Add(this.btnClearRFDS);
            this.gBoxResource.Controls.Add(this.btnClearWaterfall);
            this.gBoxResource.Controls.Add(this.btnCI004RFDS);
            this.gBoxResource.Controls.Add(this.txtBoxUploadCI004RFDS);
            this.gBoxResource.Controls.Add(this.label1);
            this.gBoxResource.Controls.Add(this.btnUploadCI004Waterfall);
            this.gBoxResource.Controls.Add(this.txtBoxCI004Waterfall);
            this.gBoxResource.Controls.Add(this.lblUpload);
            this.gBoxResource.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxResource.ForeColor = System.Drawing.Color.White;
            this.gBoxResource.Location = new System.Drawing.Point(101, 106);
            this.gBoxResource.Name = "gBoxResource";
            this.gBoxResource.Size = new System.Drawing.Size(1044, 154);
            this.gBoxResource.TabIndex = 6;
            this.gBoxResource.TabStop = false;
            this.gBoxResource.Text = "Resources";
            // 
            // btnClearRFDS
            // 
            this.btnClearRFDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearRFDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearRFDS.Location = new System.Drawing.Point(909, 82);
            this.btnClearRFDS.Name = "btnClearRFDS";
            this.btnClearRFDS.Size = new System.Drawing.Size(106, 33);
            this.btnClearRFDS.TabIndex = 15;
            this.btnClearRFDS.Text = "&Clear";
            this.btnClearRFDS.UseVisualStyleBackColor = true;
            this.btnClearRFDS.Click += new System.EventHandler(this.btnClearRFDS_Click);
            // 
            // btnClearWaterfall
            // 
            this.btnClearWaterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearWaterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearWaterfall.Location = new System.Drawing.Point(908, 41);
            this.btnClearWaterfall.Name = "btnClearWaterfall";
            this.btnClearWaterfall.Size = new System.Drawing.Size(106, 33);
            this.btnClearWaterfall.TabIndex = 14;
            this.btnClearWaterfall.Text = "&Clear";
            this.btnClearWaterfall.UseVisualStyleBackColor = true;
            this.btnClearWaterfall.Click += new System.EventHandler(this.btnClearWaterfall_Click);
            // 
            // btnCI004RFDS
            // 
            this.btnCI004RFDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCI004RFDS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCI004RFDS.Location = new System.Drawing.Point(797, 82);
            this.btnCI004RFDS.Name = "btnCI004RFDS";
            this.btnCI004RFDS.Size = new System.Drawing.Size(106, 33);
            this.btnCI004RFDS.TabIndex = 9;
            this.btnCI004RFDS.Text = "&Upload";
            this.btnCI004RFDS.UseVisualStyleBackColor = true;
            this.btnCI004RFDS.Click += new System.EventHandler(this.btnCI004RFDS_Click);
            // 
            // txtBoxUploadCI004RFDS
            // 
            this.txtBoxUploadCI004RFDS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxUploadCI004RFDS.Location = new System.Drawing.Point(153, 87);
            this.txtBoxUploadCI004RFDS.Name = "txtBoxUploadCI004RFDS";
            this.txtBoxUploadCI004RFDS.ReadOnly = true;
            this.txtBoxUploadCI004RFDS.Size = new System.Drawing.Size(628, 23);
            this.txtBoxUploadCI004RFDS.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "CI004 RFDS";
            // 
            // btnUploadCI004Waterfall
            // 
            this.btnUploadCI004Waterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadCI004Waterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCI004Waterfall.Location = new System.Drawing.Point(797, 41);
            this.btnUploadCI004Waterfall.Name = "btnUploadCI004Waterfall";
            this.btnUploadCI004Waterfall.Size = new System.Drawing.Size(106, 33);
            this.btnUploadCI004Waterfall.TabIndex = 6;
            this.btnUploadCI004Waterfall.Text = "&Upload";
            this.btnUploadCI004Waterfall.UseVisualStyleBackColor = true;
            this.btnUploadCI004Waterfall.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnSave.Location = new System.Drawing.Point(1055, 67);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 33);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // homeView21
            // 
            this.homeView21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.homeView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.homeView21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.homeView21.Location = new System.Drawing.Point(0, 290);
            this.homeView21.Name = "homeView21";
            this.homeView21.Size = new System.Drawing.Size(1256, 358);
            this.homeView21.TabIndex = 11;
            this.homeView21.Load += new System.EventHandler(this.homeView21_Load_1);
            // 
            // HomeView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.homeView21);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBoxResource);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "HomeView1";
            this.Size = new System.Drawing.Size(1200, 648);
            this.Load += new System.EventHandler(this.HomeView1_Load);
            this.gBoxResource.ResumeLayout(false);
            this.gBoxResource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxCI004Waterfall;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.GroupBox gBoxResource;
        private System.Windows.Forms.Button btnUploadCI004Waterfall;
        private System.Windows.Forms.Button btnCI004RFDS;
        private System.Windows.Forms.TextBox txtBoxUploadCI004RFDS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearRFDS;
        private System.Windows.Forms.Button btnClearWaterfall;
        private HomeView2 homeView21;
    }
}
