namespace ENMT_V2.App.Library.Resources
{
    partial class CI004WaterfallView2
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
            this.dgvCI004Waterfall = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCI004Waterfall)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCI004Waterfall
            // 
            this.dgvCI004Waterfall.AllowUserToAddRows = false;
            this.dgvCI004Waterfall.AllowUserToDeleteRows = false;
            this.dgvCI004Waterfall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCI004Waterfall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCI004Waterfall.Location = new System.Drawing.Point(16, 14);
            this.dgvCI004Waterfall.Name = "dgvCI004Waterfall";
            this.dgvCI004Waterfall.RowTemplate.Height = 24;
            this.dgvCI004Waterfall.Size = new System.Drawing.Size(1004, 399);
            this.dgvCI004Waterfall.TabIndex = 0;
            this.dgvCI004Waterfall.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCI004Waterfall_CellContentClick);
            // 
            // CI004WaterfallView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.dgvCI004Waterfall);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.Name = "CI004WaterfallView2";
            this.Size = new System.Drawing.Size(1054, 429);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCI004Waterfall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvCI004Waterfall;
    }
}
