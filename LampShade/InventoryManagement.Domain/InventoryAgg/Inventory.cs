using _0_FramBase.Domain;
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
        public List<InventoryOperations> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Edit (long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
           
        }

        public long CalculateInventoryStock()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateInventoryStock() + count;
            var operation = new InventoryOperations(true, count, operatorId, 0, currentCount, description, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;

        }
        public void Reduce(long count, long operatorId, string description,long orderId)
        {
            var currentCount = CalculateInventoryStock() - count;
            var operation = new InventoryOperations(false,count,operatorId,orderId,currentCount,description,Id);
            Operations.Add(operation);
            InStock = currentCount > 0;

        }

      
    }
}
