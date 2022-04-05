using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Article;
using _01_LampshadeQuery.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
       public List<ArticleCategoryQueryModel> articleCategories;
        public ArticleCategoryQueryModel ArticleCategory;
        List<ArticleQueryeModel> articles;

        private readonly IArticleQuery _articleQuery;   
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleCategoryModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _articleQuery = articleQuery;
        }

        public void OnGet(string id)
        {

            ArticleCategory = _articleCategoryQuery.GetArticleCategory(id);
            articleCategories = _articleCategoryQuery.GetArticleCategories();
            articles = _articleQuery.LastestArticle();
        }
    }
}
