using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastracture.efcore.Repository
{
    public class RoleRepository : RepositoryBase<long, Role>, IRoleRepository
    {
        private readonly AccountContext _accountContext;

        public RoleRepository(AccountContext accountContext):base(accountContext)
        {
            _accountContext = accountContext;
        }

        public EditRole GetDetails(long id)
        {
           var role = _accountContext.Roles.Select(x => new EditRole
            {
                Id = x.Id,
                Name = x.Name,
                MapPermissions = MapPermission(x.Permissions)
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);

            role.Permissions = role.MapPermissions.Select(x => x.Code).ToList();

            return role;
        }

        private static List<PermissionDto> MapPermission(List<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Name, x.Code)).ToList();
        }

        public List<RoleViewModel> List()
        {
            return _accountContext.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Name =x.Name
            }).ToList();

        }
    }
}
