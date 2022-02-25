using _0_FramBase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.ProductPictureFolder
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);
        OperationResult Removed(long Id);
        OperationResult Restore(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel command);
        EditProductPicture GetDetails(long id);
    }
}
