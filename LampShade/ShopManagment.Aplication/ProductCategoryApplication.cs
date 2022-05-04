using _0_FramBase.Application;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagmentAplication.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using ShopManagmentAplication.Contracts.ProductCategory.folder;

namespace ShopManagment.Aplication
{
    public class ProductCategoryApplication : IProductCategoryApplication
        
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x=>x.Name==command.Name))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var PicturePath = $"{command.Slug}";
            var pictureName = _fileUploader.Upload(command.Picture, PicturePath);

            var productCategory = new ProductCategory(command.Name, pictureName, command.PictureTitle,
                command.PictureAlt, command.Description, command.MetaDescription,
                slug, command.Keywords);
            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.Save();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();
            var PicturePath =$"{command.Slug}" ;
            var pictureName = _fileUploader.Upload(command.Picture, PicturePath);
            productCategory.Edit(command.Name, pictureName,
                command.PictureTitle, command.PictureAlt, command.Description,
                command.MetaDescription, slug, command.Keywords);
            _productCategoryRepository.Save();
            return operationResult.Succedded();
                
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);  
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.search(searchModel);
        }

        public void Delete(long id)
        {
            var item = _productCategoryRepository.Get(id);
            item.DeleteCategory();

        }

        public OperationResult Removed(long Id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(Id);
            if (productCategory == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            productCategory.DeleteCategory();
            _productCategoryRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Restore(long Id)
        {
            var operation = new OperationResult();
            var productCategory = _productCategoryRepository.Get(Id);
            if (productCategory == null)
            {
                operation.Failed(ApplicationMessages.RecordNotFound);
            }
            productCategory.RestoreCategory();
            _productCategoryRepository.Save();
            return operation.Succedded();
        }
    }
}
