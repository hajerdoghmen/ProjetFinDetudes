
using PFE.Domain;
using PFE.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private readonly string connString;
        public PictureRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public List<ArticleImage> GetPictureById(int articleId)
        {
            var pictures = new List<PictureDAL>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_GetPictureByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var picture = new PictureDAL();
                        picture.ArticleId = (int)rdr["ArticleId"];
                        picture.PictureId = (int)rdr["PictureId"];
                        picture.Picture = (string)rdr["Picture"];
                        pictures.Add(picture);
                    }
                }
            }
            //var articleImages = new List<ArticleImage>();
            //foreach (var picture in pictures)
            //{
            //    articleImages.Add ( picture.ToDomain());
            //}
            //return articleImages;
            
            List<ArticleImage> articleImages =  pictures.Select(picture => picture.ToDomain()).ToList();

            return articleImages;


        }
    }
}
