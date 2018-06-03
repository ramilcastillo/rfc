using LinqToExcel.Attributes;

namespace ENMT_V2.Core.Model
{
    public class SiteMaster
    {
        [ExcelColumn("Region")]
        public string Region { get; set; }
        [ExcelColumn("Cnq Marketname")]
        public string CnqMarketName { get; set; }
        [ExcelColumn("Cnq Clustername")]
        public string CnqClustername { get; set; }
        [ExcelColumn("USID")]
        public string USID { get; set; }
        [ExcelColumn("USID_Active")]
        public string USID_Active { get; set; }
        [ExcelColumn("Technology")]
        public string Technology { get; set; }
        [ExcelColumn("RBS Record Active?")]
        public string RBS_Record_Active { get; set; }
        [ExcelColumn("Softsectorname")]
        public string Softsectorname { get; set; }
        [ExcelColumn("Rbs Identity")]
        public string Rbs_Identity { get; set; }
        [ExcelColumn("Useid")]
        public string UseId { get; set; }
        [ExcelColumn("Site Name")]
        public string Site_Name { get; set; }
        [ExcelColumn("Location-Building Permit Address1")]
        public string Location_Building_Permit_Address_1 { get; set; }
        [ExcelColumn("Location-Building Permit City")]
        public string Location_Building_Permit_City { get; set; }
        [ExcelColumn("Location-Building Permit State")]
        public string Location_Building_Permit_State { get; set; }
        [ExcelColumn("Location-Building Permit County")]
        public string Location_Building_Permit_County { get; set; }
        [ExcelColumn("Location-Building Permit Zipcode")]
        public string Location_Building_Permit_Zipcode { get; set; }
        [ExcelColumn("Location Latitude")]
        public string Location_Latitude { get; set; }
        [ExcelColumn("Location Longitude")]
        public string Location_Longitude { get; set; }
        [ExcelColumn("CTS Entry ID")]
        public string CTS_Entry_ID { get; set; }
        [ExcelColumn("Cts Loc ID")]
        public string CTSLocID { get; set; }
        [ExcelColumn("Switch ID per Beast")]
        public string SwitchIDPerBeast { get; set; }
        [ExcelColumn("CSS Site ID")]    
        public string CSS_Site_ID { get; set; }
        [ExcelColumn("Switch ID per CSS")]
        public string Switch_ID_Per_CSS { get; set; }
        [ExcelColumn("Network Element Name")]
        public string Network_Element_Name { get; set; }
        [ExcelColumn("CTS Common ID")]
        public string CTS_Common_ID { get; set; }
        [ExcelColumn("LAC")]
        public string LAC { get; set; }
        [ExcelColumn("CID")]
        public string CID { get; set; }
        [ExcelColumn("Site Submission Status")]
        public string Site_Submission_Status { get; set; }
        [ExcelColumn("Number of Sectors")]
        public string Number_Of_Sectors { get; set; }
        [ExcelColumn("Any Sectors Linked?")]
        public string Any_Sectors_Linked { get; set; }
        [ExcelColumn("Oracle Company Number")]
        public string Oracle_Company_Number { get; set; }
        [ExcelColumn("Financial Location")]
        public string Financial_Location { get; set; }
        [ExcelColumn("Project_PACE Job Number")]
        public string Project_PACE_Job_Number { get; set; }
        [ExcelColumn("Site Type")]
        public string Site_Type { get; set; }
        [ExcelColumn("Project Status")]
        public string Project_Status { get; set; }
        [ExcelColumn("TowerHeight")]
        public string TowerHeight { get; set; }
        [ExcelColumn("On Air?")]
        public string On_Air { get; set; }
        [ExcelColumn("On-Air Date")]
        public string On_Air_Date { get; set; }
        [ExcelColumn("Equipment Vendor")]
        public string Equipment_Vendor { get; set; }
        [ExcelColumn("ATT Site ID")]
        public string ATT_Site_ID { get; set; }
        [ExcelColumn("Equipment Type")]
        public string Equipment_Type { get; set; }
        [ExcelColumn("Tdma In Active")]
        public string Tdma_In_Active { get; set; }
        [ExcelColumn("Build Type")]
        public string Build_Type { get; set; }
        [ExcelColumn("RBSS IsActive?")]
        public string RBSS_isActive { get; set; }
        [ExcelColumn("eNodeB Identity")]
        public string eNodeB_Identity { get; set; }
        [ExcelColumn("NodeB Number")]
        public string NodeB_Number { get; set; }
        [ExcelColumn("Cell Number")]
        public string Cell_Number { get; set; }
        [ExcelColumn("Cell Global Identity")]
        public string Cell_Global_Identity { get; set; }
        [ExcelColumn("Market State Code")]
        public string Market_State_Code { get; set; }
        [ExcelColumn("Market State Number")]
        public string Market_State_Number { get; set; }
        [ExcelColumn("Location Type")]
        public string Location_Type { get; set; }
        [ExcelColumn("Granite Equip Inst ID")]
        public string Granite_Equip_Inst_ID { get; set; }
        [ExcelColumn("Number of Cabinets")]
        public string Number_Of_Cabinets { get; set; }
        [ExcelColumn("DAS Owner/Type Indicator")]
        public string DAS_Owner_Type_Indicator { get; set; }
        [ExcelColumn("Sector Latitude")]
        public string Sector_Latitude { get; set; }
        [ExcelColumn("Sector Longitude")]
        public string Sector_Longitude { get; set; }
        [ExcelColumn("TAC")]
        public string TAC { get; set; }
        [ExcelColumn("Network Element Active Status")]
        public string Network_Element_Active_Status { get; set; }
        [ExcelColumn("FA Code Active?")]
        public string FA_Code_Active { get; set; }
        [ExcelColumn("RBS Market")]
        public string RBS_Market { get; set; }
        [ExcelColumn("Structure Type")]
        public string Structure_Type { get; set; }
        [ExcelColumn("COW FA Locator")]
        public string COW_FA_Locator { get; set; }
        [ExcelColumn("Sector Added Date")]
        public string Sector_Added_Date { get; set; }
        [ExcelColumn("OSS Network Status")]
        public string OSS_Network_Status { get; set; }
        [ExcelColumn("Remote Radio USID")]
        public string Remote_Radio_USID { get; set; }
        [ExcelColumn("Radio Serial Number")]
        public string Radio_Serial_Number { get; set; }
        [ExcelColumn("OPS District")]
        public string OPS_District { get; set; }
        [ExcelColumn("OPS Zone")]
        public string OPS_Zone { get; set; }
        [ExcelColumn("RF District")]
        public string RF_District { get; set; }
        [ExcelColumn("RF Zone")]
        public string RF_Zone { get; set; }
        [ExcelColumn("RRH Site ID")]
        public string RRH_Site_ID { get; set; }
        [ExcelColumn("RRH Site Common ID")]
        public string RRH_Site_Common_ID { get; set; }
    }
}
