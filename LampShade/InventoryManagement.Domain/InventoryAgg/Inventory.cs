using _0_FramBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }


        private long CalculateInventoryStock()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateInventoryStock() + count;
            var operation = new InventoryOperation(true, count, operatorId, 0, currentCount, description, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;

        }
        public void Reduce(long count, long operatorId, string description,long orderId)
        {
            var currentCount = CalculateInventoryStock() - count;
            var operation = new InventoryOperation(false, count, operatorId, 0, currentCount, description, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;

        }
    }
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public long OrderId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; private set; }

        public InventoryOperation(bool operation, long count, long operatorId, long orderId, 
            long currentCount, string description, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            OrderId = orderId;
            CurrentCount = currentCount;
            Description = description;
            InventoryId = inventoryId;
        }
    }
}
