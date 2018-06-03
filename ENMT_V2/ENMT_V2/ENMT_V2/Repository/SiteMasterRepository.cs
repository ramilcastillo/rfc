using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;
using LinqToExcel;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ENMT_V2.Repository
{
    public class SiteMasterRepository : ISiteMasterRepository
    {
        public string[] GetFilesFromPath()
        {
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\Site Master\\");
            return filePaths;
        }

        public IEnumerable<SiteMaster> GetListSiteMaster(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;
            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<SiteMaster>("A1", "XFD1048576", 0) select s).ToList();
           

            //List<SiteMaster> lstSiteMaster = new List<SiteMaster>();
            //List<SiteMaster> lstSiteMaster = new List<SiteMaster>();
            //foreach (SiteMaster item in query)
            //{
            //    lstSiteMaster.Add(new SiteMaster
            //    {
            //        Any_Sectors_Linked = item.Any_Sectors_Linked,
            //        ATT_Site_ID = item.ATT_Site_ID,
            //        Build_Type = item.Build_Type,
            //        Cell_Global_Identity = item.Cell_Global_Identity,
            //        Cell_Number = item.Cell_Number,
            //        CID = item.CID,
            //        CnqClustername = item.CnqClustername,
            //        CnqMarketName = item.CnqMarketName,
            //        COW_FA_Locator = item.COW_FA_Locator,
            //        CSS_Site_ID = item.CSS_Site_ID,
            //        CTSLocID = item.CTSLocID,
            //        CTS_Common_ID = item.CTS_Common_ID,
            //        CTS_Entry_ID = item.CTS_Entry_ID,
            //        DAS_Owner_Type_Indicator = item.DAS_Owner_Type_Indicator,
            //        eNodeB_Identity = item.eNodeB_Identity,
            //        Equipment_Type = item.Equipment_Type,
            //        Equipment_Vendor = item.Equipment_Vendor,
            //        FA_Code_Active = item.FA_Code_Active,
            //        Financial_Location = item.Financial_Location,
            //        Granite_Equip_Inst_ID = item.Granite_Equip_Inst_ID,
            //        LAC = item.LAC,
            //        Location_Building_Permit_Address_1 = item.Location_Building_Permit_Address_1,
            //        Location_Building_Permit_City = item.Location_Building_Permit_City,
            //        Location_Building_Permit_County = item.Location_Building_Permit_County,
            //        Location_Building_Permit_State = item.Location_Building_Permit_State,
            //        Location_Building_Permit_Zipcode = item.Location_Building_Permit_Zipcode,
            //        Location_Latitude = item.Location_Latitude,
            //        Location_Longitude = item.Location_Longitude,
            //        Location_Type = item.Location_Type,
            //        Market_State_Code = item.Market_State_Code,
            //        Market_State_Number = item.Market_State_Number,
            //        Network_Element_Active_Status = item.Network_Element_Active_Status,
            //        Network_Element_Name = item.Network_Element_Name,
            //        NodeB_Number = item.NodeB_Number,
            //        Number_Of_Cabinets = item.Number_Of_Cabinets,
            //        Number_Of_Sectors = item.Number_Of_Sectors,
            //        On_Air = item.On_Air,
            //        On_Air_Date = item.On_Air_Date,
            //        OPS_District = item.OPS_District,
            //        OPS_Zone = item.OPS_Zone,
            //        Oracle_Company_Number = item.Oracle_Company_Number,
            //        OSS_Network_Status = item.OSS_Network_Status,
            //        Project_PACE_Job_Number = item.Project_PACE_Job_Number,
            //        Project_Status = item.Project_Status,
            //        Radio_Serial_Number = item.Radio_Serial_Number,
            //        RBSS_isActive = item.RBSS_isActive,
            //        Rbs_Identity = item.Rbs_Identity,
            //        RBS_Market = item.RBS_Market,
            //        RBS_Record_Active = item.RBS_Record_Active,
            //        Region = item.Region,
            //        Remote_Radio_USID = item.Remote_Radio_USID,
            //        RF_District = item.RF_District,
            //        RF_Zone = item.RF_Zone,
            //        RRH_Site_Common_ID = item.RRH_Site_Common_ID,
            //        RRH_Site_ID = item.RRH_Site_ID,
            //        Sector_Added_Date = item.Sector_Added_Date,
            //        Sector_Latitude = item.Sector_Latitude,
            //        Sector_Longitude = item.Sector_Longitude,
            //        Site_Name = item.Site_Name,
            //        Site_Submission_Status = item.Site_Submission_Status,
            //        Site_Type = item.Site_Type,
            //        Softsectorname = item.Softsectorname,
            //        Structure_Type = item.Structure_Type,
            //        SwitchIDPerBeast = item.SwitchIDPerBeast,
            //        Switch_ID_Per_CSS = item.Switch_ID_Per_CSS,
            //        TAC = item.TAC,
            //        Tdma_In_Active = item.Tdma_In_Active,
            //        Technology = item.Technology,
            //        TowerHeight = item.TowerHeight,
            //        UseId = item.UseId,
            //        USID = item.USID,
            //        USID_Active = item.USID_Active
            //    });
            //}
            return query;
        }
    }
}

