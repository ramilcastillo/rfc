namespace ENMT_V2.App.Library.Resources
{
    partial class WaterfallView2
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
            this.dgvWaterfall = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaterfall)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWaterfall
            // 
            this.dgvWaterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWaterfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaterfall.Location = new System.Drawing.Point(16, 14);
            this.dgvWaterfall.Name = "dgvWaterfall";
            this.dgvWaterfall.RowTemplate.Height = 24;
            this.dgvWaterfall.Size = new System.Drawing.Size(1004, 399);
            this.dgvWaterfall.TabIndex = 1;
            // 
            // WaterfallView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.dgvWaterfall);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "WaterfallView2";
            this.Size = new System.Drawing.Size(1054, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaterfall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvWaterfall;
    }
}
