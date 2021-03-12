
using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Repository
{
    public class PictureHttpRepository : IPictureRepository
    {
        public List<ArticleImage> GetPictureById(int articleId)
        {
            return new List<ArticleImage>();
        }
    }
}
