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
        private IDiscountRepository _discountRepository;
        public ArticleUseCase(IPictureRepository pictureRepository
            , IArticleRepository articleRepository
        , IReviewRepository reviewRepository
            , IDiscountRepository discountRepository)
        // pictureRepository c'est un 
        //paramétre injécté de type interface
        {
            _pictureRepository = pictureRepository;
            _articleRepository = articleRepository;
            _reviewRepository = reviewRepository;
            _discountRepository = discountRepository;
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

            article.Discounts = _discountRepository.GetDiscountById(articleId);


            return article;
        }
    }
}
