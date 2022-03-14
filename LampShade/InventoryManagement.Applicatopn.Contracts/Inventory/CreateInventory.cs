using _0_FramBase.Application;
using ShopManagmentAplication.Contracts.Product.folder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Applicatopn.Contracts.Inventory
{
    public class CreateInventory
    {
        [Range(1,100000,ErrorMessage =ValidationMessages.IsRequaierd)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequaierd)]
        public double Unitprice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
