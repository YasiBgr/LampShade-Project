namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {
        public long ProductId { get; set; }
      //  public string ProductCategory { get; set; }
        public long CategoryId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
