using InventoryManagement.Applicatopn.Contracts.Inventory;
using ShopManagment.Domain.OrderAgg;
using ShopManagment.Domain.Services;
using System;
using System.Collections.Generic;

namespace ShopManagment.Infrastructure.InventoryAcl
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication _inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }

        public bool ReduseFromInventory(List<OrderItem> items)
        {
            List<ReduseInventory> command = new List<ReduseInventory>();
            foreach (var orderItem in items)
            {
                var item = new ReduseInventory(orderItem.ProductId,
                    orderItem.Count, "خرید مشتری", orderItem.OrderId);
                command.Add(item);
            }
            return _inventoryApplication.Reduse(command).IsSuccedded;
        }
    }
}
