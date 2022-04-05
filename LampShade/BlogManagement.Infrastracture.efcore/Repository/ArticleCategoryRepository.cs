using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastracture.efcore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        public readonly BlogContext _blogContecxt;

        public ArticleCategoryRepository(BlogContext blogContecxt):base(blogContecxt)
        {
            _blogContecxt = blogContecxt;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _blogContecxt.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _blogContecxt.ArticleCategories.Select(x => new EditArticleCategory
            {
                Id = id,
                CanonicalAddress = x.CanonicalAddress,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                ShortDescription = x.ShortDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetSlugby(long id)
        {
            return _blogContecxt.ArticleCategories.Select(x => new { x.Id, x.Slug })
                 .FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            var query = _blogContecxt.ArticleCategories.Include(x=>x.Articles).Select(x => new ArticleCategoryViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length,30))+"...",
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount=x.Articles.Count
            }) ;
            if (!string.IsNullOrWhiteSpace(search.Name))
                query = query.Where(x => x.Name.Contains(search.Name));
            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }
    }
}
