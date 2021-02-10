using ProjetFinDetudes.Model;
using ProjetFinDetudes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinDetudes.UseCase
{
    public class ArticleUseCase
    {
        public Article GetArticleById(int articleId)
        {
            ArticleRepository articleDemande = new ArticleRepository();
            Article article = articleDemande.GetArticleById(articleId);

            PictureRepository picturesArticle = new PictureRepository();
            List<ArticleImage> images = picturesArticle.GetPictureById(articleId);
            article.ArticleImages = images;

            ReviewRepository reviewArticle = new ReviewRepository();
            article.Reviews = reviewArticle.GetReviewById(articleId);

            return article;
        }
    }
}
