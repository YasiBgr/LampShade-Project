using _0_FramBase.Application;
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
        public double UnitPrice { get; set; }

        public bool IsInStock { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
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
