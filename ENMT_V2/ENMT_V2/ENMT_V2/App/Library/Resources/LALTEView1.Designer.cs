namespace ENMT_V2.App.Library.Resources
{
    partial class LALTEView1
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
            this.lalteView21 = new ENMT_V2.App.Library.Resources.LALTEView2();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "L.A. LTE";
            // 
            // lalteView21
            // 
            this.lalteView21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.lalteView21.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.lalteView21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.lalteView21.Location = new System.Drawing.Point(0, 216);
            this.lalteView21.Name = "lalteView21";
            this.lalteView21.Size = new System.Drawing.Size(1200, 429);
            this.lalteView21.TabIndex = 7;
            // 
            // LALTEView1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.lalteView21);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "LALTEView1";
            this.Size = new System.Drawing.Size(1200, 648);
            this.Load += new System.EventHandler(this.LALTEView1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public LALTEView2 lalteView21;
    }
}
