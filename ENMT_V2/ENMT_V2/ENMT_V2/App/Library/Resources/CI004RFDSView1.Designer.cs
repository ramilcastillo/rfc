namespace ENMT_V2.App.Library.Resources
{
    partial class CI004RFDSView1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmBoxStatus = new System.Windows.Forms.ComboBox();
            this.cI004RFDSView21 = new ENMT_V2.App.Library.Resources.CI004RFDSView2();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "CI004 RFDS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select View";
            // 
            // cmBoxStatus
            // 
            this.cmBoxStatus.FormattingEnabled = true;
            this.cmBoxStatus.Items.AddRange(new object[] {
            "NOT IN CSS",
            "SECTOR IN CSS",
            "MISSING COORDINATES",
            "DETAILS"});
            this.cmBoxStatus.Location = new System.Drawing.Point(181, 107);
            this.cmBoxStatus.Name = "cmBoxStatus";
            this.cmBoxStatus.Size = new System.Drawing.Size(146, 25);
            this.cmBoxStatus.TabIndex = 7;
            this.cmBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cI004RFDSView21
            // 
            this.cI004RFDSView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.cI004RFDSView21.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.cI004RFDSView21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.cI004RFDSView21.Location = new System.Drawing.Point(3, 216);
            this.cI004RFDSView21.Name = "cI004RFDSView21";
            this.cI004RFDSView21.Size = new System.Drawing.Size(1194, 429);
            this.cI004RFDSView21.TabIndex = 8;
            // 
            // CI004RFDSView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.cI004RFDSView21);
            this.Controls.Add(this.cmBoxStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "CI004RFDSView1";
            this.Size = new System.Drawing.Size(1200, 648);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBoxStatus;
        private CI004RFDSView2 cI004RFDSView21;
    }
}
