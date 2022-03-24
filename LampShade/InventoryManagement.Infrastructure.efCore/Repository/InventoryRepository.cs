using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using InventoryManagement.Applicatopn.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagment.Infrastructure.efCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.efCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Unitprice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel 
            {
            Id=x.Id,
            Count=x.Count,
            CurrentCount=x.CurrentCount,
            Description=x.Description,
            Operation=x.Operation   ,
            OperationDate=x.OperationDate.ToFarsi(),
            Operator="مدیر",
            OperatorId=x.OperatorId,
            OrderId=x.OrderId
            }).OrderByDescending(x=>x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                InStock = x.InStock,
                CurrentCount = x.CalculateInventoryStock(),
                Unitprice = x.UnitPrice,
                CreationDate=x.CreationDate.ToFarsi()
                
                
            });

            if (searchModel.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == searchModel.ProductId);
            }
            if (searchModel.InStock)
            {
                query = query.Where(x => !x.InStock);
            }

            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item =>
            {
                item.Product = product.FirstOrDefault(x =>
                x.Id == item.ProductId)?.Name;
            });
            return inventory;
        }
    }
}
