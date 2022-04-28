using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Infrastracture.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Areas.Administrator.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel;

        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        [NeedPermission(BlogPermission.ListArticleCategory)]
        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }
        [NeedPermission(BlogPermission.CreateArticleCategory)]
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var command = _articleCategoryApplication.GetDetails(id);
            return Partial("./Edit", command);

        }
        [NeedPermission(BlogPermission.EditArticleCategory)]
        public JsonResult OnPostEdit(EditArticleCategory command)
        {

            if (ModelState.IsValid)
            {

            }
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
