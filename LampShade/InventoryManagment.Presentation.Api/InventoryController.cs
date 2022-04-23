using InventoryManagement.Applicatopn.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagment.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryApplication _inventoryApplication;

        public InventoryController(IInventoryApplication inventoryApplication)
        {
            _inventoryApplication = inventoryApplication;
        }
        [HttpGet("{id}")]
        public List<InventoryOperationViewModel> GetInventoryOperationsBy(long id)
        {
            return _inventoryApplication.GetOperationLog(id);
        } 
    }
}
