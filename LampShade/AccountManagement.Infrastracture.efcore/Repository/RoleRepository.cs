using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.RoleAgg;
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
            return _accountContext.Roles.Select(x => new EditRole
            {
                Id = x.Id, 
                Name = x.Name 
            }).FirstOrDefault(x => x.Id == id);
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
