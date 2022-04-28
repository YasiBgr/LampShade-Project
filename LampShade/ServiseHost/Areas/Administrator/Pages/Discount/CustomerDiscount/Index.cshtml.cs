using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Configurations.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagmentAplication.Contracts.Product.folder;
using ShopManagmentAplication.Contracts.ProductCategory;
using ShopManagmentAplication.Contracts.ProductCategory.folder;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace ServiseHost.Areas.Administrator.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public CustomerDiscountSearchModel SearchModel;
        public SelectList Products;
        public SelectList Categories;
        public List<CustomerDiscountViewModel> Customerdiscounts;
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productcategoryApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;


        public IndexModel(IProductApplication propductApplication, ICustomerDiscountApplication customerDiscountApplication, IProductCategoryApplication productcategoryApplication)
        {
            _productApplication = propductApplication;
            _customerDiscountApplication = customerDiscountApplication;
            _productcategoryApplication = productcategoryApplication;
        }

        [NeedPermission(DiscountPermission.ListCustomerDiscount)]
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Categories = new SelectList(_productcategoryApplication.GetProductCategories(), "Id", "Name");
          
            Customerdiscounts = _customerDiscountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscount
            { 
                Products=_productApplication.GetProducts()
            };

            return Partial("./Create",command);
        }

        [NeedPermission(DiscountPermission.DefineCustomerDiscount)]

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(long id)
        {
            var customerdiscount = _customerDiscountApplication.GetDetails(id);
            customerdiscount.Products = _productApplication.GetProducts();
            return Partial("./Edit", customerdiscount);

        }
        [NeedPermission(DiscountPermission.EditCustomerDiscount)]

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
