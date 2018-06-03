using LinqToExcel.Attributes;

namespace ENMT_V2.Core.Model
{
    public class CI004_Waterfall
    {
        [ExcelColumn("USID_SPECTRUM")]
        public string USID_SPECTRUM { get; set; }
        [ExcelColumn("PACE_NUMBER")]
        public string PACE_NUMBER { get; set; }
        [ExcelColumn("PACE_NUMBER")]
        public string SITE_NUMBER { get; set; }
        [ExcelColumn("PACE_NAME")]
        public string PACE_NAME { get; set; }
        [ExcelColumn("COUNTY")]
        public string COUNTY { get; set; }
        [ExcelColumn("PRODUCT_SUBGROUP")]
        public string PRODUCT_SUBGROUP { get; set; }
        [ExcelColumn("USID")]
        public string USID { get; set; }
        [ExcelColumn("CI004_FORECAST")]
        public string CI004_FORECAST { get; set; }
        [ExcelColumn("CI004_ACTUAL")]
        public string CI004_ACTUAL { get; set; }
        [ExcelColumn("CI003_FORECAST")]
        public string CI003_FORECAST { get; set; }
        [ExcelColumn("CI003_ACTUAL")]
        public string CI003_ACTUAL { get; set; }
        [ExcelColumn("SPECTRUM")]
        public string SPECTRUM { get; set; }
        [ExcelColumn("Funding_Level")]
        public string FUNDING_LEVEL { get; set; }
        [ExcelColumn("RFDS ID")]
        public string RFDS_ID { get; set; }
        [ExcelColumn("RFDS_State_Status")]
        public string RFDS_STATE_STATUS { get; set; }
        [ExcelColumn("Spectrum Bucket")]
        public string SPECTRUM_BUCKET { get; set; }
        [ExcelColumn("PLAN YEAR")]
        public string PLAN_YEAR { get; set; }
        [ExcelColumn("NOT_IN_CSS")]
        public string NOT_IN_CSS { get; set; }
        [ExcelColumn("MISSING COORDINATES")]
        public string MISSING_COORDINATES { get; set; }
        [ExcelColumn("SECTOR IN CSS, COORDINATES POPULATED")]
        public string SECTOR_IN_CSS { get; set; }
        [ExcelColumn("Final_Remarks")]
        public string FINAL_REMARKS { get; set; }
    }
}
