using _0_FramBase.Application;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.ArticleAgg;
using BlogManagement.ArticleCategoryAgg;
using BlogManagementy.Application.Contracts.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articlecategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository articleRepository, IArticleCategoryRepository articlecategoryRepository, IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _articlecategoryRepository = articlecategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.Exist(x => x.Title == command.Title))
                operation.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var categorySlug = _articlecategoryRepository.GetSlugby(command.CategoryId);
            var picturePath = $"{categorySlug}//{slug}";
            var picture = _fileUploader.Upload(command.Picture, picturePath);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var createArtice = new Article(command.Title, command.ShortDescription, command.Description,
                picture, command.PictureAlt, command.PictureTitle, publishDate, slug,
                command.Keywords, command.MetaDescription,command.CanonicalAddress,command.CategoryId);
            _articleRepository.Create(createArtice);
            _articleRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var editedArticle = _articleRepository.GetWithCategory(command.Id);
            if (_articleRepository.Exist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            if (editedArticle == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            var slug = command.Slug.Slugify();
            var picturePath = $"{editedArticle.Category.Slug}//{slug}";
            var picture = _fileUploader.Upload(command.Picture, picturePath);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            editedArticle.Edit(command.Title, command.ShortDescription, command.Description, picture, command.PictureAlt
                , command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress,command.CategoryId);
            _articleRepository.Save();
            return operation.Succedded();



        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
          return  _articlecategoryRepository.GetArticleCategories();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel search)
        {
            return _articleRepository.Search(search);
        }
    }
}
