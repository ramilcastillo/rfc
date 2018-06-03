using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;
using LinqToExcel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ENMT_V2.Repository
{
    public class LALTERepository : ILALTERepository
    {
        public string[] GetFilesFromPath()
        {
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\LA LTE\\");
            return filePaths;
        }

        public IEnumerable<LALTE> GetListLALTE(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<LALTE>("A2", "XFD1048576", 0) select s).ToList();

            return query;
            //List<LALTE> lstLALTE = new List<LALTE>();
            //foreach (LALTE item in query)
            //{
            //    lstLALTE.Add(new LALTE
            //    {
            //        _118d_5m_20_54004s = item._118d_5m_20_54004s,
            //        Section5_E911Information = item.Section5_E911Information,
            //        USID = item.USID,
            //        RFDS_NAME = item.RFDS_NAME,
            //        Program_Type = item.Program_Type,
            //        Technology = item.Technology,
            //        SECTOR = item.SECTOR,
            //        PSAP_ID = item.PSAP_ID,
            //        E911_PHASE = item.E911_PHASE,
            //        LMU_REQUIRED = item.LMU_REQUIRED,
            //        ESRN = item.ESRN,
            //        DATE_LIVE_PH1 = item.DATE_LIVE_PH1,
            //        DATE_LIVE_PH2 = item.DATE_LIVE_PH2,
            //        RFDS_ID = item.RFDS_ID,
            //        _188167 = item._188167,
            //        CLL02285 = item.CLL02285,
            //        LTE_Next_Carrier_2018 = item.LTE_Next_Carrier_2018,
            //        EAST_MISSION_DRIVE_841 = item.EAST_MISSION_DRIVE_841,
            //        SAN_GABRIEL = item.SAN_GABRIEL,
            //        _91776 = item._91776,
            //        _34d_5m25_81008s = item._34d_5m25_81008s
            //    });
            //}
            //return lstLALTE;
        }
    }
}
