namespace ENMT_V2.App.Library.Resources
{
    partial class LALTEView2
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
            this.dgvLALTE = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLALTE)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLALTE
            // 
            this.dgvLALTE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLALTE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLALTE.Location = new System.Drawing.Point(16, 14);
            this.dgvLALTE.Name = "dgvLALTE";
            this.dgvLALTE.RowTemplate.Height = 24;
            this.dgvLALTE.Size = new System.Drawing.Size(1004, 399);
            this.dgvLALTE.TabIndex = 2;
            this.dgvLALTE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLALTE_CellContentClick);
            // 
            // LALTEView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.dgvLALTE);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "LALTEView2";
            this.Size = new System.Drawing.Size(1054, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLALTE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvLALTE;
    }
}
