using _0_FramBase.Domain;
using BlogManagement.Application.Contracts.Article;
using System.Collections.Generic;

namespace BlogManagement.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetDetails(long id);
        Article GetWithCategory(long id);
        List<ArticleViewModel> Search(ArticleSearchModel search);
        
    }
}
