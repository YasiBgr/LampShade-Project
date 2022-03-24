using _0_FramBase.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Slide.Folder
{
    public class CreateSlide
    {
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Text { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Title { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Heading { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string BtnText { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Link { get; set; }
    }
}
