namespace ENMT_V2.App.Library.Resources
{
    partial class CI004RFDSView2
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
            this.dgvCI004RFDS = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCI004RFDS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCI004RFDS
            // 
            this.dgvCI004RFDS.AllowUserToAddRows = false;
            this.dgvCI004RFDS.AllowUserToDeleteRows = false;
            this.dgvCI004RFDS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCI004RFDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCI004RFDS.Location = new System.Drawing.Point(16, 14);
            this.dgvCI004RFDS.Name = "dgvCI004RFDS";
            this.dgvCI004RFDS.RowTemplate.Height = 24;
            this.dgvCI004RFDS.Size = new System.Drawing.Size(1004, 399);
            this.dgvCI004RFDS.TabIndex = 1;
            this.dgvCI004RFDS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCI004RFDS_CellContentClick);
            // 
            // CI004RFDSView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.dgvCI004RFDS);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "CI004RFDSView2";
            this.Size = new System.Drawing.Size(1054, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCI004RFDS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCI004RFDS;
    }
}
