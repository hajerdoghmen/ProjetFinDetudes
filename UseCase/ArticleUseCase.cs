using PFE.Domain;
using PFE.Repository;
using Repository;
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
        private IArticleRepository _articleRepository;
        private IReviewRepository _reviewRepository;
        public ArticleUseCase(IPictureRepository pictureRepository
            , IArticleRepository articleRepository
        , IReviewRepository reviewRepository)
            // pictureRepository c'est un 
             //paramétre injécté de type interface
        {
            _pictureRepository = pictureRepository;
            _articleRepository = articleRepository;
            _reviewRepository = reviewRepository;
        }
        public Article GetArticleById(int articleId)
        {
            //ArticleRepository articleRepository = new ArticleRepository();
            //Article article = articleRepository.GetArticleById(articleId);

            Article article = _articleRepository.GetArticleById(articleId);

            //lena mochkol
            //PictureRepository pictureRepository = new PictureRepository();
            //article.ArticleImages = pictureRepository.GetPictureById(articleId);

            article.ArticleImages = _pictureRepository.GetPictureById(articleId);

            //ReviewRepository reviewArticle = new ReviewRepository();
            //article.Reviews = reviewArticle.GetReviewById(articleId);

            article.Reviews = _reviewRepository.GetReviewById(articleId);


            return article;
        }
    }
}
