using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.ProductCategory;

namespace _01_LampshadeQuery.Contract.Orders
{
   public interface IOrderQuery
   {
       long GeProductOrderCount(long orderId,long productId);
   }
}
