using System.Collections.Generic;

namespace _01_LampshadeQuery.Contract.Article
{
    public interface IArticleQuery
    {
        ArticleQueryeModel GetDetails(string slug);
        List<ArticleQueryeModel> LastestArticle();
        List<ArticleQueryeModel> GetListArticles();
    }
}
