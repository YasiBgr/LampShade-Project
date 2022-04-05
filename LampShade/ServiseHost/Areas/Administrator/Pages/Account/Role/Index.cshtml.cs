using System.Collections.Generic;
using AccountManagement.Application.Contracts.Account.folder;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiseHost.Areas.Administrator.Pages.Account.Role
{
    public class IndexModel : PageModel
    {


        public List<RoleViewModel> Roles;
        private readonly IRoleApplication _roleApplication;
        [TempData]
        public string Message { get; set; }

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.List();
        }
        public IActionResult OnGetCreate()
        {
            var account = new CreateRole();

            return Partial("./Create", account);
        }
        public JsonResult OnPostCreate(CreateRole command)
        {
            var result = _roleApplication.CreateRole(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var editrole = _roleApplication.GetDetails(id);
            return Partial("./Edit", editrole);

        }
        public JsonResult OnPostEdit(EditRole command)
        {
            var result = _roleApplication.EditRole(command);
            return new JsonResult(result);
        }
    }
}
