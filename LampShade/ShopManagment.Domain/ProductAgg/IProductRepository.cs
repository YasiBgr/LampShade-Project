using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.Product.folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductAgg
{
 public interface IProductRepository:IRepository<long,Product>
    {
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetPruducts();
        EditProduct GetDetails(long id);
    }
}
