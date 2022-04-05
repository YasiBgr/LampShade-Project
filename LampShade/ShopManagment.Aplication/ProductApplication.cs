using _0_FramBase.Application;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagmentAplication.Contracts.Product.folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Aplication
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct createProduct)
        {
            var operation = new OperationResult();
            if (_productRepository.Exist(x=>x.Name==createProduct.Name))
            {
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            }
            var slug = createProduct.Slug.Slugify();
            var categorySlug = _productCategoryRepository.GetSlugById(createProduct.CategoryId);
            var productPath = $"{categorySlug}//{slug}";

            var fileName = _fileUploader.Upload(createProduct.Picture, productPath);

            var product = new Product(createProduct.Name, createProduct.Code, createProduct.ShortDescription, createProduct.Description,
               fileName, createProduct.PictureAlt, createProduct.PictureTitle, createProduct.CategoryId, slug,
                createProduct.KeyWords, createProduct.MetaDescription);
            _productRepository.Create(product);
            _productRepository.Save();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct editProduct)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(editProduct.Id);
            if (product==null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_productRepository.Exist(x => x.Name == editProduct.Name && x.Id!=editProduct.Id ))
            {
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            }
            var slug = editProduct.Slug.Slugify();
            var categorySlug = _productCategoryRepository.GetSlugById(editProduct.CategoryId);
            var productPath = $"{categorySlug}//{slug}";
            var fileName = _fileUploader.Upload(editProduct.Picture,productPath);
            product.Edit(editProduct.Name, editProduct.Code, editProduct.ShortDescription, editProduct.Description,
                fileName, editProduct.PictureAlt, editProduct.PictureTitle, editProduct.CategoryId, slug,
                editProduct.KeyWords, editProduct.MetaDescription);
          
            _productRepository.Save();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
          return  _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetPruducts();
        }
        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {

            return _productRepository.Search(searchModel);
        }
    }
}
