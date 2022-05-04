using System.Collections.Generic;
using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Account.folder;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiseHost.Areas.Administrator.Pages.Account.Account
{
    public class IndexModel : PageModel
    {
        public AccountSearchModel SearchModel;
        public SelectList Role;
        public List<AccountViewModel> Accounts;
        private readonly IAccountApplication _accountApplication;
        private readonly IRoleApplication _roleApplication;
        [TempData]
        public string Message { get; set; }

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }

        [NeedPermission(AccountPermission.ListAccount)]
        public void OnGet(AccountSearchModel searchModel)
        {
            Role = new SelectList(_roleApplication.List(), "Id", "Name");
            Accounts = _accountApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var account = new RegisterAccount
            {
                Roles = _roleApplication.List()
            };
            return Partial("./Create", account);
        }
      [NeedPermission(AccountPermission.CreateAccount)]

        public JsonResult OnPostCreate(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var editAccount = _accountApplication.GetDetails(id);
            editAccount.Roles = _roleApplication.List();
            return Partial("./Edit", editAccount);

        }

       [NeedPermission(AccountPermission.EditAccount)]

        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetChangePassword(long id)
        {
            var chengepassword = new ChangePassword { Id = id };
            return Partial("./ChangePassword", chengepassword);

        }

        [NeedPermission(AccountPermission.ChangePassword)]

        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetDeleteAccount(long id)
        {
             _accountApplication.DeleteAccount(id);
         
                return RedirectToPage("./Index");
          
           
        }
    }
}