
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFE.Domain;
using PFE.Repository;
using PFE.UseCase;

namespace PFE
{
    [ApiController] // à voir l'utilité
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleUseCase _articleUseCase;

        public ArticleController(IArticleUseCase articleUseCase)
        {
            _articleUseCase = articleUseCase;
        }

        [Route("GetArticleById")] // route mta3 point d'entrer de la fct GetArticleById
        [HttpGet] // type d'appelle verbe fama 
        //HttpPut (insere data) HttpPost (update data) HttpGet (recupere data) HttpDelete (supprime data)

        public Article GetArticleById(int articleId)
        {
            //var repo = new PictureHttpRepository();
            //var repo2 = new ArticleRepository();
            //var articleUseCase = new ArticleUseCase(repo, repo2);

            //var articleUseCase = new ArticleUseCase();
            var article = _articleUseCase.GetArticleById(articleId);
            return article;
        }
    }
}
// nerja3 cours web chkountraja3 json w chkoun traja3 html
