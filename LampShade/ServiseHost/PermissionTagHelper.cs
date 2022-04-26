using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_FramBase.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiseHost
{
    [HtmlTargetElement(Attributes = "Permission")]
    public class PermissionTagHelper:TagHelper
    {
        public int Permission { get; set; }
        private readonly IAuthHelper _authHelper;

        public PermissionTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Equals(!_authHelper.IsAuthenticated()))
            {
                output.SuppressOutput();
                return;
            }

            var permission = _authHelper.GetPermissions();
            if (!permission.Any(x=>x==Permission))
            {
                output.SuppressOutput();
                return; 
            }
            base.Process(context, output);
        }
    }
}
