using LinqToExcel.Attributes;

namespace ENMT_V2.Core.Model
{
    public class Waterfall_Imp_Data
    {
        [ExcelColumn("PACE_NUMBER")]
        public string PACE_NUMBER { get; set; }
        [ExcelColumn("SITE_ID")]
        public string SITE_ID { get; set; }
        [ExcelColumn("PRIMARY_JOB_NUMBER")]
        public string PRIMARY_JOB_NUMBER { get; set; }
        [ExcelColumn("PACE_NAME")]
        public string PACE_NAME { get; set; }
        [ExcelColumn("THIRD_PARTY_OWNERS")]
        public string THIRD_PARTY_OWNERS { get; set; }
        [ExcelColumn("STRUCTURE_TYPE")]
        public string STRUCTURE_TYPE { get; set; }
        [ExcelColumn("DIST_ZONE")]
        public string DIST_ZONE { get; set; }
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
        [ExcelColumn("RBS_ID")]
        public string RBS_ID { get; set; }
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
        [ExcelColumn("INTEGRATION_VENDOR")]
        public string INTEGRATION_VENDOR { get; set; }
        [ExcelColumn("OPTIMIZATION_VENDOR")]
        public string OPTIMIZATION_VENDOR { get; set; }
        [ExcelColumn("CUSTOM_PROGRAM")]
        public string CUSTOM_PROGRAM { get; set; }
        [ExcelColumn("TEMPLATE_NAME")]
        public string TEMPLATE_NAME { get; set; }
        [ExcelColumn("JOB_SCOPE")]
        public string JOB_SCOPE { get; set; }
        [ExcelColumn("ORACLE_PTN")]
        public string ORACLE_PTN { get; set; }
        [ExcelColumn("PROJECT_MANAGER")]
        public string PROJECT_MANAGER { get; set; }
        [ExcelColumn("SAQ_Area_Manager")]
        public string SAQ_Area_Manager { get; set; }
        [ExcelColumn("WORK_GROUP")]
        public string WORK_GROUP { get; set; }
        [ExcelColumn("PM2_PERSON")]
        public string PM2_PERSON { get; set; }
        [ExcelColumn("PM3_PERSON")]
        public string PM3_PERSON { get; set; }
        [ExcelColumn("CX_AREA_MANAGER")]
        public string CX_AREA_MANAGER { get; set; }
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
        [ExcelColumn("ACTUAL_ISSUE_DATE")]
        public string ACTUAL_ISSUE_DATE { get; set; }
        [ExcelColumn("JI009_FORECAST")]
        public string JI009_FORECAST { get; set; }
        [ExcelColumn("JI009_ACTUAL")]
        public string JI009_ACTUAL { get; set; }
        [ExcelColumn("SS076_FORECAST")]
        public string SS076_FORECAST { get; set; }
        [ExcelColumn("SS076_ACTUAL")]
        public string SS076_ACTUAL { get; set; }
        [ExcelColumn("BDM_Status")]
        public string BDM_Status { get; set; }
        [ExcelColumn("BDM_Completed_Date")]
        public string BDM_Completed_Date { get; set; }
        [ExcelColumn("SS014_FORECAST")]
        public string SS014_FORECAST { get; set; }
        [ExcelColumn("SS014_ACTUAL")]
        public string SS014_ACTUAL { get; set; }
        [ExcelColumn("SS020_FORECAST")]
        public string SS020_FORECAST { get; set; }
        [ExcelColumn("SS020_ACTUAL")]
        public string SS020_ACTUAL { get; set; }
        [ExcelColumn("CI004_FORECAST")]
        public string CI004_FORECAST { get; set; }
        [ExcelColumn("CI004_ACTUAL")]
        public string CI004_ACTUAL { get; set; }
        [ExcelColumn("RE007_FORECAST")]
        public string RE007_FORECAST { get; set; }
        [ExcelColumn("RE007_ACTUAL")]
        public string RE007_ACTUAL { get; set; }
        [ExcelColumn("SS099_FORECAST")]
        public string SS099_FORECAST { get; set; }
        [ExcelColumn("SSO99_ACTUAL")]
        public string SSO99_ACTUAL { get; set; }
        [ExcelColumn("SS100_FORECAST")]
        public string SS100_FORECAST { get; set; }
        [ExcelColumn("SS100_ACTUAL")]
        public string SS100_ACTUAL { get; set; }
        [ExcelColumn("SS101_FORECAST")]
        public string SS101_FORECAST { get; set; }
        [ExcelColumn("SS101_ACTUAL")]
        public string SS101_ACTUAL { get; set; }
        [ExcelColumn("SS102_FORECAST")]
        public string SS102_FORECAST { get; set; }
        [ExcelColumn("SS102_ACTUAL")]
        public string SS102_ACTUAL { get; set; }
        [ExcelColumn("SS007_FORECAST")]
        public string SS007_FORECAST { get; set; }
        [ExcelColumn("SS007_ACTUAL")]
        public string SS007_ACTUAL { get; set; }
        [ExcelColumn("SS071_FORECAST")]
        public string SS071_FORECAST { get; set; }
        [ExcelColumn("SS071_ACTUAL")]
        public string SS071_ACTUAL { get; set; }
        [ExcelColumn("RE057_FORECAST")]
        public string RE057_FORECAST { get; set; }
        [ExcelColumn("RE057_ACTUAL")]
        public string RE057_ACTUAL { get; set; }
        [ExcelColumn("RE005_FORECAST")]
        public string RE005_FORECAST { get; set; }
        [ExcelColumn("RE005_ACTUAL")]
        public string RE005_ACTUAL { get; set; }
        [ExcelColumn("RE066_FORECAST")]
        public string RE066_FORECAST { get; set; }
        [ExcelColumn("RE066_ACTUAL")]
        public string RE066_ACTUAL { get; set; }
        [ExcelColumn("RE030_FORECAST")]
        public string RE030_FORECAST { get; set; }
        [ExcelColumn("RE030_ACTUAL")]
        public string RE030_ACTUAL { get; set; }
        [ExcelColumn("RE015_FORECAST")]
        public string RE015_FORECAST { get; set; }
        [ExcelColumn("RE015_ACTUAL")]
        public string RE015_ACTUAL { get; set; }
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
        [ExcelColumn("RE020_FORECAST")]
        public string RE020_FORECAST { get; set; }
        [ExcelColumn("RE020_ACTUAL")]
        public string RE020_ACTUAL { get; set; }
        [ExcelColumn("RE097_FORECAST")]
        public string RE097_FORECAST { get; set; }
        [ExcelColumn("RE097_ACTUAL")]
        public string RE097_ACTUAL { get; set; }
        [ExcelColumn("RE060_FORECAST")]
        public string RE060_FORECAST { get; set; }
        [ExcelColumn("RE060_ACTUAL")]
        public string RE060_ACTUAL { get; set; }
        [ExcelColumn("CI025_FORECAST")]
        public string CI025_FORECAST { get; set; }
        [ExcelColumn("CI025_ACTUAL")]
        public string CI025_ACTUAL { get; set; }
        [ExcelColumn("CI060_FORECAST")]
        public string CI060_FORECAST { get; set; }
        [ExcelColumn("CI060_ACTUAL")]
        public string CI060_ACTUAL { get; set; }
        [ExcelColumn("EPL_ProjectBucket01")]
        public string EPL_ProjectBucket01 { get; set; }
        [ExcelColumn("Max_CED_for_Project")]
        public string Max_CED_for_Project { get; set; }
        [ExcelColumn("Max_CED_Bucket")]
        public string Max_CED_Bucket { get; set; }
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
        [ExcelColumn("CI020_FORECAST")]
        public string CI020_FORECAST { get; set; }
        [ExcelColumn("CI020_ACTUAL")]
        public string CI020_ACTUAL { get; set; }
        [ExcelColumn("TRANSPORT_FORECAST")]
        public string TRANSPORT_FORECAST { get; set; }
        [ExcelColumn("TRANSPORT_ACTUAL")]
        public string TRANSPORT_ACTUAL { get; set; }
        [ExcelColumn("EDP_Publish_Date")]
        public string EDP_Publish_Date { get; set; }
        [ExcelColumn("EDP_STATUS")]
        public string EDP_STATUS { get; set; }
        [ExcelColumn("CONVERGED_Fcst")]
        public string CONVERGED_Fcst { get; set; }
        [ExcelColumn("CONVERGED_AC_ed")]
        public string CONVERGED_AC_ed { get; set; }
        [ExcelColumn("CI003_FORECAST")]
        public string CI003_FORECAST { get; set; }
        [ExcelColumn("CI003_ACTUAL")]
        public string CI003_ACTUAL { get; set; }
        [ExcelColumn("CI118_FORECAST")]
        public string CI118_FORECAST { get; set; }
        [ExcelColumn("CI118_ACTUAL")]
        public string CI118_ACTUAL { get; set; }
        [ExcelColumn("CI119_FORECAST")]
        public string CI119_FORECAST { get; set; }
        [ExcelColumn("CI119_ACTUAL")]
        public string CI119_ACTUAL { get; set; }
        [ExcelColumn("CI110_FORECAST")]
        public string CI110_FORECAST { get; set; }
        [ExcelColumn("CI110_ACTUAL")]
        public string CI110_ACTUAL { get; set; }
        [ExcelColumn("LCL_Category")]
        public string LCL_Category { get; set; }
        [ExcelColumn("iComply_Bucket")]
        public string iComply_Bucket { get; set; }
        [ExcelColumn("PSAP_Bucket")]
        public string PSAP_Bucket { get; set; }
        [ExcelColumn("PSAP_Comments")]
        public string PSAP_Comments { get; set; }
        [ExcelColumn("Submission_Status_Validation_Ranking")]
        public string Submission_Status_Validation_Ranking { get; set; }
        [ExcelColumn("Site_Submission_Status")]
        public string Site_Submission_Status { get; set; }
        [ExcelColumn("AFTRCC_Status")]
        public string AFTRCC_Status { get; set; }
        [ExcelColumn("AFTRCC_Submit")]
        public string AFTRCC_Submit { get; set; }
        [ExcelColumn("Filter_Info")]
        public string Filter_Info { get; set; }
        [ExcelColumn("CI035_CI010_FORECAST")]
        public string CI035_CI010_FORECAST { get; set; }
        [ExcelColumn("CI035_CI010_ACTUAL")]
        public string CI035_CI010_ACTUAL { get; set; }
        [ExcelColumn("CI166_FORECAST")]
        public string CI166_FORECAST { get; set; }
        [ExcelColumn("CI166_ACTUAL")]
        public string CI166_ACTUAL { get; set; }
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
        [ExcelColumn("CI149_FORECAST")]
        public string CI149_FORECAST { get; set; }
        [ExcelColumn("CI149_ACTUAL")]
        public string CI149_ACTUAL { get; set; }
        [ExcelColumn("CI216_FORECAST")]
        public string CI216_FORECAST { get; set; }
        [ExcelColumn("CI216_ACTUAL")]
        public string CI216_ACTUAL { get; set; }
        [ExcelColumn("CI217_FORECAST")]
        public string CI217_FORECAST { get; set; }
        [ExcelColumn("CI217_ACTUAL")]
        public string CI217_ACTUAL { get; set; }
        [ExcelColumn("ONAIR_TASK")]
        public string ONAIR_TASK { get; set; }
        [ExcelColumn("ONAIR_PLAN")]
        public string ONAIR_PLAN { get; set; }
        [ExcelColumn("ONAIR_FORECAST")]
        public string ONAIR_FORECAST { get; set; }
        [ExcelColumn("ONAIR_ACTUAL")]
        public string ONAIR_ACTUAL { get; set; }
        [ExcelColumn("CI139_FORECAST")]
        public string CI139_FORECAST { get; set; }
        [ExcelColumn("CI139_ACTUAL")]
        public string CI139_ACTUAL { get; set; }
        [ExcelColumn("CI140_FORECAST")]
        public string CI140_FORECAST { get; set; }
        [ExcelColumn("CI140_ACTUAL")]
        public string CI140_ACTUAL { get; set; }
        [ExcelColumn("CI050_FORECAST")]
        public string CI050_FORECAST { get; set; }
        [ExcelColumn("CI050_ACTUAL")]
        public string CI050_ACTUAL { get; set; }
        [ExcelColumn("CL001_FORECAST")]
        public string CL001_FORECAST { get; set; }
        [ExcelColumn("CL001_ACTUAL")]
        public string CL001_ACTUAL { get; set; }
        [ExcelColumn("CL100_FORECAST")]
        public string CL100_FORECAST { get; set; }
        [ExcelColumn("CL100_ACTUAL")]
        public string CL100_ACTUAL { get; set; }
        [ExcelColumn("CL101_FORECAST")]
        public string CL101_FORECAST { get; set; }
        [ExcelColumn("CL101_ACTUAL")]
        public string CL101_ACTUAL { get; set; }
        [ExcelColumn("PLAN_FC_On_Air")]
        public string PLAN_FC_On_Air { get; set; }
        [ExcelColumn("SPECTRUM")]
        public string SPECTRUM { get; set; }
        [ExcelColumn("Funding_Level")]
        public string Funding_Level { get; set; }
        [ExcelColumn("RAN FA Rank")]
        public string RAN_FA_Rank { get; set; }
        [ExcelColumn("MCEP")]
        public string MCEP { get; set; }
        [ExcelColumn("High_Trust")]
        public string High_Trust { get; set; }
        [ExcelColumn("MOD_Code")]
        public string MOD_Code { get; set; }
        [ExcelColumn("MODCDParity_Flag")]
        public string MODCDParity_Flag { get; set; }       
        [ExcelColumn("RFDS ID")]
        public string RFDS_ID { get; set; }
        [ExcelColumn("RFDS_State_Status")]
        public string RFDS_State_Status { get; set; }
        [ExcelColumn("RFDS_Workflow_Owner")]
        public string RFDS_Workflow_Owner { get; set; }
        [ExcelColumn("RFDS_Workflow_Updated_Date")]
        public string RFDS_Workflow_Updated_Date { get; set; }
        [ExcelColumn("RFDS_Issue")]
        public string RFDS_Issue { get; set; }
        [ExcelColumn("GATING_BUCKET")]
        public string GATING_BUCKET { get; set; }
        [ExcelColumn("Gating_Bucket_Reason")]
        public string Gating_Bucket_Reason { get; set; }
        [ExcelColumn("Current_Cycle_Time")]
        public string Current_Cycle_Time { get; set; }
        [ExcelColumn("Current_Cycle_Time_Category")]
        public string Current_Cycle_Time_Category { get; set; }
        [ExcelColumn("EXECUTED_ON")]
        public string EXECUTED_ON { get; set; }
        [ExcelColumn("Carrier_Count")]
        public string Carrier_Count { get; set; }
        [ExcelColumn("Spectrum_Bucket")]
        public string Spectrum_Bucket { get; set; }
        [ExcelColumn("Funding_Level_Handle")]
        public string Funding_Level_Handle { get; set; }
        [ExcelColumn("PLAN_YEAR")]
        public string PLAN_YEAR { get; set; }
        [ExcelColumn("Temp")]
        public string Temp { get; set; }
    }
}
