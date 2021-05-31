

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PFE.Config;
using PFE.Domain;
using PFE.Modeles;
using PFE.Repository;
using PFE.UseCase;

namespace PFE
{
    [ApiController] // à voir l'utilité
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private IArticleUseCase _articleUseCase;
        private readonly MyConfig _appConfig;

        public ArticleController(IArticleUseCase articleUseCase, IOptions<MyConfig> appConfig)
        {
            _articleUseCase = articleUseCase;
            _appConfig = appConfig.Value;
        }
        [Route("GetArticleById")] // route mta3 point d'entrer de la fct GetArticleById
        [HttpGet] // type d'appelle verbe fama 
        //HttpPut (insere data) HttpPost (update data) HttpGet (recupere data) HttpDelete (supprime data)

        public ArticleModel GetArticleById(int articleId)
        {
            var version = _appConfig.Version;
            //var repo = new PictureHttpRepository();
            //var repo2 = new ArticleRepository();
            //var articleUseCase = new ArticleUseCase(repo, repo2);

            //var articleUseCase = new ArticleUseCase();
            var articleMmodel = new ArticleModel(_articleUseCase.GetArticleById(articleId));
            return articleMmodel;
        }
    }

}
// nerja3 cours web chkountraja3 json w chkoun traja3 html
