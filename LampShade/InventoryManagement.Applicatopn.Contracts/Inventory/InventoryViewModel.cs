namespace InventoryManagement.Applicatopn.Contracts.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public bool InStock { get; set; }
        public long CurrentCount { get; set; }
        public long ProductId { get; set; }
        public double Unitprice { get; set; }
    }
}
