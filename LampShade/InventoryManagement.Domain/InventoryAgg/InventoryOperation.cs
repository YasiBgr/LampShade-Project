﻿using System;

namespace InventoryManagement.Domain.InventoryAgg
{
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
