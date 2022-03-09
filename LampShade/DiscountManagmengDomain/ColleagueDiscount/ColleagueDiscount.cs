using _0_FramBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagmengDomain.ColleagueDiscount
{
   public class ColleagueDiscount:EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public bool IsRemoved { get; private set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;
        }


        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            IsRemoved = false;
        }

        public void Remove()
        {
            IsRemoved = true;
        }


        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
