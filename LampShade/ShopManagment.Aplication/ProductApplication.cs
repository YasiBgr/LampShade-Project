using _0_FramBase.Application;
using ShopManagment.Domain.ProductAgg;
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

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct createProduct)
        {
            var operation = new OperationResult();
            if (_productRepository.Exist(x=>x.Name==createProduct.Name))
            {
                return operation.Failed(ApplicationMessages.DublicatedRecord);
            }
            var product = new Product(createProduct.Name, createProduct.Code, createProduct.UnitPrice, createProduct.ShortDescription, createProduct.Description,
                createProduct.Picture, createProduct.PictureAlt, createProduct.PictureTitle, createProduct.CategoryId, createProduct.Slug,
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
          product.Edit(editProduct.Name, editProduct.Code, editProduct.UnitPrice, editProduct.ShortDescription, editProduct.Description,
                editProduct.Picture, editProduct.PictureAlt, editProduct.PictureTitle, editProduct.CategoryId, editProduct.Slug,
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

        public OperationResult IsInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            product.InStock();
            _productRepository.Save();
            return operation.Succedded();
        }

        public OperationResult NotInStock(long id)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            product.NotInStock();
            _productRepository.Save();
            return operation.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {

            return _productRepository.Search(searchModel);
        }
    }
}
