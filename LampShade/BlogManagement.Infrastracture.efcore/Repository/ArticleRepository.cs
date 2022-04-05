using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastracture.efcore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        public readonly BlogContext _Context;

        public ArticleRepository(BlogContext blogContecxt):base(blogContecxt)
        {
            _Context = blogContecxt;
        }


        public EditArticle GetDetails(long id)
        {
            return _Context.Articles.Select(x => new EditArticle
            { 
            Id=x.Id,
            Title=x.Title,
            PictureAlt=x.PictureAlt,
            PictureTitle=x.PictureTitle,
            CategoryId=x.CategoryId,
            Description=x.Description,
            CanonicalAddress=x.CanonicalAddress,
            Keywords=x.Keywords,
            PublishDate=x.PublishDate.ToFarsi(), 
            MetaDescription=x.MetaDescription,
            ShortDescription=x.ShortDescription,
            Slug=x.Slug
            }).FirstOrDefault(x=>x.Id==id); 
        }

        public Article GetWithCategory(long id)
        {
            return _Context.Articles.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel search)
        {
            var query = _Context.Articles.Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Picture=x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Title = x.Title
            });

            if (!string.IsNullOrWhiteSpace(search.Title))
                query = query.Where(x => x.Title.Contains(search.Title));
            if (search.CategoryId > 0)
                query = query.Where(x => x.CategoryId == search.CategoryId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
