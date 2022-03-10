using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Applicatopn.Contracts.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; set; }
        public double Unitprice { get; set; }
    }
}
