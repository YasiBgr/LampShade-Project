using _0_FramBase.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagementy.Application.Contracts.ArticleCategory;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
         EditArticleCategory GetDetails(long id);
        string GetSlugby(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search);
        List<ArticleCategoryViewModel> GetArticleCategories();
    }
}
