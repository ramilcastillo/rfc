namespace ENMT_V2.App.Home
{
    partial class HomeView2
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
            this.btnSave = new System.Windows.Forms.Button();
            this.gBoxResource = new System.Windows.Forms.GroupBox();
            this.btnClearWaterfall = new System.Windows.Forms.Button();
            this.btnClearSiteMaster = new System.Windows.Forms.Button();
            this.btnClearLALTE = new System.Windows.Forms.Button();
            this.btnUploadWaterfall = new System.Windows.Forms.Button();
            this.txtBoxWaterfall = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUploadSiteMaster = new System.Windows.Forms.Button();
            this.txtBoxSiteMaster = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadLALTE = new System.Windows.Forms.Button();
            this.txtBoxLALTE = new System.Windows.Forms.TextBox();
            this.lblUpload = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxResource.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnSave.Location = new System.Drawing.Point(858, 79);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 33);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gBoxResource
            // 
            this.gBoxResource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxResource.Controls.Add(this.btnClearWaterfall);
            this.gBoxResource.Controls.Add(this.btnClearSiteMaster);
            this.gBoxResource.Controls.Add(this.btnClearLALTE);
            this.gBoxResource.Controls.Add(this.btnUploadWaterfall);
            this.gBoxResource.Controls.Add(this.txtBoxWaterfall);
            this.gBoxResource.Controls.Add(this.label3);
            this.gBoxResource.Controls.Add(this.btnUploadSiteMaster);
            this.gBoxResource.Controls.Add(this.txtBoxSiteMaster);
            this.gBoxResource.Controls.Add(this.label1);
            this.gBoxResource.Controls.Add(this.btnUploadLALTE);
            this.gBoxResource.Controls.Add(this.txtBoxLALTE);
            this.gBoxResource.Controls.Add(this.lblUpload);
            this.gBoxResource.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxResource.ForeColor = System.Drawing.Color.White;
            this.gBoxResource.Location = new System.Drawing.Point(100, 118);
            this.gBoxResource.Name = "gBoxResource";
            this.gBoxResource.Size = new System.Drawing.Size(848, 203);
            this.gBoxResource.TabIndex = 13;
            this.gBoxResource.TabStop = false;
            this.gBoxResource.Text = "Resources";
            // 
            // btnClearWaterfall
            // 
            this.btnClearWaterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearWaterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearWaterfall.Location = new System.Drawing.Point(724, 121);
            this.btnClearWaterfall.Name = "btnClearWaterfall";
            this.btnClearWaterfall.Size = new System.Drawing.Size(106, 33);
            this.btnClearWaterfall.TabIndex = 15;
            this.btnClearWaterfall.Text = "&Clear";
            this.btnClearWaterfall.UseVisualStyleBackColor = true;
            this.btnClearWaterfall.Click += new System.EventHandler(this.btnClearWaterfall_Click);
            // 
            // btnClearSiteMaster
            // 
            this.btnClearSiteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSiteMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSiteMaster.Location = new System.Drawing.Point(724, 80);
            this.btnClearSiteMaster.Name = "btnClearSiteMaster";
            this.btnClearSiteMaster.Size = new System.Drawing.Size(106, 33);
            this.btnClearSiteMaster.TabIndex = 14;
            this.btnClearSiteMaster.Text = "&Clear";
            this.btnClearSiteMaster.UseVisualStyleBackColor = true;
            this.btnClearSiteMaster.Click += new System.EventHandler(this.btnClearSiteMaster_Click);
            // 
            // btnClearLALTE
            // 
            this.btnClearLALTE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLALTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLALTE.Location = new System.Drawing.Point(724, 39);
            this.btnClearLALTE.Name = "btnClearLALTE";
            this.btnClearLALTE.Size = new System.Drawing.Size(106, 33);
            this.btnClearLALTE.TabIndex = 13;
            this.btnClearLALTE.Text = "&Clear";
            this.btnClearLALTE.UseVisualStyleBackColor = true;
            this.btnClearLALTE.Click += new System.EventHandler(this.btnClearLALTE_Click);
            // 
            // btnUploadWaterfall
            // 
            this.btnUploadWaterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadWaterfall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadWaterfall.Location = new System.Drawing.Point(612, 121);
            this.btnUploadWaterfall.Name = "btnUploadWaterfall";
            this.btnUploadWaterfall.Size = new System.Drawing.Size(106, 33);
            this.btnUploadWaterfall.TabIndex = 12;
            this.btnUploadWaterfall.Text = "&Upload";
            this.btnUploadWaterfall.UseVisualStyleBackColor = true;
            this.btnUploadWaterfall.Click += new System.EventHandler(this.btnUploadWaterfall_Click);
            // 
            // txtBoxWaterfall
            // 
            this.txtBoxWaterfall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxWaterfall.Location = new System.Drawing.Point(125, 126);
            this.txtBoxWaterfall.Name = "txtBoxWaterfall";
            this.txtBoxWaterfall.ReadOnly = true;
            this.txtBoxWaterfall.Size = new System.Drawing.Size(458, 23);
            this.txtBoxWaterfall.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(33, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Waterfall";
            // 
            // btnUploadSiteMaster
            // 
            this.btnUploadSiteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadSiteMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadSiteMaster.Location = new System.Drawing.Point(612, 80);
            this.btnUploadSiteMaster.Name = "btnUploadSiteMaster";
            this.btnUploadSiteMaster.Size = new System.Drawing.Size(106, 33);
            this.btnUploadSiteMaster.TabIndex = 9;
            this.btnUploadSiteMaster.Text = "&Upload";
            this.btnUploadSiteMaster.UseVisualStyleBackColor = true;
            this.btnUploadSiteMaster.Click += new System.EventHandler(this.btnUploadSiteMaster_Click);
            // 
            // txtBoxSiteMaster
            // 
            this.txtBoxSiteMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxSiteMaster.Location = new System.Drawing.Point(125, 85);
            this.txtBoxSiteMaster.Name = "txtBoxSiteMaster";
            this.txtBoxSiteMaster.ReadOnly = true;
            this.txtBoxSiteMaster.Size = new System.Drawing.Size(458, 23);
            this.txtBoxSiteMaster.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Site Master";
            // 
            // btnUploadLALTE
            // 
            this.btnUploadLALTE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadLALTE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadLALTE.Location = new System.Drawing.Point(612, 39);
            this.btnUploadLALTE.Name = "btnUploadLALTE";
            this.btnUploadLALTE.Size = new System.Drawing.Size(106, 33);
            this.btnUploadLALTE.TabIndex = 6;
            this.btnUploadLALTE.Text = "&Upload";
            this.btnUploadLALTE.UseVisualStyleBackColor = true;
            this.btnUploadLALTE.Click += new System.EventHandler(this.btnUploadLALTE_Click);
            // 
            // txtBoxLALTE
            // 
            this.txtBoxLALTE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxLALTE.Location = new System.Drawing.Point(125, 44);
            this.txtBoxLALTE.Name = "txtBoxLALTE";
            this.txtBoxLALTE.ReadOnly = true;
            this.txtBoxLALTE.Size = new System.Drawing.Size(458, 23);
            this.txtBoxLALTE.TabIndex = 5;
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.ForeColor = System.Drawing.Color.White;
            this.lblUpload.Location = new System.Drawing.Point(33, 47);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(55, 19);
            this.lblUpload.TabIndex = 4;
            this.lblUpload.Text = "L.A. LTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Input";
            // 
            // HomeView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gBoxResource);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "HomeView2";
            this.Size = new System.Drawing.Size(1054, 429);
            this.gBoxResource.ResumeLayout(false);
            this.gBoxResource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gBoxResource;
        private System.Windows.Forms.Button btnUploadSiteMaster;
        private System.Windows.Forms.TextBox txtBoxSiteMaster;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUploadLALTE;
        private System.Windows.Forms.TextBox txtBoxLALTE;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUploadWaterfall;
        private System.Windows.Forms.TextBox txtBoxWaterfall;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearWaterfall;
        private System.Windows.Forms.Button btnClearSiteMaster;
        private System.Windows.Forms.Button btnClearLALTE;
    }
}
