using _0_FramBase.Application;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagmentAplication.Contracts.ProductPictureFolder;
using System.Collections.Generic;

namespace ShopManagment.Aplication
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var Operation = new OperationResult();
            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.Id == command.ProductId));
            Operation.Failed(ApplicationMessages.DublicatedRecord);
            var productPicture = new ProductPicture(
                command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.Save();
            return Operation.Succedded();
           
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productpicture = _productPictureRepository.Get(command.Id);
            if (productpicture == null)
                operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productPictureRepository.Exist(x => x.ProductId == command.ProductId && x.Picture == command.Picture && x.Id != command.Id))
                operation.Failed(ApplicationMessages.DublicatedRecord);
            productpicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Save();
          return  operation.Succedded();
            
        }

        public EditProductPicture GetDetails(long id)
        {
           return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Removed(long Id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(Id);
            if (productPicture==null)
             operation.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Removed();
            _productPictureRepository.Save();
            return operation.Succedded();
            
        }

        public OperationResult Restore(long Id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(Id);
            if (productPicture == null)
                operation.Failed(ApplicationMessages.RecordNotFound);
            productPicture.Restore();
            _productPictureRepository.Save();
            return operation.Succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel command)
        {
            return _productPictureRepository.Search(command);
        }
    }
}
