using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENMT_V2.Repository.Interface;
using ENMT_V2.Repository;

namespace ENMT_V2.App.Library.Resources
{
    public partial class WaterfallView1 : UserControl
    {
        public WaterfallView1()
        {
            InitializeComponent();
        }

        private void cmBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBoxStatus.Text == "Imp_Data")
            {
                Display_Imp_Data();
            }
            else if (cmBoxStatus.Text == "NSB_Data")
            {
                Display_NSB_Data();
            }

        }

        public void Display_Imp_Data()
        {
            IWaterfallRepository waterfall = new WaterfallRepository ();
            var file = waterfall.GetFilesFromPath();
            var listWaterfall = waterfall.GetListWaterfall_Imp_Data(file[0]);
            waterfallView21.dgvWaterfall.DataSource = listWaterfall;
        }

        public void Display_NSB_Data()
        {
            IWaterfallRepository waterfall = new WaterfallRepository();
            var file = waterfall.GetFilesFromPath();
            var listWaterfall = waterfall.GetListWaterfall_NSB_Data(file[0]);
            waterfallView21.dgvWaterfall.DataSource = listWaterfall;
        }
    }
}
