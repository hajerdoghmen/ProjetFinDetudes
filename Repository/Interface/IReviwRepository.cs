using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Repository
{
    public interface IReviewRepository
    {
        List<Review> GetReviewById(int articleId);

    }
}
