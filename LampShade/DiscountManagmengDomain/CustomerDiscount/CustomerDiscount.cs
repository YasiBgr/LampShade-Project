using _0_FramBase.Domain;
using System;

namespace DiscountManagmengDomain.CustomerDiscount
{
    public class CustomerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DicountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Occasion { get; private set; }

        public CustomerDiscount(long productId, int dicountRate,
            DateTime startDate, DateTime endDate, string occasion)
        {
            ProductId = productId;
            DicountRate = dicountRate;
            StartDate = startDate;
            EndDate = endDate;
            Occasion = occasion;
        }
        public void Edit(long productId, int dicountRate,
           DateTime startDate, DateTime endDate, string occasion)
        {
            ProductId = productId;
            DicountRate = dicountRate;
            StartDate = startDate;
            EndDate = endDate;
            Occasion = occasion;
        }
    }
}
