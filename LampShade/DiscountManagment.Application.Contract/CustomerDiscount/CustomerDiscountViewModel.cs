﻿using System;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long CategortId { get; set; }
        public string Product { get; set; }
        public string ProductCategory { get; set; }
        public int DicountRate { get; set; }
        public string StartDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public string EndDate { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Occasion { get; set; }
        public string CreationDate { get; set; }
    }
}
