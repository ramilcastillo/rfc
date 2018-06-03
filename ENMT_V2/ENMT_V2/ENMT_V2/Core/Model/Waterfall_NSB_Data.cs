using LinqToExcel.Attributes;

namespace ENMT_V2.Core.Model
{
    public class Waterfall_NSB_Data
    {
        [ExcelColumn("PACE_NUMBER")]
        public string PACE_NUMBER { get; set; }
        [ExcelColumn("SITE_ID")]
        public string SITE_ID { get; set; }
        [ExcelColumn("Primary_Job_Number")]
        public string Primary_Job_Number { get; set; }
        [ExcelColumn("PACE_NAME")]
        public string PACE_NAME { get; set; }
        [ExcelColumn("SEARCH_RING_ID")]
        public string SEARCH_RING_ID { get; set; }
        [ExcelColumn("SEARCH_RING_NAME")]
        public string SEARCH_RING_NAME { get; set; }
        [ExcelColumn("Dist_Zone")]
        public string Dist_Zone { get; set; }
        [ExcelColumn("COUNTY")]
        public string COUNTY { get; set; }
        [ExcelColumn("FIPS_CODE")]
        public string FIPS_CODE { get; set; }
        [ExcelColumn("LATITUDE")]
        public string LATITUDE { get; set; }
        [ExcelColumn("LONGITUDE")]
        public string LONGITUDE { get; set; }
        [ExcelColumn("PRODUCT_GROUP")]
        public string PRODUCT_GROUP { get; set; }
        [ExcelColumn("PRODUCT_SUBGROUP")]
        public string PRODUCT_SUBGROUP { get; set; }
        [ExcelColumn("CFAS_PROJECT_NUMBER")]
        public string CFAS_PROJECT_NUMBER { get; set; }
        [ExcelColumn("SOURCE_JOB_NUMBER")]
        public string SOURCE_JOB_NUMBER { get; set; }
        [ExcelColumn("IPLAN_JOB_STATUS")]
        public string IPLAN_JOB_STATUS { get; set; }
        [ExcelColumn("USID")]
        public string USID { get; set; }
        [ExcelColumn("CONSTRUCTION_TYPE")]
        public string CONSTRUCTION_TYPE { get; set; }
        [ExcelColumn("STATUS")]
        public string STATUS { get; set; }
        [ExcelColumn("NATIONAL_PROGRAM")]
        public string NATIONAL_PROGRAM { get; set; }
        [ExcelColumn("JOB_TYPE_SUBTYPE")]
        public string JOB_TYPE_SUBTYPE { get; set; }
        [ExcelColumn("CAPITAL_PROGRAM")]
        public string CAPITAL_PROGRAM { get; set; }
        [ExcelColumn("TECHNOLOGY")]
        public string TECHNOLOGY { get; set; }
        [ExcelColumn("FREQUENCY")]
        public string FREQUENCY { get; set; }
        [ExcelColumn("RBS_ID")]
        public string RBS_ID { get; set; }
        [ExcelColumn("REGIONFRANCHISE_INDICATOR")]
        public string REGIONFRANCHISE_INDICATOR { get; set; }
        [ExcelColumn("STRATEGIC_DRIVER")]
        public string STRATEGIC_DRIVER { get; set; }
        [ExcelColumn("BUDGET_YEAR")]
        public string BUDGET_YEAR { get; set; }
        [ExcelColumn("CIVIL_VENDOR")]
        public string CIVIL_VENDOR { get; set; }
        [ExcelColumn("SITE_ACQUISITION_VENDOR")]
        public string SITE_ACQUISITION_VENDOR { get; set; }
        [ExcelColumn("EQUIPMENT_VENDOR")]
        public string EQUIPMENT_VENDOR { get; set; }
        [ExcelColumn("JOB_VENDOR")]
        public string JOB_VENDOR { get; set; }
        [ExcelColumn("custom_program")]
        public string custom_program { get; set; }
        [ExcelColumn("TEMPLATE_NAME")]
        public string TEMPLATE_NAME { get; set; }
        [ExcelColumn("JOB_SCOPE")]
        public string JOB_SCOPE { get; set; }
        [ExcelColumn("ORACLE_PTN")]
        public string ORACLE_PTN { get; set; }
        [ExcelColumn("LAUNCH_POLYGON")]
        public string LAUNCH_POLYGON { get; set; }
        [ExcelColumn("PHASE")]
        public string PHASE { get; set; }
        [ExcelColumn("PROJECT_MANAGER")]
        public string PROJECT_MANAGER { get; set; }
        [ExcelColumn("AREA_MANAGER")]
        public string AREA_MANAGER { get; set; }
        [ExcelColumn("WORK_GROUP")]
        public string WORK_GROUP { get; set; }
        [ExcelColumn("PM2_Person")]
        public string PM2_Person { get; set; }
        [ExcelColumn("PM3_Person")]
        public string PM3_Person { get; set; }
        [ExcelColumn("FA_LOCATION_CODE")]
        public string FA_LOCATION_CODE { get; set; }
        [ExcelColumn("FA_LOCATION_TYPE")]
        public string FA_LOCATION_TYPE { get; set; }
        [ExcelColumn("C_E_ON_AIR_DATE")]
        public string C_E_ON_AIR_DATE { get; set; }
        [ExcelColumn("ORIGINAL_NEED_BY_DATE")]
        public string ORIGINAL_NEED_BY_DATE { get; set; }
        [ExcelColumn("CURRENT_NEED_BY_DATE")]
        public string CURRENT_NEED_BY_DATE { get; set; }
        [ExcelColumn("COMMITTED_POR_ONAIRDATE")]
        public string COMMITTED_POR_ONAIRDATE { get; set; }
        [ExcelColumn("ADDRESS")]
        public string ADDRESS { get; set; }
        [ExcelColumn("POLYGON_JID")]
        public string POLYGON_JID { get; set; }
        [ExcelColumn("TRANSPORT_TYPE")]
        public string TRANSPORT_TYPE { get; set; }
        [ExcelColumn("POE_Name")]
        public string POE_Name { get; set; }
        [ExcelColumn("POR_Name")]
        public string POR_Name { get; set; }
        [ExcelColumn("POE_Status")]
        public string POE_Status { get; set; }
        [ExcelColumn("POR_Status")]
        public string POR_Status { get; set; }
        [ExcelColumn("POR_ONAIR_PLAN")]
        public string POR_ONAIR_PLAN { get; set; }
        [ExcelColumn("CASPR_PROJECT_SEQ")]
        public string CASPR_PROJECT_SEQ { get; set; }
        [ExcelColumn("CASPR_PROJECT_NUMBER")]
        public string CASPR_PROJECT_NUMBER { get; set; }
        [ExcelColumn("Jurisdiction")]
        public string Jurisdiction { get; set; }
        [ExcelColumn("ACTUAL_ISSUE_DATE")]
        public string ACTUAL_ISSUE_DATE { get; set; }
        [ExcelColumn("ISSUE_DATE_ORIGINAL_ACTUAL")]
        public string ISSUE_DATE_ORIGINAL_ACTUAL { get; set; }
        [ExcelColumn("SS019_FORECAST")]
        public string SS019_FORECAST { get; set; }
        [ExcelColumn("SS019_ACTUAL")]
        public string SS019_ACTUAL { get; set; }
        [ExcelColumn("SS059_FORECAST")]
        public string SS059_FORECAST { get; set; }
        [ExcelColumn("SS059_ACTUAL")]
        public string SS059_ACTUAL { get; set; }
        [ExcelColumn("SS055_FORECAST")]
        public string SS055_FORECAST { get; set; }
        [ExcelColumn("SS055_ACTUAL")]
        public string SS055_ACTUAL { get; set; }
        [ExcelColumn("SS010_FORECAST")]
        public string SS010_FORECAST { get; set; }
        [ExcelColumn("SS010_ACTUAL")]
        public string SS010_ACTUAL { get; set; }
        [ExcelColumn("SS002_ACTUAL")]
        public string SS002_FORECAST { get; set; }
        [ExcelColumn("SS002_ACTUAL")]
        public string SS002_ACTUAL { get; set; }
        [ExcelColumn("SS011_FORECAST")]
        public string SS011_FORECAST { get; set; }
        [ExcelColumn("SS011_ACTUAL")]
        public string SS011_ACTUAL { get; set; }
        [ExcelColumn("SS009_FORECAST")]
        public string SS009_FORECAST { get; set; }
        [ExcelColumn("SS009_ACTUAL")]
        public string SS009_ACTUAL { get; set; }
        [ExcelColumn("SS020_FORECAST")]
        public string SS020_FORECAST { get; set; }
        [ExcelColumn("SS020_ACTUAL")]
        public string SS020_ACTUAL { get; set; }
        [ExcelColumn("RE015_FORECAST")]
        public string RE015_FORECAST { get; set; }
        [ExcelColumn("RE015_ACTUAL")]
        public string RE015_ACTUAL { get; set; }
        [ExcelColumn("RE046_FORECAST")]
        public string RE046_FORECAST { get; set; }
        [ExcelColumn("RE046_ACTUAL")]
        public string RE046_ACTUAL { get; set; }
        [ExcelColumn("RE047_FORECAST")]
        public string RE047_FORECAST { get; set; }
        [ExcelColumn("RE047_ACTUAL")]
        public string RE047_ACTUAL { get; set; }
        [ExcelColumn("RE005_FORECAST")]
        public string RE005_FORECAST { get; set; }
        [ExcelColumn("RE005_ACTUAL")]
        public string RE005_ACTUAL { get; set; }
        [ExcelColumn("1/2/1900")]
        public string _1_2_1900 { get; set; }
        [ExcelColumn("RE066_ACTUAL")]
        public string RE066_ACTUAL { get; set; }
        [ExcelColumn("RE055_FORECAST")]
        public string RE055_FORECAST { get; set; }
        [ExcelColumn("RE055_ACTUAL")]
        public string RE055_ACTUAL { get; set; }
        [ExcelColumn("RE030_FORECAST")]
        public string RE030_FORECAST { get; set; }
        [ExcelColumn("RE030_ACTUAL")]
        public string RE030_ACTUAL { get; set; }
        [ExcelColumn("CI004_FORECAST")]
        public string CI004_FORECAST { get; set; }
        [ExcelColumn("CI004_ACTUAL")]
        public string CI004_ACTUAL { get; set; }
        [ExcelColumn("RE056_FORECAST")]
        public string RE056_FORECAST { get; set; }
        [ExcelColumn("RE056_ACTUAL")]
        public string RE056_ACTUAL { get; set; }
        [ExcelColumn("RE001_FORECAST")]
        public string RE001_FORECAST { get; set; }
        [ExcelColumn("RE001_ACTUAL")]
        public string RE001_ACTUAL { get; set; }
        [ExcelColumn("RE031_FORECAST")]
        public string RE031_FORECAST { get; set; }
        [ExcelColumn("RE031_ACTUAL")]
        public string RE031_ACTUAL { get; set; }
        [ExcelColumn("RE032_FORECAST")]
        public string RE032_FORECAST { get; set; }
        [ExcelColumn("RE032_ACTUAL")]
        public string RE032_ACTUAL { get; set; }
        [ExcelColumn("CI026_FORECAST")]
        public string CI026_FORECAST { get; set; }
        [ExcelColumn("CI026_ACTUAL")]
        public string CI026_ACTUAL { get; set; }
        [ExcelColumn("RE020_FORECAST")]
        public string RE020_FORECAST { get; set; }
        [ExcelColumn("RE020_ACTUAL")]
        public string RE020_ACTUAL { get; set; }
        [ExcelColumn("RE060_FORECAST")]
        public string RE060_FORECAST { get; set; }
        [ExcelColumn("RE060_ACTUAL")]
        public string RE060_ACTUAL { get; set; }
        [ExcelColumn("CI025_FORECAST")]
        public string CI025_FORECAST { get; set; }
        [ExcelColumn("CI025_ACTUAL")]
        public string CI025_ACTUAL { get; set; }
        [ExcelColumn("CI038_FORECAST")]
        public string CI038_FORECAST { get; set; }
        [ExcelColumn("CI038_ACTUAL")]
        public string CI038_ACTUAL { get; set; }
        [ExcelColumn("CI001_FORECAST")]
        public string CI001_FORECAST { get; set; }
        [ExcelColumn("CI001_ACTUAL")]
        public string CI001_ACTUAL { get; set; }
        [ExcelColumn("CI042_FORECAST")]
        public string CI042_FORECAST { get; set; }
        [ExcelColumn("CI042_ACTUAL")]
        public string CI042_ACTUAL { get; set; }
        [ExcelColumn("CI060_FORECAST")]
        public string CI060_FORECAST { get; set; }
        [ExcelColumn("CI060_ACTUAL")]
        public string CI060_ACTUAL { get; set; }
        [ExcelColumn("CI046_FORECAST")]
        public string CI046_FORECAST { get; set; }
        [ExcelColumn("CI046_ACTUAL")]
        public string CI046_ACTUAL { get; set; }
        [ExcelColumn("CI048_FORECAST")]
        public string CI048_FORECAST { get; set; }
        [ExcelColumn("CI048_ACTUAL")]
        public string CI048_ACTUAL { get; set; }
        [ExcelColumn("CI034_FORECAST")]
        public string CI034_FORECAST { get; set; }
        [ExcelColumn("CI034_ACTUAL")]
        public string CI034_ACTUAL { get; set; }
        [ExcelColumn("CI045_FORECAST")]
        public string CI045_FORECAST { get; set; }
        [ExcelColumn("CI045_ACTUAL")]
        public string CI045_ACTUAL { get; set; }
        [ExcelColumn("CI020_FORECAST")]
        public string CI020_FORECAST { get; set; }
        [ExcelColumn("CI020_ACTUAL")]
        public string CI020_ACTUAL { get; set; }
        [ExcelColumn("CI018_FORECAST")]
        public string CI018_FORECAST { get; set; }
        [ExcelColumn("CI018_ACTUAL")]
        public string CI018_ACTUAL { get; set; }
        [ExcelColumn("CI014_FORECAST")]
        public string CI014_FORECAST { get; set; }
        [ExcelColumn("CI014_ACTUAL")]
        public string CI014_ACTUAL { get; set; }
        [ExcelColumn("CI050_FORECAST")]
        public string CI050_FORECAST { get; set; }
        [ExcelColumn("CI050_ACTUAL")]
        public string CI050_ACTUAL { get; set; }
        [ExcelColumn("CI110_FORECAST")]
        public string CI110_FORECAST { get; set; }
        [ExcelColumn("CI110_ACTUAL")]
        public string CI110_ACTUAL { get; set; }
        [ExcelColumn("CI010_FORECAST")]
        public string CI010_FORECAST { get; set; }
        [ExcelColumn("CI010_ACTUAL")]
        public string CI010_ACTUAL { get; set; }
        [ExcelColumn("CI035_FORECAST")]
        public string CI035_FORECAST { get; set; }
        [ExcelColumn("CI035_ACTUAL")]
        public string CI035_ACTUAL { get; set; }
        [ExcelColumn("CI019_FORECAST")]
        public string CI019_FORECAST { get; set; }
        [ExcelColumn("CI019_ACTUAL")]
        public string CI019_ACTUAL { get; set; }
        [ExcelColumn("CI173_FORECAST")]
        public string CI173_FORECAST { get; set; }
        [ExcelColumn("CI173_ACTUAL")]
        public string CI173_ACTUAL { get; set; }
        [ExcelColumn("CI030_FORECAST")]
        public string CI030_FORECAST { get; set; }
        [ExcelColumn("CI030_ACTUAL")]
        public string CI030_ACTUAL { get; set; }
        [ExcelColumn("CI031_FORECAST")]
        public string CI031_FORECAST { get; set; }
        [ExcelColumn("CI031_ACTUAL")]
        public string CI031_ACTUAL { get; set; }
        [ExcelColumn("CI032_FORECAST")]
        public string CI032_FORECAST { get; set; }
        [ExcelColumn("CI032_ACTUAL")]
        public string CI032_ACTUAL { get; set; }
        [ExcelColumn("ONAIR_TASK")]
        public string ONAIR_TASK { get; set; }
        [ExcelColumn("ONAIR_PLAN")]
        public string ONAIR_PLAN { get; set; }
        [ExcelColumn("ONAIR_FORECAST")]
        public string ONAIR_FORECAST { get; set; }
        [ExcelColumn("ONAIR_ACTUAL")]
        public string ONAIR_ACTUAL { get; set; }
        [ExcelColumn("CL001_FORECAST")]
        public string CL001_FORECAST { get; set; }
        [ExcelColumn("CL001_ACTUAL")]
        public string CL001_ACTUAL { get; set; }
        [ExcelColumn("CL100_FORECAST")]
        public string CL100_FORECAST { get; set; }
        [ExcelColumn("CL100_ACTUAL")]
        public string CL100_ACTUAL { get; set; }
        [ExcelColumn("PLAN-FC_On_Air")]
        public string PLAN_FC_On_Air { get; set; }
        [ExcelColumn("NSB RANKING")]
        public string NSB_RANKING { get; set; }
        [ExcelColumn("Funding_Level")]
        public string Funding_Level { get; set; }
        [ExcelColumn("SPECTRUM")]
        public string SPECTRUM { get; set; }
        [ExcelColumn("AFTRCC_Status")]
        public string AFTRCC_Status { get; set; }
        [ExcelColumn("AFTRCC_Submit")]
        public string AFTRCC_Submit { get; set; }
        [ExcelColumn("RFDS ID")]
        public string RFDS_ID{ get; set; }
        [ExcelColumn("RFDS_State_Status")]
        public string RFDS_State_Status { get; set; }
        [ExcelColumn("RFDS Workflow Owner")]
        public string RFDS_Workflow_Owner { get; set; }
        [ExcelColumn("Submission Status_Validation Ranking")]
        public string Submission_Status_Validation_Ranking { get; set; }
        [ExcelColumn("Site Submission Status")]
        public string Site_Submission_Status { get; set; }
        [ExcelColumn("EDP_Publish_Date")]
        public string EDP_Publish_Date { get; set; }
        [ExcelColumn("EDP_STATUS")]
        public string EDP_STATUS { get; set; }
        [ExcelColumn("High_Trust")]
        public string High_Trust { get; set; }
        [ExcelColumn("MOD_Code")]
        public string MOD_Code { get; set; }
        [ExcelColumn("MODCD_Parity_Flag")]
        public string MODCD_Parity_Flag { get; set; }
        [ExcelColumn("EXECUTED_ON")]
        public string EXECUTED_ON { get; set; }
        [ExcelColumn("Carrier Count")]
        public string Carrier_Count{ get; set; }
        [ExcelColumn("Spectrum Bucket")]
        public string Spectrum_Bucket { get; set; }
        [ExcelColumn("Funding_Level_Handle")]
        public string Funding_Level_Handle { get; set; }
        [ExcelColumn("Temp")]
        public string Temp { get; set; }
        [ExcelColumn("Temp 2")]
        public string Temp_2 { get; set; }














}
}
