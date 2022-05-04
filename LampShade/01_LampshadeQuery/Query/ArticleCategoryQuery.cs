using _0_FramBase.Application;
using _01_LampshadeQuery.Contract.Article;
using _01_LampshadeQuery.Contract.ArticleCategory;
using BlogManagement.ArticleAgg;
using BlogManagement.Infrastracture.efcore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public List<ArticleCategoryQueryModel> GetArticleCategories()
        {
            var article = _blogContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                ArticleCount = x.Articles.Count
            }).ToList();
            return article;
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var articleCategory= _blogContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Slug = x.Slug,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Keyword = x.Keywords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                ArticleCount = x.Articles.Count,
                Articles = MapArticle(x.Articles)
            }).FirstOrDefault(x => x.Slug == slug);
            if (!string.IsNullOrWhiteSpace(articleCategory.Keyword))
            {
                articleCategory.Keywords = articleCategory.Keyword.Split(",").ToList();
            }
            return articleCategory;
        }

        private List<ArticleQueryeModel> MapArticle(List<Article> articles)
        {
            return articles.Select(x => new ArticleQueryeModel
            {
                Slug = x.Slug,
                ShortDescription = x.ShortDescription,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi()
            }).ToList();
        }
    }
}
