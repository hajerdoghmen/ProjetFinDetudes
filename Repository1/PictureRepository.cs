using ProjetFinDetudes.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinDetudes.Repository
{
    public class PictureRepository
    {
        public List<ArticleImage> GetPictureById(int articleId)
        {
            List<ArticleImage> pictures = new List<ArticleImage>();

            using (SqlConnection conn = new SqlConnection(SqlConstant.ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_Ge" +
                    "tPictureByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ArticleImage picture = new ArticleImage();
                        picture.ArticleImageId = (int)rdr["PictureId"];
                        picture.Url = (string)rdr["Picture"];


                        pictures.Add(picture);
                    }
                }
            }

            return pictures;



        }
    }
}
