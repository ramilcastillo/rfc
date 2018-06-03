using ENMT_V2.Repository;
using ENMT_V2.Repository.Interface;
using System;
using System.Windows.Forms;
using System.Linq;
using ENMT_V2.Core.ViewModel;

namespace ENMT_V2.App.Process
{
    public partial class Process1 : UserControl
    {
        public Process1()
        {
            InitializeComponent();
        }

        private void btnGetRFDSID_Click(object sender, EventArgs e)
        {
            IWaterfallRepository waterfall = new WaterfallRepository();
            var file = waterfall.GetFilesFromPath();
            var listWaterfall = waterfall.GetListWaterfall_Imp_Data(file[0]);
            var listRFDSID = listWaterfall.Select(s=> new Process1RFDS_ViewModel {
                RFDS_ID = s.RFDS_ID
            }).ToList();

            dgvProcess1.DataSource = listRFDSID;
        }
    }
}
