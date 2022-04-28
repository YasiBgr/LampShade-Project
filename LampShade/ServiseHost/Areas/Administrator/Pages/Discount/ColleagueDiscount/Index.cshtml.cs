using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Configurations.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagmentAplication.Contracts.Product.folder;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace ServiseHost.Areas.Administrator.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public ColleagueDiscountSearchModel SearchModel;
        public SelectList Products;
        public List<ColleagueDiscountViewModel> Colleaguediscounts;
        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _ColleagueDiscountApplication;


        public IndexModel(IProductApplication propductApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = propductApplication;
            _ColleagueDiscountApplication = colleagueDiscountApplication;
        }

        [NeedPermission(DiscountPermission.ListColleagueDiscount)]
        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Colleaguediscounts = _ColleagueDiscountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        [NeedPermission(DiscountPermission.DefineColleagueDiscount)]

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _ColleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(long id)
        {
            var Colleaguediscount = _ColleagueDiscountApplication.GetDetails(id);
            Colleaguediscount.Products = _productApplication.GetProducts();
            return Partial("./Edit", Colleaguediscount);

        }

        [NeedPermission(DiscountPermission.EditColleagueDiscount)]

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = _ColleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        [NeedPermission(DiscountPermission.RestoreColleagueDiscount)]

        public IActionResult OnGetRemove(long Id)
        {
            var result = _ColleagueDiscountApplication.Remove(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        [NeedPermission(DiscountPermission.RestoreColleagueDiscount)]

        public IActionResult OnGetRestore(long Id)
        {
            var result = _ColleagueDiscountApplication.Restore(Id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

    }
}
