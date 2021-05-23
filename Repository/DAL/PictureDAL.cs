using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Repository.DAL
{
    public class PictureDAL
    {
        public int ArticleId { get; set; }
        public int PictureId { get; set; }
        public string Picture { get; set; }
        public ArticleImage ToDomain()
        {
            return new ArticleImage
            {
                ArticleId = ArticleId,
                ArticleImageId = PictureId,
                Url = Picture
            };
        }
    }
}