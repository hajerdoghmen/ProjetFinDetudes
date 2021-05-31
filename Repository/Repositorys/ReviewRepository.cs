
using PFE.Domain;
using PFE.QRepository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string connString;
        public ReviewRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public List<Review> GetReviewById(int articleId)
        {
            var reviews = new List<ReviewDAL>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_GetReviewByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var review = new ReviewDAL();
                        review.ArticleId = (int)rdr["ArticleId"];
                        review.Score = (int)rdr["Score"];
                        review.ReviewId = (int)rdr["ReviewId"];
                        review.Comments = (string)rdr["Comments"];
                        review.ReviewDate = (DateTime)rdr["ReviewDate"];
                        reviews.Add(review);
                    }
                }
            }

            List<Review> articleReview = reviews.Select(review => review.ToDomain()).ToList();

            return articleReview;



        }
    }
}
