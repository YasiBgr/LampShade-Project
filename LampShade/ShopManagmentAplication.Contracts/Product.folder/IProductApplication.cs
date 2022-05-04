using _0_FramBase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Product.folder
{
  public  interface IProductApplication
    {
        OperationResult Create(CreateProduct createProduct);
        OperationResult Edit(EditProduct editProduct);
        EditProduct GetDetails(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
        OperationResult Removed(long Id);
        OperationResult Restore(long Id);
    }
}
