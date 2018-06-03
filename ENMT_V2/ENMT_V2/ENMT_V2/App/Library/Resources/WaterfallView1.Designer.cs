namespace ENMT_V2.App.Library.Resources
{
    partial class WaterfallView1
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
            this.waterfallView21 = new ENMT_V2.App.Library.Resources.WaterfallView2();
            this.cmBoxStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Waterfall";
            // 
            // waterfallView21
            // 
            this.waterfallView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.waterfallView21.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.waterfallView21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.waterfallView21.Location = new System.Drawing.Point(3, 216);
            this.waterfallView21.Name = "waterfallView21";
            this.waterfallView21.Size = new System.Drawing.Size(1197, 429);
            this.waterfallView21.TabIndex = 8;
            // 
            // cmBoxStatus
            // 
            this.cmBoxStatus.FormattingEnabled = true;
            this.cmBoxStatus.Items.AddRange(new object[] {
            "Imp_Data",
            "NSB_Data"});
            this.cmBoxStatus.Location = new System.Drawing.Point(181, 107);
            this.cmBoxStatus.Name = "cmBoxStatus";
            this.cmBoxStatus.Size = new System.Drawing.Size(146, 25);
            this.cmBoxStatus.TabIndex = 10;
            this.cmBoxStatus.SelectedIndexChanged += new System.EventHandler(this.cmBoxStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select View";
            // 
            // WaterfallView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.cmBoxStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.waterfallView21);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "WaterfallView1";
            this.Size = new System.Drawing.Size(1200, 648);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private WaterfallView2 waterfallView21;
        private System.Windows.Forms.ComboBox cmBoxStatus;
        private System.Windows.Forms.Label label1;
    }
}
