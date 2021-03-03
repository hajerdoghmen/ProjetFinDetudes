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
            ArticleRepository articleRepository = new ArticleRepository();
            Article article = articleRepository.GetArticleById(articleId);

            PictureRepository pictureRepository = new PictureRepository();
            article.ArticleImages = pictureRepository.GetPictureById(articleId);

            ReviewRepository reviewArticle = new ReviewRepository();
            article.Reviews = reviewArticle.GetReviewById(articleId);

            return article;
        }
    }
}
