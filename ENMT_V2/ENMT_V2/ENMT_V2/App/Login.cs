using ENMT_V2.Repository;
using ENMT_V2.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENMT_V2.App
{
    public partial class Login : Form
    {
        //sampleUserControl sampleUserControl = new sampleUserControl();
        public Login()
        {

            //sampleUserControl.Hide();
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            

            string[] input = new string[2];
            input[0] = txtBoxUserName.Text;
            input[1] = txtBoxPassword.Text;

            if (input[0] == string.Empty || input[1] == string.Empty)
            {
                MessageBox.Show("Fill in required fields.");
                return;
            }

            ILoginAccountRepository la = new LoginAccountRepository();
            var result = la.GetLoginByCredentials(input);

            if (result.Count() == 0)
                MessageBox.Show("Invalid Credentials.");
            else
                mf.ShowDialog();

        }
    }
}
