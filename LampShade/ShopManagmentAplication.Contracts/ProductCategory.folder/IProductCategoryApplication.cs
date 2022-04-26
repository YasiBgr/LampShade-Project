using System.Collections.Generic;
using _0_FramBase.Application;

namespace ShopManagmentAplication.Contracts.ProductCategory.folder
{
    public  interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> GetProductCategories();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

    }
}
