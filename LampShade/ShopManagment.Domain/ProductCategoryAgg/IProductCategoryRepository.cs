using _0_FramBase.Domain;
using ShopManagmentAplication.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ShopManagmentAplication.Contracts.ProductCategory.folder;

namespace ShopManagment.Domain.ProductCategoryAgg
{
    public  interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        List<ProductCategoryViewModel> GetList();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> search(ProductCategorySearchModel searchModel);
       string GetSlugById(long id);

      
    }
}
