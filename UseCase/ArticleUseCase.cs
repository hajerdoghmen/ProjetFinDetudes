using PFE.Domain;
using PFE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE.UseCase
{
    public class ArticleUseCase : IArticleUseCase
    {
        private IPictureRepository _pictureRepository;   // variable de classe de type interface 
        public ArticleUseCase(IPictureRepository pictureRepository) // pictureRepository c'est un 
                                                                    //paramétre injécté de type interface
        {
            _pictureRepository = pictureRepository;
        }
        public Article GetArticleById(int articleId)
        {
            ArticleRepository articleRepository = new ArticleRepository();
            Article article = articleRepository.GetArticleById(articleId);

            //lena mochkol
            //PictureRepository pictureRepository = new PictureRepository();
            //article.ArticleImages = pictureRepository.GetPictureById(articleId);

            article.ArticleImages = _pictureRepository.GetPictureById(articleId);

            ReviewRepository reviewArticle = new ReviewRepository();
            article.Reviews = reviewArticle.GetReviewById(articleId);

            return article;
        }
    }
}
