using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contract.Orders
{
   public class OrderModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public string ProductCategory { get; set; }
        public long OrderCount { get; set; }
        public string CreationDate { get; set; }    
    }
}
