using _01_LampshadeQuery.Contract.Slide;
using ShopManagment.Infrastructure.efCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlide()
        {
            return _shopContext.Slides.Where(x => x.IsRemove == false)
                .Select(x => new SlideQueryModel
                {
                    BtnText = x.BtnText,
                    Heading = x.Heading,
                    Link = x.Link,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Text = x.Text,
                    Title = x.Title
                }).ToList();
        }
    }
}
