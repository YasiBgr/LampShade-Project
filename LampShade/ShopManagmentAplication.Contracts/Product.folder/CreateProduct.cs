using _0_FramBase.Application;
using Microsoft.AspNetCore.Http;
using ShopManagmentAplication.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagmentAplication.Contracts.Product.folder
{
    public class CreateProduct
    {

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Code { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }


        [FileExtentionLimitation(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = ValidationMessages.InValidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile Picture { get; set; }


        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Range(1,100000,ErrorMessage =ValidationMessages.IsRequaierd)]
        public long CategoryId { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string KeyWords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string MetaDescription { get; set; }
        public List<ProductCategoryViewModel> Category { get; set; }
    }
}
