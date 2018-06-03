namespace ENMT_V2.App.Process
{
    partial class Process1
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
            this.btnGetRFDSID = new System.Windows.Forms.Button();
            this.dgvProcess1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetRFDSID
            // 
            this.btnGetRFDSID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRFDSID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetRFDSID.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.btnGetRFDSID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnGetRFDSID.Location = new System.Drawing.Point(27, 24);
            this.btnGetRFDSID.Name = "btnGetRFDSID";
            this.btnGetRFDSID.Size = new System.Drawing.Size(159, 33);
            this.btnGetRFDSID.TabIndex = 13;
            this.btnGetRFDSID.Text = "&Get List RFDS ID";
            this.btnGetRFDSID.UseVisualStyleBackColor = true;
            this.btnGetRFDSID.Click += new System.EventHandler(this.btnGetRFDSID_Click);
            // 
            // dgvProcess1
            // 
            this.dgvProcess1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcess1.Location = new System.Drawing.Point(27, 63);
            this.dgvProcess1.Name = "dgvProcess1";
            this.dgvProcess1.RowTemplate.Height = 24;
            this.dgvProcess1.Size = new System.Drawing.Size(1138, 351);
            this.dgvProcess1.TabIndex = 14;
            // 
            // Process1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.dgvProcess1);
            this.Controls.Add(this.btnGetRFDSID);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "Process1";
            this.Size = new System.Drawing.Size(1200, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcess1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetRFDSID;
        private System.Windows.Forms.DataGridView dgvProcess1;
    }
}
