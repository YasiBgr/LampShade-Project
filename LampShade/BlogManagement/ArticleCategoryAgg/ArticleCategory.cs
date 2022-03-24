using _0_FramBase.Domain;
using BlogManagement.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Slug { get; private set; }
        public int ShowOrder { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public string Keywords { get; private set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string picture, string pictureAlt,
            string pictureTitle, string shortDescription, string slug, int showOrder,
            string metaDescription, string canonicalAddress, string keywords)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Slug = slug;
            ShowOrder = showOrder;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            Keywords = keywords;
        }

        public void Edit(string name, string picture, string pictureAlt,
            string pictureTitle, string shortDescription,
            string slug, int showOrder, string metaDescription, string keywords, string canonicalAddress)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Slug = slug;
            ShowOrder = showOrder;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
           
            Keywords = keywords;
        }
    }

}
