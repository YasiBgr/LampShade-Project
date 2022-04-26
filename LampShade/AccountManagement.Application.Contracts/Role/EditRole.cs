﻿using _0_FramBase.Infrastructure;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto> MapPermissions { get; set; }
        public EditRole()
        {
            Permissions = new List<int>();
        }
    }
}
