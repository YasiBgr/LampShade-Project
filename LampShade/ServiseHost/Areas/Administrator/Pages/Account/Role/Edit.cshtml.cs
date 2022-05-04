using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ServiseHost.Areas.Administrator.Pages.Account.Role
{
    public class EditModel : PageModel
    {
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposer;
        public EditRole command;
        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposer)
        {
            _roleApplication = roleApplication;
            _exposer = exposer;
        }


        public void OnGet(long id)
        {
            command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposer)
            {
                var exposePermission = exposer.Expose();
                foreach (var (key, value) in exposePermission)
                {
                    var group = new SelectListGroup
                    {
                        Name = key
                    };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };
                        if (command.MapPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }

        }
        public IActionResult OnPost(EditRole command)
        {
            var result = _roleApplication.EditRole(command);
            return RedirectToPage("Index");
        }
    }
}
