using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FramBase.Application;
using AccountManagement.Application.Contracts.Account.folder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Pages
{
    public class AccountModel : PageModel
    {
     [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }
        public OperationResult result;
        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
           
        }

      
        public IActionResult OnPostLogin(Login command)
        {
             result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");

                LoginMessage = result.Message;
                return RedirectToPage("/Account");
           
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
        public IActionResult OnPostRegister(RegisterAccount registerAccount)
        {
            var result = _accountApplication.Register(registerAccount);
            if (result.IsSuccedded)
                RedirectToPage("/Index");
            RegisterMessage = result.Message;
          return  RedirectToPage("/Account");

        }
    }
}
