﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiseHost.ViewComponents
{
    public class FooterViewComponent:ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
