using System;
using System.Windows.Forms;
using ENMT_V2.Repository.Interface;
using ENMT_V2.Repository;
using System.IO;

namespace ENMT_V2.App.Home
{
    public partial class HomeView1 : UserControl
    {
        public HomeView1()
        {
            InitializeComponent();
        }

        public void DeleteItemsInFolder(string folderPath)
        {
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            #region CI004RFDS
            if (txtBoxUploadCI004RFDS.Text != string.Empty)
            { 
                var filename = Path.GetFileName(txtBoxUploadCI004RFDS.Text);
                DeleteItemsInFolder(Application.StartupPath + "\\CI004_RDFS\\");
                File.Copy(txtBoxUploadCI004RFDS.Text, Application.StartupPath + "\\CI004_RDFS\\" + filename, true);
            }
            #endregion

            #region CI004Waterfall
            if (txtBoxCI004Waterfall.Text != string.Empty)
            {
                var filename = Path.GetFileName(txtBoxCI004Waterfall.Text);
                DeleteItemsInFolder(Application.StartupPath + "\\CI004_Waterfall\\");
                File.Copy(txtBoxCI004Waterfall.Text, Application.StartupPath + "\\CI004_Waterfall\\" + filename, true);
            }
            #endregion

            if (txtBoxCI004Waterfall.Text == string.Empty && txtBoxUploadCI004RFDS.Text == string.Empty)
            {
                MessageBox.Show("No Files Uploaded.");
            }
            else
            {
                MessageBox.Show("Successfully Save.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "CI004_Check_Waterfall*";
            ofd.ShowDialog();
            txtBoxCI004Waterfall.Text = ofd.FileName;
        }

        private void btnCI004RFDS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "CI004_Check_RFDS*";
            ofd.ShowDialog();
            txtBoxUploadCI004RFDS.Text = ofd.FileName;
        }

        private void btnClearWaterfall_Click(object sender, EventArgs e)
        {
            txtBoxCI004Waterfall.Text = string.Empty;
        }

        private void btnClearRFDS_Click(object sender, EventArgs e)
        {
            txtBoxUploadCI004RFDS.Text = string.Empty;
        }

        private void HomeView1_Load(object sender, EventArgs e)
        {

        }

        private void homeView21_Load(object sender, EventArgs e)
        {

        }

        private void homeView21_Load_1(object sender, EventArgs e)
        {

        }
    }
}
