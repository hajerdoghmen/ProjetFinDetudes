using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Repository.DAL
{
    public class DiscountDAL

    {
        public int ArticleId { get; set; }
        public int DiscoutId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Percent { get; set; }
        public Discount ToDomain()
        {
            return new Discount
            {
                ArticleId = ArticleId,
                DiscoutId = DiscoutId,
                StartDate = StartDate,
                EndDate = EndDate,
                Percent = Percent
            };
    }

    }
}
