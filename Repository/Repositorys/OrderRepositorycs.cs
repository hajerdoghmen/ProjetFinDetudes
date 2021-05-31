using PFE.Domain;
using PFE.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PFE.Repository
{
    public class OrderRepository : IOrderRepository // rôle de l'interface 
    {
        private readonly string connString;
        public OrderRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public Order GetOrderById(int orderId)
        {
            List<OrderDetailDAL> orderDetails = new List<OrderDetailDAL>();
            using (SqlConnection conn = new SqlConnection(connString))// rôle const el sna3tha
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetOrderById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                    while (rdr.Read()) // wa9tech nesta3wl while w wa9tech lo5rin
                    {
                        OrderDetailDAL detailDAL = new OrderDetailDAL();
                        detailDAL.OrderDate = (DateTime)rdr["OrderDate"];
                        detailDAL.OrderId = (int)rdr["OrderId"];
                        detailDAL.UserId = (int)rdr["UserId"];
                        detailDAL.Price = (double) rdr["Price"];
                        detailDAL.OrderDate = (DateTime)rdr["OrderDate"];
                        detailDAL.DeliveryDate = (DateTime)rdr["DeliveryDate"];
                        detailDAL.OrderTypeId = (int) rdr["OrderTypeId"];
                        detailDAL.ShippingModeId = (int)rdr["ShippingModeId"];
                        detailDAL.ShippingAdressId = (int)rdr["ShippingAdressId"];
                        detailDAL.BillingAdressId = (int) rdr["BillingAdressId"];
                        detailDAL.Sh_City = (string)rdr["Sh_City"];
                        detailDAL.Sh_Country = (string)rdr["Sh_Country"];
                        //detailDAL.Sh_IsDefault = (bool?)rdr["Sh_IsDefault"];
                        detailDAL.Sh_Number = (int)rdr["Sh_Number"];
                        detailDAL.Sh_Street = (string)rdr["Sh_Street"];
                        detailDAL.Sh_ZipCode = (int)rdr["Sh_ZipCode"];
                        detailDAL.Bi_City = (string)rdr["Bi_City"];
                        detailDAL.Bi_Country = (string)rdr["Bi_Country"];
                       // detailDAL.Bi_IsDefault = (bool?)rdr["Bi_IsDefault"];
                        detailDAL.Bi_Number = (int)rdr["Bi_Number"];
                        detailDAL.Bi_Street = (string)rdr["Bi_Street"];
                        detailDAL.Bi_ZipCode = (int)rdr["Bi_ZipCode"];
                        detailDAL.ArticleId = (int)rdr["ArticleId"];
                        detailDAL.Amount = (int)rdr["Amount"];
                        detailDAL.CreditCardId = (int?)rdr["CreditCardId"];
                        detailDAL.Label = (string)rdr["Label"];
                        detailDAL.ExpirtionDate = (DateTime)rdr["ExpirtionDate"];
                        detailDAL.SecurityCode = (int)rdr["SecurityCode"];
                        detailDAL.CreditCardNumbr = (string)rdr["CardNumber"];
                        orderDetails.Add(detailDAL);
                    }
            }
            Order order = OrderDetailDAL.ToDomain(orderDetails);
            return order;
        }
    }
}
