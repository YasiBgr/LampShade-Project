using _0_FramBase.Application;
using System.Collections.Generic;

namespace ShopManagmentAplication.Contracts.ProductCategory
{
    public  interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

    }
}
