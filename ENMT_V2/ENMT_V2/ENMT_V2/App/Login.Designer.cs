namespace ENMT_V2.App
{
    partial class Login
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1432, 894);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 42);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.Location = new System.Drawing.Point(403, 89);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '●';
            this.txtBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBoxPassword.ShortcutsEnabled = false;
            this.txtBoxPassword.Size = new System.Drawing.Size(170, 24);
            this.txtBoxPassword.TabIndex = 1;
            this.txtBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUserName.Location = new System.Drawing.Point(403, 50);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBoxUserName.Size = new System.Drawing.Size(170, 24);
            this.txtBoxUserName.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(444, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 34);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label2.Location = new System.Drawing.Point(295, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "PASSWORD:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Honeydew;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label1.Location = new System.Drawing.Point(294, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "USER NAME:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Window;
            this.btnLogin.Location = new System.Drawing.Point(444, 121);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(129, 35);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "&LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(591, 245);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
    }
}