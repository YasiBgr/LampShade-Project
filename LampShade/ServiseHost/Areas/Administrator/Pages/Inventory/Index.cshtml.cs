using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using InventoryManagement.Applicatopn.Contracts.Inventory;
using InventoryManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagmentAplication.Contracts.Product.folder;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace ServiseHost.Areas.Administrator.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public InventorySearchModel SearchModel;
        public SelectList Products;
        public List<InventoryViewModel> Inventory;
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _InventoryApplication;


        public IndexModel(IProductApplication propductApplication, IInventoryApplication InventoryApplication)
        {
            _productApplication = propductApplication;
            _InventoryApplication = InventoryApplication;
        }
        [NeedPermission(InventoryPermission.ListInventory)]
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventory = _InventoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productApplication.GetProducts()
            };

            return Partial("./Create", command);
        }

        [NeedPermission(InventoryPermission.CreateInventory)]

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _InventoryApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(long id)
        {
            var Inventory = _InventoryApplication.GetDetails(id);
            Inventory.Products = _productApplication.GetProducts();
            return Partial("./Edit", Inventory );

        }
        [NeedPermission(InventoryPermission.EditInventory)]

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _InventoryApplication.Edit(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("./Increase",command);

        }
        [NeedPermission(InventoryPermission.IncreaseInventory)]

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _InventoryApplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduse(long id)
        {
            var command = new ReduseInventory()
            {
                InventoryId = id
            };
            return Partial("./Reduse", command);

        }

        [NeedPermission(InventoryPermission.ReduceInventory)]

        public JsonResult OnPostReduse(ReduseInventory command)
        {
            var result = _InventoryApplication.Reduse(command);
            return new JsonResult(result);
        }

        [NeedPermission(InventoryPermission.OperationLog)]

        public IActionResult OnGetLog(long id)
        {
            var log = _InventoryApplication.GetOperationLog(id);
            return Partial("OperationLog", log);
        }
    }
}
