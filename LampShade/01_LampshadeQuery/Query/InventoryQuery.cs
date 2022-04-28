using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contract.Inventory;
using InventoryManagement.Infrastructure.efCore;
using ShopManagment.Infrastructure.efCore;

namespace _01_LampshadeQuery.Query
{
   public class InventoryQuery:IInventoryQuery
   {
       private readonly InventoryContext _inventoryContext;
       private readonly ShopContext _shopContext;

       public InventoryQuery(InventoryContext inventoryContext, ShopContext shopContext)
       {
           _inventoryContext = inventoryContext;
           _shopContext = shopContext;
       }

       public StockStatus CheckStock(IsInStock command)
       {
           var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == command.ProductId);
           var Product = _shopContext.Products.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == command.ProductId);

            if (inventory==null || inventory.CalculateInventoryStock()< command.Count)
           {
               return new StockStatus()
               {
                   IsStock = false,
                   ProductName = Product?.Name

               };
           }

           return new StockStatus()
           {
               IsStock = true,
               ProductName = Product?.Name
           };
       }
    }
}
