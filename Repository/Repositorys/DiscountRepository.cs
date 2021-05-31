using PFE.Domain;
using PFE.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PFE.Repository
{
    public class DiscountRepository :IDiscountRepository
    {
        private readonly string connString;
        public DiscountRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public List< Discount> GetDiscountById(int articleId)
        {
           List< Discount> discounts = new List<Discount>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_GetDiscountByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var discount = new DiscountDAL();
                        discount.ArticleId = (int)rdr["ArticleId"];
                        discount.DiscoutId = (int)rdr["DiscoutId"];
                        discount.StartDate = (DateTime)rdr["StartDate"];
                        discount.EndDate = (DateTime)rdr["EndDate"];
                        discount.Percent = (int)rdr["Percent"];
                        discounts.Add(discount.ToDomain()) ;
                    }
                }
            }
            return discounts;
        }
    }
}
