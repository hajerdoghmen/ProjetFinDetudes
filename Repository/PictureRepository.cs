﻿using ProjetFinDetudes.Model;
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

            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLExpress;DataBase=PFE;Integrated Security=SSPI"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("PS_GetPictureByArticleId", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        ArticleImage picture = new ArticleImage();
                        picture.Url = (string)rdr["Picture"];
                       

                        pictures.Add(picture);
                    }
                }
            }

            return pictures;



        }
    }
}
