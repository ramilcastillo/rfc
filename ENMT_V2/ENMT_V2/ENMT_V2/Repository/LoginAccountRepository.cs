using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using ENMT_V2.Core.Model;
using ENMT_V2.Repository.Interface;

namespace ENMT_V2.Repository
{
    public class LoginAccountRepository : ILoginAccountRepository
    {
        public IEnumerable<LoginAccount> GetLoginByCredentials(string[] input)
        {
            var loginAcct = new List<LoginAccount>();
            SqlConnection conn = new SqlConnection(Context.ConnectionString);
            string sqlStatement = "select * from LoginAccount where UserName = '"+input[0]+"' AND _Password = '"+input[1]+"'";
            try
            { 
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    loginAcct.Add(new LoginAccount {
                        Id = int.Parse(reader["Id"].ToString()),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["_Password"].ToString(),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateCreated = DateTime.Parse(reader["DateCreated"].ToString())
                    });
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            return loginAcct;
        }
    }
}
