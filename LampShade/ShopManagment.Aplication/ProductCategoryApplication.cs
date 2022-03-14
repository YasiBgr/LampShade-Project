using _0_FramBase.Application;
using _0_Framework.Application;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagmentAplication.Contracts.ProductCategory;
using System;
using System.Collections.Generic;

namespace ShopManagment.Aplication
{
    public class ProductCategoryApplication : IProductCategoryApplication
        
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            if (_productCategoryRepository.Exist(x=>x.Name==command.Name))
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            var slug = command.Slug.Slugify();

            var productCategory = new ProductCategory(command.Name, command.Picture, command.PictureTitle,
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

            productCategory.Edit(command.Name, command.Picture,
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
    }
}
