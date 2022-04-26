using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServiseHost
{
    public class SecurityPageFilter:IPageFilter
    {
        private readonly IAuthHelper _AuthHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _AuthHelper = authHelper;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlePermission =(NeedPermissionAttribute) context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedPermissionAttribute));

            var accountPermission = _AuthHelper.GetPermissions();
            if (handlePermission==null)
            return;
            if (accountPermission.All(x=>x!=handlePermission.Permission))
            {
             context.HttpContext.Response.Redirect("/Account");   
            }
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
           
        }
    }
}
