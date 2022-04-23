using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FramBase.Application.ZarinPal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiseHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PaymentResult Result;

        public void OnGet(PaymentResult result)
        {
            Result = result;
        }
    }
}
