using System.ComponentModel.DataAnnotations;
using _0_FramBase.Application;
using Microsoft.AspNetCore.Http;

namespace ShopManagmentAplication.Contracts.ProductCategory.folder
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Name { get; set; }
        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" },ErrorMessage =ValidationMessages.InValidFileFormat)]
        [MaxFileSize(3*1024 * 1024, ErrorMessage =ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string MetaDescription { get; set; }
        [Required(ErrorMessage =ValidationMessages.IsRequaierd)]
        public string Slug { get; set; }
        [Required(ErrorMessage =ValidationMessages.IsRequaierd)]
        public string Keywords { get; set; }
    }
}
