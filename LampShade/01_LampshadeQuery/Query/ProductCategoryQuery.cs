﻿using _01_LampshadeQuery.Contract.ProductCategory;
using ShopManagment.Infrastructure.efCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetListProductCategory()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryQueryModel {
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Id  =x.Id
            }).ToList(); 
        }
    }
}
