using ShopManagmentAplication.Contracts.Product.folder;
using System.Collections.Generic;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get; set; }
        public int DicountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Occasion { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }
}
