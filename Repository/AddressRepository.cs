
using PFE.Domain;
using PFE.Repository.DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PFE.Repository
{
    public class AddressRepository : IAddressRepository
    {
        public List <Address>  GetBillingAdressByUserId (int userId)
        {
            var addressesBilling = new List<AddressDAL>();
            
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
                        var addressBilling = new AddressDAL();
                        addressBilling.AddressId = (int)rdr["BillingAddressId"];
                        addressBilling.Number = (int)rdr["Number"];
                        addressBilling.Street=(string)rdr["Street"];
                        addressBilling.ZipCode= (int)rdr["ZipCode"];
                        addressBilling.City = (string)rdr["City"];
                        addressBilling.Country =(string)rdr["Country"];
                        addressBilling.IsDefault = (bool)rdr["IsDefault"];
                        addressesBilling.Add(addressBilling);
                    }
                }
            }
             List<Address> userBillingAddress = addressesBilling.Select(addressBilling => addressBilling.ToDomain()).ToList();
            return userBillingAddress;
        }
        public List<Address> GetShippingAdressByUserId(int userId)
        {
            var addressesShipping = new List<AddressDAL>();

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
                        var addressShipping = new AddressDAL();
                        addressShipping.AddressId = (int)rdr["ShippingAddressId"];
                        addressShipping.Number = (int)rdr["Number"];
                        addressShipping.Street = (string)rdr["Street"];
                        addressShipping.ZipCode = (int)rdr["ZipCode"];
                        addressShipping.City = (string)rdr["City"];
                        addressShipping.Country = (string)rdr["Country"];
                        addressShipping.IsDefault = (bool)rdr["IsDefault"];
                        addressesShipping.Add(addressShipping);

                    }
                }
            }
            List<Address> userAddressShipping = addressesShipping.Select(addressShipping => addressShipping.ToDomain()).ToList();
            return userAddressShipping;
        }
    }
}
