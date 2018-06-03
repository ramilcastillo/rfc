using ENMT_V2.Repository;
using ENMT_V2.Repository.Interface;
using System;
using System.Windows.Forms;

namespace ENMT_V2.App.Library.Resources
{
    public partial class CI004RFDSView1 : UserControl
    {
        private object cWaterfall;

        public CI004RFDSView1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBoxStatus.Text == "NOT IN CSS")
            {
                DisplayNOTINCSS();
            }
            else if (cmBoxStatus.Text == "SECTOR IN CSS")
            {
                DisplaySECTORINCSS();
            }
            else if (cmBoxStatus.Text == "MISSING COORDINATES")
            {
                DisplayMISSINGCOORDINATES();
            }
            else if (cmBoxStatus.Text == "DETAILS")
            {
                DisplayDETAILS();
            }
        }
        public void DisplayNOTINCSS()
        {
            ICI004RFDSRepository crfds = new CI004RFDSRepository();
            var file = crfds.GetFilesFromPath();
            var listrfds = crfds.GetListCI004_RFDS_NOT_IN_CSS(file[0]);
            cI004RFDSView21.dgvCI004RFDS.DataSource = listrfds;
        }

        public void DisplaySECTORINCSS()
        {
            ICI004RFDSRepository crfds = new CI004RFDSRepository();
            var file = crfds.GetFilesFromPath();
            var listrfds = crfds.GetListCI004_RFDS_SECTOR_IN_CSS(file[0]);
            cI004RFDSView21.dgvCI004RFDS.DataSource = listrfds;
        }

        public void DisplayMISSINGCOORDINATES()
        {
            ICI004RFDSRepository crfds = new CI004RFDSRepository();
            var file = crfds.GetFilesFromPath();
            var listrfds = crfds.GetListCI004_RFDS_MISSING_COORDINATES(file[0]);
            cI004RFDSView21.dgvCI004RFDS.DataSource = listrfds;
        }
        public void DisplayDETAILS()
        {
            ICI004RFDSRepository crfds = new CI004RFDSRepository();
            var file = crfds.GetFilesFromPath();
            var listrfds = crfds.GetListCI004_RFDS_DETAILS(file[0]);
            cI004RFDSView21.dgvCI004RFDS.DataSource = listrfds;
        }
    }
}
