using System;
using System.Windows.Forms;
using System.IO;
using GemBox.Spreadsheet;
using Microsoft.Office.Interop.Excel;

namespace ENMT_V2.App.Home
{
    public partial class HomeView2 : UserControl
    {
        public HomeView2()
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

        private void btnUploadLALTE_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "LOS-ANGELES*";
            ofd.ShowDialog();
            txtBoxLALTE.Text = ofd.FileName;
        }

        private void btnUploadSiteMaster_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "SiteMaster*";
            ofd.ShowDialog();
            txtBoxSiteMaster.Text = ofd.FileName;
        }

        private void btnUploadWaterfall_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "Water*";
            ofd.ShowDialog();
            txtBoxWaterfall.Text = ofd.FileName;
        }

        private void btnClearLALTE_Click(object sender, EventArgs e)
        {
            txtBoxLALTE.Text = string.Empty;
        }

        private void btnClearSiteMaster_Click(object sender, EventArgs e)
        {
            txtBoxSiteMaster.Text = string.Empty;
        }

        private void btnClearWaterfall_Click(object sender, EventArgs e)
        {
            txtBoxWaterfall.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region LA LTE
            if (txtBoxLALTE.Text != string.Empty)
            {
                var filename = Path.GetFileName(txtBoxLALTE.Text);
                DeleteItemsInFolder(System.Windows.Forms.Application.StartupPath + "\\LA LTE\\");
                File.Copy(txtBoxLALTE.Text, System.Windows.Forms.Application.StartupPath + "\\LA LTE\\" + filename, true);
            }
            #endregion

            #region Site Master
            if (txtBoxSiteMaster.Text != string.Empty)
            {            
                var filename = Path.GetFileName(txtBoxSiteMaster.Text);
                string fileNameExcel = Path.GetFileNameWithoutExtension(filename);

                DeleteItemsInFolder(System.Windows.Forms.Application.StartupPath + "\\Site Master\\");

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = app.Workbooks.Open(txtBoxSiteMaster.Text, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.SaveAs(System.Windows.Forms.Application.StartupPath + "\\Site Master\\" + fileNameExcel +".xlsx", XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                wb.Close();
                app.Quit();

                //File.Copy(txtBoxSiteMaster.Text, System.Windows.Forms.Application.StartupPath + "\\Site Master\\" + filename, true);
            }
            #endregion

            #region Waterfall
            if (txtBoxWaterfall.Text != string.Empty)
            {
                var filename = Path.GetFileName(txtBoxWaterfall.Text);
                DeleteItemsInFolder(System.Windows.Forms.Application.StartupPath + "\\Waterfall\\");
                File.Copy(txtBoxWaterfall.Text, System.Windows.Forms.Application.StartupPath + "\\Waterfall\\" + filename, true);
            }
            #endregion

            if (txtBoxLALTE.Text == string.Empty && txtBoxSiteMaster.Text == string.Empty && txtBoxWaterfall.Text == string.Empty)
            {
                MessageBox.Show("No Files Uploaded.");
            }
            else
            {
                MessageBox.Show("Successfully Save.");
            }
        }
    }
}
