using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;
using LinqToExcel;
using System.Linq;

namespace ENMT_V2.Repository
{
    public class CI004RFDSRepository : ICI004RFDSRepository
    {
        public string[] GetFilesFromPath()
        {
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\CI004_RDFS\\");
            return filePaths;
        }

        public IEnumerable<CI004_RFDS_NOT_IN_CSS> GetListCI004_RFDS_NOT_IN_CSS(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<CI004_RFDS_NOT_IN_CSS>("A1", "XFD1048576", 2) select s).ToList();

            //List<CI004_RFDS_NOT_IN_CSS> lstRFDS = new List<CI004_RFDS_NOT_IN_CSS>();
            //foreach (CI004_RFDS_NOT_IN_CSS item in query)
            //{
            //    lstRFDS.Add(new CI004_RFDS_NOT_IN_CSS
            //    {
            //        USID = item.USID,
            //        RFDS_NAME = item.RFDS_NAME,
            //        PROGRAM_TYPE = item.PROGRAM_TYPE,
            //        TECHNOLOGY = item.TECHNOLOGY,
            //        CARRIER = item.CARRIER,
            //        SECTOR = item.SECTOR,
            //        USEID = item.USEID,
            //        RBSID = item.RBSID,
            //        DELETE_SOFT_SECTOR = item.DELETE_SOFT_SECTOR,
            //        CTS_COMMONID = item.CTS_COMMONID,
            //        SOFT_SECTORID = item.SECTOR, 
            //        CELL_NUMBER_LTE = item.CELL_NUMBER_LTE,
            //        CID_SAC = item.CID_SAC,
            //        RFDSID = item.RFDSID,
            //        SITEMASTER = item.SITEMASTER,
            //        SECTOR_LATITUDE = item.SECTOR_LATITUDE,
            //        SECTOR_LONGITUDE = item.SECTOR_LONGITUDE,
            //        RBSS_ISACTIVE = item.RBSS_ISACTIVE,
            //        REMARKS = item.REMARKS,
            //        SPECTRUM_BUCKET_1 = item.SPECTRUM_BUCKET_1,
            //        SPECTRUM_BUCKET_2 = item.SPECTRUM_BUCKET_2,
            //        SPECTRUM_USID = item.SPECTRUM_USID
            //    });
            //}
            //return lstRFDS;
            return query;
        }

        public IEnumerable<CI004_RFDS_SECTOR_IN_CSS> GetListCI004_RFDS_SECTOR_IN_CSS(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<CI004_RFDS_SECTOR_IN_CSS>("A1", "XFD1048576", 3) select s).ToList();


            //List<CI004_RFDS_SECTOR_IN_CSS> lstRFDS = new List<CI004_RFDS_SECTOR_IN_CSS>();
            //foreach (CI004_RFDS_SECTOR_IN_CSS item in query)
            //{
            //    lstRFDS.Add(new CI004_RFDS_SECTOR_IN_CSS
            //    {
            //        USID = item.USID,
            //        RFDS_NAME = item.RFDS_NAME,
            //        PROGRAM_TYPE = item.PROGRAM_TYPE,
            //        TECHNOLOGY = item.TECHNOLOGY,
            //        CARRIER = item.CARRIER,
            //        SECTOR = item.SECTOR,
            //        USEID = item.USEID,
            //        RBSID = item.RBSID,
            //        DELETE_SOFT_SECTOR = item.DELETE_SOFT_SECTOR,
            //        CTS_COMMONID = item.CTS_COMMONID,
            //        SOFT_SECTORID = item.SECTOR,
            //        CELL_NUMBER_LTE = item.CELL_NUMBER_LTE,
            //        CID_SAC = item.CID_SAC,
            //        RFDSID = item.RFDSID,
            //        SITEMASTER = item.SITEMASTER,
            //        SECTOR_LATITUDE = item.SECTOR_LATITUDE,
            //        SECTOR_LONGITUDE = item.SECTOR_LONGITUDE,
            //        RBSS_ISACTIVE = item.RBSS_ISACTIVE,
            //        REMARKS = item.REMARKS,
            //        SPECTRUM_BUCKET_1 = item.SPECTRUM_BUCKET_1,
            //        SPECTRUM_BUCKET_2 = item.SPECTRUM_BUCKET_2,
            //        SPECTRUM_USID = item.SPECTRUM_USID
            //    });
            //}
            //return lstRFDS;
            return query;
        }
        public IEnumerable<CI004_RFDS_MISSING_COORDINATES> GetListCI004_RFDS_MISSING_COORDINATES(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<CI004_RFDS_MISSING_COORDINATES>("A1", "XFD1048576", 1) select s).ToList();


            //List<CI004_RFDS_MISSING_COORDINATES> lstRFDS = new List<CI004_RFDS_MISSING_COORDINATES>();
            //foreach (CI004_RFDS_MISSING_COORDINATES item in query)
            //{
            //    lstRFDS.Add(new CI004_RFDS_MISSING_COORDINATES
            //    {
            //        USID = item.USID,
            //        RFDS_NAME = item.RFDS_NAME,
            //        PROGRAM_TYPE = item.PROGRAM_TYPE,
            //        TECHNOLOGY = item.TECHNOLOGY,
            //        CARRIER = item.CARRIER,
            //        SECTOR = item.SECTOR,
            //        USEID = item.USEID,
            //        RBSID = item.RBSID,
            //        DELETE_SOFT_SECTOR = item.DELETE_SOFT_SECTOR,
            //        CTS_COMMONID = item.CTS_COMMONID,
            //        SOFT_SECTORID = item.SECTOR,
            //        CELL_NUMBER_LTE = item.CELL_NUMBER_LTE,
            //        CID_SAC = item.CID_SAC,
            //        RFDSID = item.RFDSID,
            //        SITEMASTER = item.SITEMASTER,
            //        SECTOR_LATITUDE = item.SECTOR_LATITUDE,
            //        SECTOR_LONGITUDE = item.SECTOR_LONGITUDE,
            //        RBSS_ISACTIVE = item.RBSS_ISACTIVE,
            //        REMARKS = item.REMARKS,
            //        SPECTRUM_BUCKET_1 = item.SPECTRUM_BUCKET_1,
            //        SPECTRUM_BUCKET_2 = item.SPECTRUM_BUCKET_2,
            //        SPECTRUM_USID = item.SPECTRUM_USID
            //    });
            //}
            //return lstRFDS;
            return query;
        }

        public IEnumerable<CI004_RFDS_DETAILS> GetListCI004_RFDS_DETAILS(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;

            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<CI004_RFDS_DETAILS>("A1", "XFD1048576", 0) select s).ToList();


            //List<CI004_RFDS_DETAILS> lstRFDS = new List<CI004_RFDS_DETAILS>();
            //foreach (CI004_RFDS_DETAILS item in query)
            //{
            //    lstRFDS.Add(new CI004_RFDS_DETAILS
            //    {
            //        USID = item.USID,
            //        RFDS_NAME = item.RFDS_NAME,
            //        PROGRAM_TYPE = item.PROGRAM_TYPE,
            //        TECHNOLOGY = item.TECHNOLOGY,
            //        CARRIER = item.CARRIER,
            //        SECTOR = item.SECTOR,
            //        USEID = item.USEID,
            //        RBSID = item.RBSID,
            //        DELETE_SOFT_SECTOR = item.DELETE_SOFT_SECTOR,
            //        CTS_COMMONID = item.CTS_COMMONID,
            //        SOFT_SECTORID = item.SECTOR,
            //        CELL_NUMBER_LTE = item.CELL_NUMBER_LTE,
            //        CID_SAC = item.CID_SAC,
            //        RFDSID = item.RFDSID,
            //        SITEMASTER = item.SITEMASTER,
            //        SECTOR_LATITUDE = item.SECTOR_LATITUDE,
            //        SECTOR_LONGITUDE = item.SECTOR_LONGITUDE,
            //        RBSS_ISACTIVE = item.RBSS_ISACTIVE,
            //        REMARKS = item.REMARKS,
            //        SPECTRUM_BUCKET_1 = item.SPECTRUM_BUCKET_1,
            //        SPECTRUM_BUCKET_2 = item.SPECTRUM_BUCKET_2,
            //        SPECTRUM_USID = item.SPECTRUM_USID
            //    });
            //}
            //return lstRFDS;
            return query;
        }
    }
}
