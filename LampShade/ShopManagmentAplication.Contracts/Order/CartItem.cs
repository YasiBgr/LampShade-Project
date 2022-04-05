using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Order
{
   public class CartItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public string Picture { get; set; }
        public int Count { get; set; }
        public double TotalItemPrice { get; set; }

        public CartItem()
        {
            TotalItemPrice = UnitPrice * Count;
        }
    }
}
