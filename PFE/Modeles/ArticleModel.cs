using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PFE.Modeles
{
    public class ArticleModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string EstimatedDeliveryDate { get; set; }
        public string PriceAfterDiscount { get; set; }
        public ArticleModel(Article article)
        {
            Name = article.Name;
            Price = article.Price != 0 ? article.Price.ToString() : "Inconnu";
            EstimatedDeliveryDate = article.EstimatedDeliveryDate.HasValue ? article.EstimatedDeliveryDate.ToString() : "Inconnu";
            var activeDiscount = article.Discounts.FirstOrDefault(d => d.EndDate > DateTime.Now);
            PriceAfterDiscount = GetPriceAfetrDiscount(article.Price, activeDiscount);
        }
        private string GetPriceAfetrDiscount(double price, Discount discount)
        {
            var priceAfterDiscount = "";
            if (price == 0)
            {
                priceAfterDiscount = "Incalculable";
            }
            else
            {
                if (discount == null)
                {
                    priceAfterDiscount = " No Discount";
                }
                else
                {
                    priceAfterDiscount = (price * (1 - discount.Percent * 0.01)).ToString();
                }
            }
            return priceAfterDiscount;
        }

    }


}
