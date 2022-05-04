using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagment.Configuration.Permission;
using ShopManagmentAplication.Contracts.Product.folder;
using ShopManagmentAplication.Contracts.ProductCategory.folder;

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
        [NeedPermission(ShopPermission.ListProduct)]

        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_propductCategoryApplication.GetProductCategories(), "Id", "Name");
            products = _propductApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var propduct = new CreateProduct
            {
                Category = _propductCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", propduct);
        }

        [NeedPermission(ShopPermission.CreateProduct)]

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
        [NeedPermission(ShopPermission.EditProduct)]

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _propductApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(long Id)
        {
            var result = _propductApplication.Removed(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = _propductApplication.Restore(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
