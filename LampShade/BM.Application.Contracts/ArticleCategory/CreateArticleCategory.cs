using _0_FramBase.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Name { get; set; }

        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Slug { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public int ShowOrder { get; set; }

        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
      

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Keywords { get; set; }
    }
}
