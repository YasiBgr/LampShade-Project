using _01_LampshadeQuery.Contract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contract.ArticleCategory
{
   public class ArticleCategoryQueryModel
    {
        public string Name { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string ShortDescription { get;  set; }
        public string Slug { get;  set; }
        public int ShowOrder { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalAddress { get;  set; }
        public string Keyword { get;  set; }
        public List<string> Keywords { get; set; }
        public List<ArticleQueryeModel> Articles { get; set; }
        public long ArticleCount { get;  set; }
    }
}
