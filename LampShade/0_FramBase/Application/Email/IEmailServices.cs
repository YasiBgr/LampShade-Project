using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FramBase.Application.Email
{
  public  interface IEmailServices
  {
      void SendEmail(string title, string messageBody, string destination);
  }
}
