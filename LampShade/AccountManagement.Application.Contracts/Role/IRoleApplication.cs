using _0_FramBase.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Role
{
   public interface IRoleApplication
    {
        OperationResult CreateRole(CreateRole command);
        OperationResult EditRole(EditRole command);
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
