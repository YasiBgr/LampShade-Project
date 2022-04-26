using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Areas.Administrator.Pages.Account.Role
{
    public class CreateModel : PageModel
    {
        public CreateRole command;
        private readonly IRoleApplication _roleApplication;

        public CreateModel(IRoleApplication roleApplication)
        {
            _roleApplication = roleApplication;
        }

        public void OnGet()
        {
          
        }
        public IActionResult OnPost(CreateRole command)
        {
            var result = _roleApplication.CreateRole(command);
            return RedirectToPage("Index");
        }
    }
}
