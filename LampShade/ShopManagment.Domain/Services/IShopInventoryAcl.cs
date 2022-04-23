using ShopManagment.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.Services
{
   public interface IShopInventoryAcl
    {
        bool ReduseFromInventory(List<OrderItem> items);
    }
}
