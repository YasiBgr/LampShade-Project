using _0_FramBase.Application;
using Microsoft.AspNetCore.Http;
using ShopManagmentAplication.Contracts.Product.folder;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagmentAplication.Contracts.ProductPictureFolder
{
    public class CreateProductPicture
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequaierd)]
        public long ProductId { get; set; }
        
        [MaxFileSize(1*1024*1024,ErrorMessage =ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]

        public string PictureTitle { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
