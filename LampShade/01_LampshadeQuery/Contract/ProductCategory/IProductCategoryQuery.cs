﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contract.ProductCategory
{
   public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetListProductCategory();
        List<ProductCategoryQueryModel> GetProductCategoryWithProducts();
        ProductCategoryQueryModel GetProductCategoryWithProductsby(String slug);
    }
}
