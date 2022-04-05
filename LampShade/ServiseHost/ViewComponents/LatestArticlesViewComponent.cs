using _01_LampshadeQuery.Contract.Article;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiseHost.ViewComponents
{
    public class LatestArticlesViewComponent:ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public IViewComponentResult Invoke()
        {
            var article = _articleQuery.LastestArticle();
            return View(article);
        }
    }
}
