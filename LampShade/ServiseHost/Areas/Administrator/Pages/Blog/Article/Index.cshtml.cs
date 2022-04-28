using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Infrastracture.Configuration.Permission;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [NeedPermission(BlogPermission.ListArticle)]
        public void OnGet(ArticleSearchModel searchModel)
        {
            articleCategory = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            Article = _articleApplication.Search(searchModel);
        }
        
        }
    }

