using _0_FramBase.Application;
using AccountManagement.Application.Contracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account.folder
{
    public class CreateAccount
    {

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Fullname { get; set; }        
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Username { get; set; }        
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Password { get; set; }        
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public long RollId { get; set; }
        public string Mobail { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
