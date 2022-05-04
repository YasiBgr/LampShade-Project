using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.Services
{
   public interface IShopAccountAcl
   {
       (string name, string number) GetAccountBy(long id);
   }
}
