using InventoryManagement.Applicatopn.Contracts.Inventory;
using ShopManagment.Domain.OrderAgg;
using ShopManagment.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagment.Infrastructure.InventoryACL1
{
    public class ShopInventoryAcl 
    {
        //private readonly IInventoryApplication _inventoryApplication;
        //public List<ReduceInventory> command;
        //public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        //{
        //    _inventoryApplication = inventoryApplication;
        //}

        //public bool ReduceFromInventory(List<OrderItem> items)
        //{

        //    command = items.Select(x =>
        //      new ReduceInventory(x.ProductId, x.Count, "خرید مشتری", x.OrderId))
        //        .ToList();

        //    return _inventoryApplication.Reduse(command).IsSuccedded();
        //}
    }
}