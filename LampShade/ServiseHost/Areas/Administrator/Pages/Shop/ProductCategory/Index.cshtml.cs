using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Aplication;
using ShopManagmentAplication.Contracts.ProductCategory;

namespace ServiseHost.Areas.Administrator.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;

        public List<ProductCategoryViewModel> productCategories { get; set; }
        private readonly IProductCategoryApplication _propductCategoryApplication;

        public IndexModel(IProductCategoryApplication propductCategoryApplication)
        {
            _propductCategoryApplication = propductCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel)
        {
         productCategories = _propductCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _propductCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var command = _propductCategoryApplication.GetDetails(id);
            return Partial ("./Edit",command);
                
        }
        public JsonResult OnPostEdit(EditProductCategory command)
        {

            if (ModelState.IsValid)
            {

            }
            var result = _propductCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
