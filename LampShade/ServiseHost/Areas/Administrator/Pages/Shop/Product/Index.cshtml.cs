using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FramBase.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Aplication;
using ShopManagmentAplication.Contracts.Product.folder;
using ShopManagmentAplication.Contracts.ProductCategory;

namespace ServiseHost.Areas.Administrator.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        public ProductSearchModel SearchModel;
        public SelectList ProductCategories;
        public List<ProductViewModel> products;
        private readonly IProductApplication _propductApplication;
        private readonly IProductCategoryApplication _propductCategoryApplication;
        [TempData]
        public string Message { get; set; }

        public IndexModel(IProductApplication propductApplication, IProductCategoryApplication propductCategoryApplication)
        {
            _propductApplication = propductApplication;
            _propductCategoryApplication = propductCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_propductCategoryApplication.GetProductCategories(), "Id", "Name");
            products = _propductApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var propductCategory = new CreateProduct
            {
                Category = _propductCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", propductCategory);
        }
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _propductApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = _propductApplication.GetDetails(id);
            product.Category = _propductCategoryApplication.GetProductCategories();
            return Partial("./Edit", product);

        }
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _propductApplication.Edit(command);
            return new JsonResult(result);
        }
       
    }
}
