using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FramBase.Infrastructure;

namespace AccountManagement.Configuration.Permission
{
    public class AccountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Account", new List<PermissionDto>
                    {
                        new PermissionDto("CreateAccount", AccountPermission.CreateAccount),
                        new PermissionDto("EditAccount", AccountPermission.EditAccount),
                        new PermissionDto("ListAccount", AccountPermission.ListAccount),
                        new PermissionDto("ChangePasswordAccount", AccountPermission.ChangePassword),
                    }

                },

                {
                    "Role",
                    new List<PermissionDto>
                    {
                        new PermissionDto("CreateRole", AccountPermission.CreateRole),
                        new PermissionDto("EditRole", AccountPermission.EditRole),
                        new PermissionDto("ListRole", AccountPermission.ListRole),
                    }

                }
            };
        }
    }
}