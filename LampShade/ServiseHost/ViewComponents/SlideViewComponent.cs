using _01_LampshadeQuery.Contract.Slide;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiseHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }

        public IViewComponentResult Invoke()
        {
            var slider = _slideQuery.GetSlide();
            return View(slider);
        }
    }
}
