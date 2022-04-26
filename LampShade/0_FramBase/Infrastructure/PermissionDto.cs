using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FramBase.Infrastructure
{
  public  class PermissionDto
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public PermissionDto(string name, int code)
        {
            Name = name;
            Code = code;
        }
    }
}
