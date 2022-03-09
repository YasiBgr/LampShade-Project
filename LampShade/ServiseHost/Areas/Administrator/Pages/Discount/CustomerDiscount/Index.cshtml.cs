using System.Collections.Generic;
using DiscountManagment.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagmentAplication.Contracts.Product.folder;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace ServiseHost.Areas.Administrator.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public CustomerDiscountSearchModel SearchModel;
        public SelectList Products;
        public List<CustomerDiscountViewModel> Customerdiscounts;
        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
       

        public IndexModel(IProductApplication propductApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = propductApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
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
        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

    }
}
