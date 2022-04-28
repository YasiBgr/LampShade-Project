using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Article;

namespace BlogManagment.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Article : ControllerBase
    {
        private readonly IArticleQuery _articleQuery;

        public Article(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        [HttpGet]
        public List<ArticleQueryeModel> GetLatestArticles()
        {
           return _articleQuery.LastestArticle();
        }

    }
}
