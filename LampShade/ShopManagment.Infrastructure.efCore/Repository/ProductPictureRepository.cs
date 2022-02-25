using _0_FramBase.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagmentAplication.Contracts.ProductPictureFolder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.efCore.Repository
{
  public  class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _shopContext.ProductPicture.Select(x => new EditProductPicture 
            {
            Id=x.Id,
            Picture=x.Picture,
            PictureAlt=x.PictureAlt,
            PictureTitle=x.PictureTitle,
            ProductId=x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel)
        {
            var query = _shopContext.ProductPicture.Include(x => x.Product).Select(x => new ProductPictureViewModel
            {
                Product = x.Product.Name,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                Picture = x.Picture,
                ProductId=x.ProductId,
                IsRemoved=x.IsDeleted
            });
            if (productPictureSearchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == productPictureSearchModel.ProductId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
