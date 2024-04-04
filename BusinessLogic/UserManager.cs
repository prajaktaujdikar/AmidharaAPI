using AmidharaAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AmidharaAPI.BusinessLogic
{
    public class UserManager
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AmidharaCon"].ConnectionString);
        public List<dynamic> GetUserLogin(string contactNo, string password)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("APKGetUserLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactNo", contactNo);
                cmd.Parameters.AddWithValue("@Password", password);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                List<dynamic> userViewModels = new List<dynamic>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dynamic userView = new 
                        {
                            AdminUserID = Convert.ToInt64(dr["AdminUserID"]),
                            AdminUserName = Convert.ToString(dr["AdminUserName"]),
                            
                        };
                        userViewModels.Add(userView);
                    };
                }
                return userViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurs in GetUserLogin {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}