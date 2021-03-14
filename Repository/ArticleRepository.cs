
using PFE.Domain;
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
        public Article GetArticleById(int articleId)
        {
            Article article = new Article();

            using (SqlConnection conn = new SqlConnection(SqlConstant.ConnectionString))
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
                        //int i = 0;
                        //if (rdr == null)
                        //{
                        //    i = 1;
                        //}
                        //else
                        //{
                        //    i = 2;
                        //}
                        //int ii = rdr == null ? 1 : 2;
                        //article.ArticleCategory = (ArticleCategory)rdr["CategoryName"];
                        // n7ot type mte3ou string 5atr lel c# yetretihom lkol koma objet
                        article.ArticleCategory = (ArticleCategory)rdr["ArticleCategoryId"]; // probléme cast enum
                        article.Name = (string)rdr["Name"];
                        article.Price = (double)rdr["Price"];
                        int dayToDeliver = (int)rdr["DeliveryEstimated"];
                        article.EstimatedDeliveryDate = DateTime.Now.AddDays(dayToDeliver);
                    }

                }
            }

            return article;

            //int i = 0;
            //while (i< 3)
            //{
            //    Console.WriteLine(i);
            //    i = i + 1;
            //}

            //return result;
            // boucle while kima boucle if w for w forech heya eli tecotroli l'exécution de la progamme 
            // while ki neda ma3rch bel dhabt nbre d'exécution
        }

    }

}
