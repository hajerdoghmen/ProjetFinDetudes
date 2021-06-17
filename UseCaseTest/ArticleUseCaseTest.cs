using Moq;
using PFE.Domain;
using PFE.Repository;
using PFE.UseCase;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using Xunit;

namespace UseCaseTest
{
    public class ArticleUseCaseTest
    {
        private readonly ArticleUseCase articleUseCase;
        private readonly Mock<IArticleRepository> articleRepositoryMock;
        private readonly Mock<IPictureRepository> pictureRepositoryMock;
        private readonly Mock<IReviewRepository> reviewRepositoryMock;
        private readonly Mock<IDiscountRepository> discountRepositoryMock;
        public ArticleUseCaseTest()
        {
            articleRepositoryMock = new Mock<IArticleRepository>();
            pictureRepositoryMock = new Mock<IPictureRepository>();
            reviewRepositoryMock = new Mock<IReviewRepository>();
            discountRepositoryMock = new Mock<IDiscountRepository>();
            articleUseCase = new ArticleUseCase
            (pictureRepositoryMock.Object,
            articleRepositoryMock.Object,
            reviewRepositoryMock.Object,
            discountRepositoryMock.Object);
        }
        [Fact]
        public void Test_GetArticleById_WhenIdPositif_CallGetArticleById_Once()
        {
            //Given
            var article = new Article()
            {
                ArticleId = 1,
                Name = "robe",
                Price = 40,
                // EstimatedDeliveryDate =
            };
            var reviews = new List<Review>();
            var review = new Review()
            {
                ArticleId = 1,
                ReviewId = 1,
                Comments = "parfait",
                ReviewDate = new DateTime(2020, 01, 22),
            };
            reviews.Add(review);
            var review2 = new Review()
            {
                ArticleId = 1,
                ReviewId = 2,
                Comments = "jolie robe",
                ReviewDate = new DateTime(2020, 01, 25),
            };
            reviews.Add(review2);

            var pictures = new List<ArticleImage>();
            var picture = new ArticleImage()
            {
                ArticleId = 1,
                ArticleImageId = 1,
                Url = "http//asus/bureau/images"
            };
            pictures.Add(picture);

            var discounts = new List<Discount>
            {
                new Discount()
                {
                    ArticleId = 1,
                    DiscoutId = 1,
                    StartDate= new DateTime(2020, 01, 22),
                    EndDate= new DateTime(2020, 05, 02),
                    Percent = 25
                }
            };

            articleRepositoryMock.Setup(x => x.GetArticleById(It.IsAny<int>())) // ki ta3tiha ay entier testa3ml GetArticleById bech traja3li articleResultat
                               .Returns(article);
            reviewRepositoryMock.Setup(x => x.GetReviewById(It.IsAny<int>()))
                               .Returns(reviews);
            pictureRepositoryMock.Setup(x => x.GetPictureById(It.IsAny<int>()))
                               .Returns(pictures);
            discountRepositoryMock.Setup(x => x.GetDiscountById(It.IsAny<int>()))
                               .Returns(discounts);

            //When
            var articleResult = articleUseCase.GetArticleById(1);
            //then
            articleRepositoryMock.Verify(x => x.GetArticleById(1), Times.Once);
            Assert.Equal(1, articleResult.ArticleId);
            Assert.Equal("robe", articleResult.Name);
            Assert.Equal(40, articleResult.Price);
            Assert.Equal(1, articleResult.Reviews.First().ReviewId);
            Assert.Equal(2, articleResult.Reviews.Count);
            Assert.Equal("parfait", articleResult.Reviews.First().Comments);
            Assert.Equal(new DateTime(2020, 01, 22), articleResult.Reviews.First().ReviewDate);
            Assert.Equal(1, articleResult.ArticleImages.First().ArticleImageId);
            Assert.Equal("http//asus/bureau/images", articleResult.ArticleImages.First().Url);
            Assert.Equal(1, articleResult.Discounts.First().DiscoutId);
            Assert.Equal(new DateTime(2020, 01, 22), articleResult.Discounts.First().StartDate);
            Assert.Equal(new DateTime(2020, 05, 02), articleResult.Discounts.First().EndDate);
            Assert.Equal(25, articleResult.Discounts.First().Percent);
        }
        [Fact]
        public void Test_GetArticleById_WhenIdNegatif_ThrowException()
        {
            //then
            Assert.Throws<ArgumentException>(() => articleUseCase.GetArticleById(-3));
            articleRepositoryMock.Verify(x => x.GetArticleById(-3), Times.Never);

        }
    }
}

