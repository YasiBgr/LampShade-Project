using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.ProductPictureFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);
        ProductPicture GetCategoryWithProduct(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel);
    }
}
