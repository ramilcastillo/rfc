using LinqToExcel.Attributes;

namespace ENMT_V2.Core.Model
{
    public class CI004_RFDS_MISSING_COORDINATES
    {
        [ExcelColumn("USID")]
        public string USID { get; set; }
        [ExcelColumn("RFDS NAME")]
        public string RFDS_NAME { get; set; }
        [ExcelColumn("Program Type")]
        public string PROGRAM_TYPE { get; set; }
        [ExcelColumn("Technology")]
        public string TECHNOLOGY { get; set; }
        [ExcelColumn("CARRIER *")]
        public string CARRIER { get; set; }
        [ExcelColumn("SECTOR *")]
        public string SECTOR { get; set; }
        [ExcelColumn("USEID")]
        public string USEID { get; set; }
        [ExcelColumn("RBS ID")]
        public string RBSID { get; set; }
        [ExcelColumn("DELETE SOFT SECTOR ?")]
        public string DELETE_SOFT_SECTOR { get; set; }
        [ExcelColumn("CTS COMMON ID *(Carrier association from Section 6 - reference only)")]
        public string CTS_COMMONID { get; set; }
        [ExcelColumn("SOFT SECTOR ID")]
        public string SOFT_SECTORID { get; set; }
        [ExcelColumn("CELL NUMBER * (LTE)")]
        public string CELL_NUMBER_LTE { get; set; }
        [ExcelColumn("CID SAC(GSM / UMTS ONLY)")]
        public string CID_SAC { get; set; }
        [ExcelColumn("RFDS ID")]
        public string RFDSID { get; set; }
        [ExcelColumn("Sitemaster")]
        public string SITEMASTER { get; set; }
        [ExcelColumn("Sector Latitude")]
        public string SECTOR_LATITUDE { get; set; }
        [ExcelColumn("Sector Longitude")]
        public string SECTOR_LONGITUDE { get; set; }
        [ExcelColumn("RBSS IsActive?")]
        public string RBSS_ISACTIVE { get; set; }
        [ExcelColumn("Remarks")]
        public string REMARKS { get; set; }
        [ExcelColumn("Spectrum Bucket")]
        public string SPECTRUM_BUCKET_1 { get; set; }
        [ExcelColumn("Spectrum Bucket_2")]
        public string SPECTRUM_BUCKET_2 { get; set; }
        [ExcelColumn("Spectrum_USID")]
        public string SPECTRUM_USID { get; set; }
    }
}
