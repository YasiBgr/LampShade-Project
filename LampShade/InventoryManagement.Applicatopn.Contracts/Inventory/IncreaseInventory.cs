using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Applicatopn.Contracts.Inventory
{
    public class IncreaseInventory
    {
        public long InventoryId { get; set; }
        public long Count1 { get; set; }
        public string Description { get; set; }
    }
}
