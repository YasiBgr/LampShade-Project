using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FramBase.Infrastructure;

namespace DiscountManagment.Configurations.Permission
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                "ColleagueDiscount",new List<PermissionDto>
                {

                    new PermissionDto("DefineDiscount", DiscountPermission.DefineColleagueDiscount),
                    new PermissionDto("EditDiscount", DiscountPermission.EditColleagueDiscount),
                    new PermissionDto("ListDiscount", DiscountPermission.ListColleagueDiscount),
                    new PermissionDto("RemoveDiscount", DiscountPermission.RemoveColleagueDiscount),
                    new PermissionDto("RestoreDiscount", DiscountPermission.RestoreColleagueDiscount),
                      }

                },


                {
                    "CustomerDiscount",
                    new List<PermissionDto>
                    {
                        new PermissionDto("DefineDiscount", DiscountPermission.DefineCustomerDiscount),
                        new PermissionDto("EditDiscount", DiscountPermission.EditCustomerDiscount),
                        new PermissionDto("ListDiscount", DiscountPermission.ListCustomerDiscount),
                        new PermissionDto("RemoveDiscount", DiscountPermission.RemoveCustomerDiscount),
                        new PermissionDto("RestoreDiscount", DiscountPermission.RestoreCustomerDiscount),
                    }
                }
            };
        }
    }
}
