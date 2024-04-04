using AmidharaAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmidharaAPI.BusinessLogic
{
    public class VillageManager
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AmidharaCon"].ConnectionString);
        public List<dynamic> GetVillageList(string village)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("APKGetVillageList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Village", village);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                List<dynamic> villageViewModels = new List<dynamic>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dynamic villageView = new
                        {
                            VillageID = Convert.ToInt64(dr["VillageID"]),
                            Village = Convert.ToString(dr["Village"]),
                            gVillage = Convert.ToString(dr["gVillage"])
                        };
                        villageViewModels.Add(villageView);
                    };
                }
                return villageViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurs in GetVillageList {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public List<dynamic> GetStreetList(long villageID, string street)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("APKGetStreetList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VillageID", villageID);
                cmd.Parameters.AddWithValue("@Street", street);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                List<dynamic> streetViewModels = new List<dynamic>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dynamic streetView = new
                        {
                            StreetID = Convert.ToInt64(dr["StreetID"]),
                            Street = Convert.ToString(dr["Street"]),
                            gStreet = Convert.ToString(dr["gStreet"])
                        };
                        streetViewModels.Add(streetView);
                    };
                }
                return streetViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurs in GetStreetList {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public List<PersonIfoViewModel> GetFamilyPersonList(long streetID, string personName)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("APKGetFamilyPersonList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StreetID", streetID);
                cmd.Parameters.AddWithValue("@PersonName", personName);

                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                List<PersonIfoViewModel> personInfoViewModels = new List<PersonIfoViewModel>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PersonIfoViewModel personIfoViewModelView = new PersonIfoViewModel
                        {
                           FamilyCode = Convert.ToString(dr["FamilyCode"]),
                           GPersonName = Convert.ToString(dr["GPersonName"]),
                           MobileNo = Convert.ToString(dr["MobileNo"]),
                           PAddress  = Convert.ToString(dr["PAddress"]),
                           PersonName = Convert.ToString(dr["PersonName"]),
                           PGAddress = Convert.ToString(dr["PGAddress"]),
                           Photo = Convert.ToString(dr["Photo"]),
                           RegistrationID = Convert.ToInt64(dr["RegistrationID"]),
                        };
                        personInfoViewModels.Add(personIfoViewModelView);
                    };
                }
                return personInfoViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurs in GetFamilyPersonList {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }
}