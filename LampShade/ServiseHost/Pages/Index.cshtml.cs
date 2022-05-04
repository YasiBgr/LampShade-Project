using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FramBase.Application.Email;

namespace ServiseHost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmailServices _emailServices;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IEmailServices emailServices)
        {
            _logger = logger;
            _emailServices = emailServices;
        }

        public void OnGet()
        {
         //   _emailServices.SendEmail("hi","how are u","yasamanbagheri2@gmail.com");
        }
    }
}
