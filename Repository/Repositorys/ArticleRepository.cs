
using PFE.Domain;
using PFE.Repository.DAL;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly string connString;
        public ArticleRepository(IDbConnection dbConnection)
        {
            connString = dbConnection.ConnectionString;
        }
        public Article GetArticleById(int articleId)
        {
            var articleDal = new ArticleDAL();

            using (SqlConnection conn = new SqlConnection(connString))
            // lena nbadl ken database hedhi nel9aha win na3ml connexion  fel sql : lena na3tih route de connexion lel sql
            // La raison de l' usinginstruction est de s'assurer que l'objet est supprimé dès qu'il est hors de 
            //portée, et il ne nécessite pas de code explicite pour s'assurer que cela se produit.
            {
                conn.Open();
                // lena n7el CONNEXION


                // taw au dessouq commande sql bech na3ml connexion 
                SqlCommand cmd = new SqlCommand("PS_GetArticleById", conn);
                // lena na3tih ism procedure stokées lena esmha PS_GetArticleById

                cmd.CommandType = CommandType.StoredProcedure;
                // lena nzid n9olou eli heya procédure stokée

                cmd.Parameters.Add(new SqlParameter("@articleId", articleId));
                // lena na3th les paramétres eli te5ouhom procédure stokée
                // @articleId hedhi ism paramétre fel sql serveur ama hedhi articleId paramétre eli te5ou fct mte3na fel repository

                using (SqlDataReader rdr = cmd.ExecuteReader())
                // .ExecuteReader (5atr bech yrja3 liste wala yraja3 élemet we7d) w fama ExecuteNnnQuery( bech mayraja3 chay) 
                {
                    if (rdr.Read())
                    //rdr.Read heya ei fasrheli oussama kima dictionnaire
                    {
                        articleDal.ArticleId = (int)rdr["ArticleId"]; // probléme cast enum
   
                        articleDal.ArticleCategoryId = rdr["ArticleCategoryId"] != DBNull.Value ? (int)rdr["ArticleCategoryId"] : 0;
                        articleDal.ArticleName = rdr["ArticleName"] != DBNull.Value ? (string)rdr["ArticleName"] : null;
                        articleDal.Price = rdr["Price"] != DBNull.Value ? (double)rdr["Price"] : 0;
                        articleDal.DeliveryEstimated = rdr["DeliveryEstimated"] != DBNull.Value ? (int?)rdr["DeliveryEstimated"] : null;   
                    }
                }
                Article a = articleDal.ToDomain();
                return a;

            }

        }

    }

}
