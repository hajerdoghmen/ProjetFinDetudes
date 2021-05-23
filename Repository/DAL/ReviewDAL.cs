using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.QRepository.DAL
{
    public class ReviewDAL
    {
        public int ArticleId { get; set; }
        public int ReviewId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review ToDomain()
        {
            return new Review
            {
                ArticleId = ArticleId,
                ReviewId = ReviewId,
                Score = Score,
                Comments = Comments,
                ReviewDate = ReviewDate
            };

        }
    }
}
