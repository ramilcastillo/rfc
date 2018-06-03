using ENMT_V2.Repository;
using ENMT_V2.Repository.Interface;
using System;
using System.Windows.Forms;

namespace ENMT_V2.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
            homeView11.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnHome.Height;
            panelLeft.Top = btnHome.Top;
            panelLibraries.Visible = false;
            homeView11.BringToFront();
            
        }

        private void btnModule1_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnProcess.Height;
            panelLeft.Top = btnProcess.Top;
            panelLibraries.Visible = false;
            process1.BringToFront();
        }

        private void btnLibraries_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnLibraries.Height;
            panelLeft.Top = btnLibraries.Top;
            panelLibraries.Visible = true;
            cI004WaterfallView11.BringToFront();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            panelLeft.Height = btnExport.Height;
            panelLeft.Top = btnExport.Top;
            panelLibraries.Visible = false;
        }

        private void btnCI004Waterfall_Click(object sender, EventArgs e)
        {
            cI004WaterfallView11.BringToFront();

            ICI004WaterfallRepository cWaterfall = new CI004WaterfallRepository();
            var file = cWaterfall.GetFilesFromPath();
            var listWaterfall = cWaterfall.GetListCI004Waterfall(file[0]);
            cI004WaterfallView11.cI004WaterfallView21.dgvCI004Waterfall.DataSource = listWaterfall;
        }

        private void btnCI004RFDS_Click(object sender, EventArgs e)
        {
            cI004RFDSView11.BringToFront();
        }

        private void btnLALTE_Click(object sender, EventArgs e)
        {
            lalteView11.BringToFront();

            ILALTERepository laLTE = new LALTERepository();
            var file = laLTE.GetFilesFromPath();
            var listWaterfall = laLTE.GetListLALTE(file[0]);
            lalteView11.lalteView21.dgvLALTE.DataSource = listWaterfall;
        }

        private void btnSiteMaster_Click(object sender, EventArgs e)
        {
            siteMasterView11.BringToFront();

            ISiteMasterRepository sitemaster = new SiteMasterRepository();
            var file = sitemaster.GetFilesFromPath();
            var listSiteMaster = sitemaster.GetListSiteMaster(file[0]);
            siteMasterView11.siteMasterView21.dgvSiteMaster.DataSource = listSiteMaster;
        }

        private void btnWaterfall_Click(object sender, EventArgs e)
        {
           waterfallView11.BringToFront();
        }
    }
}
