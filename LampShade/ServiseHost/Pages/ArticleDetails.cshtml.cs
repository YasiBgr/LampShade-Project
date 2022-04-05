using System.Collections.Generic;
using _01_LampshadeQuery.Contract.Article;
using _01_LampshadeQuery.Contract.ArticleCategory;
using CommentManagement.Application.Contracts.Comment.folder;
using CommentManagement.Infrastracture.efcore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryeModel Article;
        public List<ArticleQueryeModel> LatestArticle;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleDetailsModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Article = _articleQuery.GetDetails(id);
            LatestArticle = _articleQuery.LastestArticle();
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }
        public IActionResult OnPost(AddComment comment, string articleSlug)
        {
            comment.Type = CommentsTypes.Article;
            var result = _commentApplication.AddComment(comment);
            return RedirectToPage("./ArticleDetails", new { Id = articleSlug });
        }
    }
}


