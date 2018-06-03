using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ENMT_V2.Repository
{
    public class HomeRepository : IHomeRepository
    {
        public IEnumerable<CI004_RFDS_NOT_IN_CSS> ExcelUploadReference_CI004_NOT_IN_CSS(string _fileName)
        {
            var excelQuery = new ExcelQueryFactory(_fileName);
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.USID, "USID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.RFDS_NAME, "RFDS_NAME");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.PROGRAM_TYPE, "PROGRAM_TYPE");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.TECHNOLOGY, "TECHNOLOGY");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.CARRIER, "CARRIER");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SECTOR, "SECTOR");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.USEID, "USEID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.RBSID, "RBSID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.DELETE_SOFT_SECTOR, "DELETE_SOFT_SECTOR");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.CTS_COMMONID, "CTS_COMMONID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SOFT_SECTORID, "SOFT_SECTORID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.CELL_NUMBER_LTE, "CELL_NUMBER_LTE");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.CID_SAC, "CID_SAC");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.RFDSID, "RFDSID");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SITEMASTER, "SITEMASTER");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SECTOR_LATITUDE, "SECTOR_LATITUDE");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SECTOR_LONGITUDE, "SECTOR_LONGITUDE");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.RBSS_ISACTIVE, "RBSS_ISACTIVE");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.REMARKS, "REMARKS");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SPECTRUM_BUCKET_1, "SPECTRUM_BUCKET_1");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SPECTRUM_BUCKET_2, "SPECTRUM_BUCKET_2");
            excelQuery.AddMapping<CI004_RFDS_NOT_IN_CSS>(x => x.SPECTRUM_USID, "SPECTRUM_USID");

            var items = (from s in excelQuery.Worksheet<CI004_RFDS_NOT_IN_CSS>("NOT_IN_CSS") select s).AsEnumerable();

            return items;
        }

        public void Save_CI004_NOT_IN_CSS(DataTable dt)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Context.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ci004_waterfall", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Table0", dt).SqlDbType = SqlDbType.Structured;
                cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public DataTable ObtainDataTableFromIEnumerable(IEnumerable<CI004_RFDS_NOT_IN_CSS> items)
        {
            DataTable dt = new DataTable();
            foreach (CI004_RFDS_NOT_IN_CSS item in items)
            {
                Type t = item.GetType();
                PropertyInfo[] pis = t.GetProperties();
                if (dt.Columns.Count == 0)
                {
                    foreach (PropertyInfo pi in pis)
                    {
                        dt.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pi in pis)
                {
                    object value = pi.GetValue(item, null);
                    dr[pi.Name] = value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
