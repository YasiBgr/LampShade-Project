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
        //[TempData]
        //public string Message { get; set; }

        public IndexModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
            Roles = _roleApplication.List();
        }
        
       
    }
}
