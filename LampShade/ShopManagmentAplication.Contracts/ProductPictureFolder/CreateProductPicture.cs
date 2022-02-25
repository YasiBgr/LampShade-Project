using _0_FramBase.Application;
using ShopManagmentAplication.Contracts.Product.folder;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagmentAplication.Contracts.ProductPictureFolder
{
    public class CreateProductPicture
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequaierd)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequaierd)]

        public string PictureTitle { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
