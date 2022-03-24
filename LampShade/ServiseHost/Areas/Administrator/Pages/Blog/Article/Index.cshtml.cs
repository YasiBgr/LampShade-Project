using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagementy.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Aplication;
using ShopManagmentAplication.Contracts.ProductCategory;

namespace ServiseHost.Areas.Administrator.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public ArticleSearchModel SearchModel;
        public SelectList articleCategory;
        public List<ArticleViewModel> Article { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleSearchModel searchModel)
        {
            articleCategory = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            Article = _articleApplication.Search(searchModel);
        }
        
        }
    }

