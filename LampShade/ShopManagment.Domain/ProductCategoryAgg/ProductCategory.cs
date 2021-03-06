using _0_FramBase.Domain;
using ShopManagment.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Domain.ProductCategoryAgg
{
   public class ProductCategory :EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureTitle { get; private set; }
        public string PictureAlt { get; private set; }
        public string Description { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public bool Delete { get; private set; }
        public List<Product> products{ get; private set; }
        

        public ProductCategory(string name, string picture, string pictureTitle, string pictureAlt,
            string description, string metaDescription, string slug, string keywords)
        {
            Name = name;
            Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Description = description;
            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
            Delete = false;
        }
        public void Edit(string name, string picture, string pictureTitle, string pictureAlt,
            string description, string metaDescription, string slug, string keywords)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
             Picture = picture;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            Description = description;
            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
        }

        public void DeleteCategory()
        {
            this.Delete = true;
        }
        public void RestoreCategory()
        {
            this.Delete = false;
        }

    }

}
