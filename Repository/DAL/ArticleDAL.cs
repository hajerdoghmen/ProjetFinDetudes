using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Repository.DAL
{
    public class ArticleDAL
    {
        public int ArticleId { get; set; }
        public int ArticleCategoryId { get; set; }
        public string ArticleName { get; set; }
        public double Price { get; set; }
        public int? DeliveryEstimated { get; set; }
        public Article ToDomain()
        {
            var result = new Article();
            result.ArticleId = ArticleId;
            result.ArticleCategory = (ArticleCategory)ArticleCategoryId;
            result.Name = ArticleName;
            result.Price = Price;
            if (DeliveryEstimated.HasValue)
            {
                result.EstimatedDeliveryDate = DateTime.Now.AddDays(DeliveryEstimated.Value);
            }
           
            return result;
        }


    }

}