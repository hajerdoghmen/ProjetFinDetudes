using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.Domain
{
    public class Article
    {
        public int ArticleId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public List<Review> Reviews { get; set; }
        public List<ArticleImage> ArticleImages { get; set; }
        public List<Discount> Discounts { get; set; }
        
    }
}
