using _0_FramBase.Application;
using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.ArticleCategoryAgg;
using BlogManagementy.Application.Contracts.ArticleCategory;

using System;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exist(x => x.Name == command.Name))
                operation.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var picture = _fileUploader.Upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, picture,command.PictureAlt,command.PictureTitle
                , command.ShortDescription, slug, command.ShowOrder, command.MetaDescription,
                command.CanonicalAddress,command.Keywords);
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if (articleCategory == null)
                operation.Failed(ApplicationMessages.RecordNotFound);
            if (_articleCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                operation.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var picture = _fileUploader.Upload(command.Picture, slug);

            articleCategory.Edit(command.Name,picture,command.PictureAlt,command.PictureTitle
                ,command.ShortDescription,slug,command.ShowOrder,command.MetaDescription,command.Keywords,command.CanonicalAddress);
            _articleCategoryRepository.Save();
            return operation.Succedded();

        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel search)
        {
            return _articleCategoryRepository.Search(search);
        }
    }
}
