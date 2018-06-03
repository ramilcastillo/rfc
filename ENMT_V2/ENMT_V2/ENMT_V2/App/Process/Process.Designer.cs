namespace ENMT_V2.App.Process
{
    partial class Process
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.process11 = new ENMT_V2.App.Process.Process1();
            this.process31 = new ENMT_V2.App.Process.Process3();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Process";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnNext.Location = new System.Drawing.Point(194, 98);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 33);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnBack.Location = new System.Drawing.Point(98, 98);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 33);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // process11
            // 
            this.process11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.process11.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.process11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.process11.Location = new System.Drawing.Point(0, 219);
            this.process11.Name = "process11";
            this.process11.Size = new System.Drawing.Size(1200, 429);
            this.process11.TabIndex = 13;
            this.process11.Load += new System.EventHandler(this.process11_Load);
            // 
            // process31
            // 
            this.process31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.process31.Location = new System.Drawing.Point(3, 219);
            this.process31.Name = "process31";
            this.process31.Size = new System.Drawing.Size(1200, 429);
            this.process31.TabIndex = 14;
            // 
            // Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.process31);
            this.Controls.Add(this.process11);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "Process";
            this.Size = new System.Drawing.Size(1200, 648);
            this.Load += new System.EventHandler(this.Process_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private Process1 process11;
        private Process3 process31;
    }
}
