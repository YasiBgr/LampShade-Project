﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Contract.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public long InventoryId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string code { get; set; }
        public long CurrentCount { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string CategorySlug { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public double doublePrice { get; set; }
        public string PriceWithDiscount { get; set; }
        public bool HasDiscount { get; set; }
        public int DiscountRate { get; set; }
        public bool IsInStock { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
        public List<CommentQueryModel> Comments { get; set; }

        public string DiscountExpirationDate { get; set; }
    }


    public class ProductPictureQueryModel
    
    {
        public long ProductId { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public bool IsDeleted { get;  set; }
    }




    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate{ get; set; }
        public long ParentId { get; set; }
        public string parentName { get; set; }

    }
}


