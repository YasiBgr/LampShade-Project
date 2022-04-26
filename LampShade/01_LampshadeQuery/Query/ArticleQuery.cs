using _0_FramBase.Application;
using _01_LampshadeQuery.Contract.Article;
using BlogManagement.Infrastracture.efcore;
using CommentManagement.CommentAgg;
using CommentManagement.Infrastracture.efcore;
using System;
using System.Collections.Generic;
using System.Linq;
using _01_LampshadeQuery.Contract.Comment;

namespace _01_LampshadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;
        private readonly CommentContext _commentContext;
        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            _blogContext = blogContext;
            _commentContext = commentContext;
        }

        public ArticleQueryeModel GetDetails(string slug)
        {
            var article= _blogContext.Articles.Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryeModel
            {
                Id=x.Id,
                CanonicalAddress = x.CanonicalAddress,
                CategoryName = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Slug = x.Slug,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title
            }).FirstOrDefault(x => x.Slug == slug);

            article.KeywordsList = article.Keywords.Split(",").ToList();

            var comments = _commentContext.Comments
                .Where(x => x.Status == Statuses.Confirmed)
                .Where(x => x.Type == CommentsTypes.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentId>0)
                {
                    comment.parentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
                }
            }
            article.Comments = comments;
            return article;
        }

        public List<ArticleQueryeModel> LastestArticle()
        {
            return _blogContext.Articles.Where(x => x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryeModel
            {
               CategoryName = x.Category.Name,
                CategorySlug = x.Category.Slug,
                Slug = x.Slug,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title
            }).ToList();
        }
    }
}
