using _0_FramBase.Domain;
using _0_FramBase.Infrastructure;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagmengDomain.ColleagueDiscount
{
    public interface IColleagueDiscountRepository : IRepository<long, ColleagueDiscount>
    {

        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command);
    }
}
