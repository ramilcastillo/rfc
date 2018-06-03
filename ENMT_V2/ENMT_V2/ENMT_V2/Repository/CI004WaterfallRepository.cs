using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;
using LinqToExcel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System;

namespace ENMT_V2.Repository
{
    public class CI004WaterfallRepository:ICI004WaterfallRepository
    {
        public string[] GetFilesFromPath()
        {
            string[] filePaths = Directory.GetFiles(Application.StartupPath + "\\CI004_Waterfall\\");
            return filePaths;
        }

        public IEnumerable<CI004_Waterfall> GetListCI004Waterfall(string filename)
        {
            var excel = new ExcelQueryFactory();
            excel.FileName = filename;
            
            var x = excel.GetWorksheetNames();

            var query = (from s in excel.WorksheetRange<CI004_Waterfall>("A2", "XFD1048576", 0) select s).ToList();

            return query;
            //List < CI004_Waterfall > lstWaterfall = new List<CI004_Waterfall>();
            //foreach (CI004_Waterfall item in query)
            //{
            //    lstWaterfall.Add(new CI004_Waterfall
            //    {
            //        USID_SPECTRUM = item.USID_SPECTRUM,
            //        PACE_NUMBER = item.PACE_NUMBER,
            //        SITE_NUMBER = item.SITE_NUMBER,
            //        PACE_NAME = item.PACE_NAME,
            //        COUNTY = item.COUNTY,
            //        PRODUCT_SUBGROUP = item.PRODUCT_SUBGROUP,
            //        USID = item.USID,
            //        CI004_FORECAST = item.CI004_FORECAST,
            //        CI004_ACTUAL = item.CI004_ACTUAL,
            //        CI003_FORECAST = item.CI003_FORECAST,
            //        CI003_ACTUAL = item.CI003_ACTUAL,
            //        SPECTRUM = item.SPECTRUM,
            //        FUNDING_LEVEL = item.FUNDING_LEVEL,
            //        RFDS_ID = item.RFDS_ID,
            //        RFDS_STATE_STATUS = item.RFDS_STATE_STATUS,
            //        SPECTRUM_BUCKET = item.SPECTRUM_BUCKET,
            //        PLAN_YEAR = item.PLAN_YEAR,
            //        NOT_IN_CSS = item.NOT_IN_CSS,
            //        MISSING_COORDINATES = item.MISSING_COORDINATES,
            //        SECTOR_IN_CSS = item.SECTOR_IN_CSS,
            //        FINAL_REMARKS = item.FINAL_REMARKS
            //    });
            //}
            //return lstWaterfall;
        }
    }
}
