using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Orders;
using _01_LampshadeQuery.Contract.ProductCategory;
using ShopManagmentAplication.Contracts.Order;

namespace _01_LampshadeQuery.Query
{
   public class OrderQuery:IOrderQuery
   {
       private readonly IOrderApplication _orderApplication;

       public OrderQuery(IOrderApplication orderApplication)
       {
           _orderApplication = orderApplication;
       }

       public long GeProductOrderCount(long orderId, long productId)
       {
         var items=  _orderApplication.GetItems(orderId);
         var product = items.Where(x => x.ProductId == productId).Count();
         return product;
       }
    }
}
