using _01_LampshadeQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiseHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {            
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var productCategory = _productCategoryQuery.GetListProductCategory();
            return View(productCategory);
        }
    }
}
