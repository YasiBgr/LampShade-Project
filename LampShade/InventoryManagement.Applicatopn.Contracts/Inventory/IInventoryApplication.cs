using _0_FramBase.Application;
using System.Collections.Generic;

namespace InventoryManagement.Applicatopn.Contracts.Inventory
{
    public  interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduse(List<ReduseInventory> command);
        OperationResult Reduse(ReduseInventory command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
        
    }
}
