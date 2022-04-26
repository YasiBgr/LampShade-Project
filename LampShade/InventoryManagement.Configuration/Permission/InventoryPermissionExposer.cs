using _0_FramBase.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Configuration.Permission
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
          {
              {

                    "Inventory",  new List<PermissionDto>
                    {
                        new PermissionDto("ListInventory", InventoryPermission.ListInventory),
                        new PermissionDto("SearchInventory", InventoryPermission.SearchInventory),
                        new PermissionDto("CreateInventory", InventoryPermission.CreateInventory),
                        new PermissionDto("EditInventory", InventoryPermission.EditInventory),
                        new PermissionDto("ReduceInventory", InventoryPermission.ReduceInventory),
                        new PermissionDto("IncreaseInventory", InventoryPermission.IncreaseInventory),
                        new PermissionDto("OperationLog", InventoryPermission.OperationLog),
                    }
              }
          };
        }
    }
}
