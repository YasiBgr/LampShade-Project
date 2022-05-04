using _0_FramBase.Domain;
using System.Collections.Generic;
using AccountManagement.AccountAgg;

namespace AccountManagement.RoleAgg
{
    public class Role:EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public bool Delete { get; private set; }
        protected Role()
        {

        }
        public Role(string name, List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
            Accounts = new List<Account>();
            Delete = false;
        }
        public void Edit(string name, List<Permission> permissions)
        {
            Name = name; 
            Permissions = permissions;
        }

        public void DeleteRole()
        {
            this.Delete = true;
        }
    }

}
