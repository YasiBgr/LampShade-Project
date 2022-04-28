using InventoryManagement.Applicatopn.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using _01_LampshadeQuery.Contract.Inventory;

namespace InventoryManagment.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryApplication _inventoryApplication;
        private readonly IInventoryQuery _inventoryQuery;
        public InventoryController(IInventoryApplication inventoryApplication, IInventoryQuery inventoryQuery)
        {
            _inventoryApplication = inventoryApplication;
            _inventoryQuery = inventoryQuery;
        }
        [HttpGet("{id}")]
        public List<InventoryOperationViewModel> GetInventoryOperationsBy(long id)
        {
            return _inventoryApplication.GetOperationLog(id);
        }

        [HttpPost]
        public StockStatus checkStock(IsInStock command)
        {
            return _inventoryQuery.CheckStock(command);
        }
    }
}
