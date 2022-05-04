using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagment.Configuration.Permission;
using ShopManagmentAplication.Contracts.ProductCategory.folder;

namespace ServiseHost.Areas.Administrator.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        [TempData]
        public string Message { get; set; }
        public List<ProductCategoryViewModel> productCategories { get; set; }
        private readonly IProductCategoryApplication _propductCategoryApplication;

        public IndexModel(IProductCategoryApplication propductCategoryApplication)
        {
            _propductCategoryApplication = propductCategoryApplication;
        }
        [NeedPermission(ShopPermission.ListProductCategory)]
        public void OnGet(ProductCategorySearchModel searchModel)
        {
         productCategories = _propductCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        [NeedPermission(ShopPermission.CreateProductCategory)]

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
        [NeedPermission(ShopPermission.EditProductCategory)]

        public JsonResult OnPostEdit(EditProductCategory command)
        {

            if (ModelState.IsValid)
            {

            }
            var result = _propductCategoryApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemoved(long Id)
        {
            var result = _propductCategoryApplication.Removed(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = _propductCategoryApplication.Restore(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
