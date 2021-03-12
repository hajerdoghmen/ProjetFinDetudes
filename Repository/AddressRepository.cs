
using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PFE.Repository
{
    public class AddressRepository
    {
        public List <Address>  GetBillingAdressByUserId (int userId)
        {
            List<Address> addressesBilling = new List<Address>();
            
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PS_GetBillingAdresByUserId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                { 
                    while (rdr.Read())
                    {
                        Address addressBilling = new Address();

                        addressBilling.Number = (int)rdr["Number"];
                        addressBilling.Street=(string)rdr["Street"];
                        addressBilling.ZIPcode= (int)rdr["ZipCode"];
                        addressBilling.City = (string)rdr["City"];
                        addressBilling.Country = (Country)Enum.Parse(typeof(Country), (string)rdr["Country"]);
                        addressBilling.IsDefault = (bool)rdr["IsDefault"];
                        addressesBilling.Add(addressBilling);
                    
                    }
                }
            }
            return addressesBilling;
        }
        public List<Address> GetShippingAdressByUserId(int userId)
        {
            List<Address> addressesShipping = new List<Address>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PS_GetShippingAddrsesByUserId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Address addressShipping = new Address();

                        addressShipping.Number = (int)rdr["Number"];
                        addressShipping.Street = (string)rdr["Street"];
                        addressShipping.ZIPcode = (int)rdr["ZipCode"];
                        addressShipping.City = (string)rdr["City"];
                        addressShipping.Country = (Country)Enum.Parse(typeof(Country), (string)rdr["Country"]);
                        addressShipping.IsDefault = (bool)rdr["IsDefault"];
                        addressesShipping.Add(addressShipping);

                    }
                }
            }
            return addressesShipping;
        }
    }
}
