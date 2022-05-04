namespace ShopManagmentAplication.Contracts.Product.folder
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CreationDate { get; set; }
        public string Picture { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public long Id { get; set; }
        public bool Delete { get; set; }
    }
}
