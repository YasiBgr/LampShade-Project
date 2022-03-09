﻿using ShopManagmentAplication.Contracts.Product.folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        public long ProducrId { get; set; }
        public int DiscountRate { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
