using _0_FramBase.Domain;
using DiscountManagment.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagmengDomain.CustomerDiscount
{
    public interface ICustomerDiscountRepository:IRepository<long, CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command);

    }
}
