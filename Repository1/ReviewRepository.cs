using ProjetFinDetudes.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinDetudes.Repository
{
    public class ReviewRepository
    {
        public List<Review> GetReviewById(int articleId)
        {
            List<Review> reviews = new List<Review>();

            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_GetReviewByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Review review = new Review();
                        review.Score = (int)rdr["Score"];
                        review.ReviewId = (int)rdr["ReviewId"];
                        review.Comments = (string)rdr["Comments"];
                        review.ReviewDate = (DateTime)rdr["ReviewDate"];
                        reviews.Add(review);
                    }
                }
            }

            return reviews;



        }
    }
}
