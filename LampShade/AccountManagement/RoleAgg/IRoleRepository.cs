using _0_FramBase.Domain;
using AccountManagement.Application.Contracts.Role;
using System.Collections.Generic;

namespace AccountManagement.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}