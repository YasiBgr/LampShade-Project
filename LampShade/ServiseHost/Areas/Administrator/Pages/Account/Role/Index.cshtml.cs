using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Account.folder;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiseHost.Areas.Administrator.Pages.Account.Role
{
    public class IndexModel : PageModel
    {


        public List<RoleViewModel> Roles;
        private readonly IRoleApplication _roleApplication;
        //[TempData]
        //public string Message { get; set; }

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }
       [NeedPermission(AccountPermission.ListRole)]
        public void OnGet()
        {
            Roles = _roleApplication.List();
        }

        public IActionResult OnGetDelete(long id)
        {
            _roleApplication.DeleteRole(id);
            return RedirectToPage("./Index");
        }
       
    }
}
