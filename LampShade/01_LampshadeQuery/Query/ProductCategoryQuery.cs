using _0_FramBase.Application;
using _01_LampshadeQuery.Contract.Product;
using _01_LampshadeQuery.Contract.ProductCategory;
using DiscountManagment.Infrastructure.efCore;
using InventoryManagement.Infrastructure.efCore;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
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
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetListProductCategory()
        {
          
            var productCategory= _context.ProductCategories
                .Include(x=>x.products)
                .Select(x => new ProductCategoryQueryModel {
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Id  =x.Id,
            Delete = x.Delete
               
            }).Where(x => !x.Delete).AsNoTracking().ToList();

            return productCategory;
        }

        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
               new {
                   x.ProductId, x.UnitPrice
                   }).ToList();

            var discounts = _discountContext.CustomerDiscounts.Where(x=>x.StartDate<DateTime.Now && x.EndDate>DateTime.Now)
                .Select(x => new
            {
                x.DicountRate,
                x.ProductId
            }).ToList();

          
            var categories = _context.ProductCategories
                .Include(x=>x.products)
                .ThenInclude(x=>x.Category).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Products = MapProduct(x.products),
                Delete = x.Delete
            }).Where(x => !x.Delete).AsNoTracking().ToList();
            foreach (var category in categories)
            {   
                foreach (var product in category.Products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null && !product.Delete)
                    {
                        var Price = inventory.FirstOrDefault(x => x.ProductId == product.Id).UnitPrice;
                        product.Price = Price.ToMoney();
                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int discountRate = discount.DicountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((Price * discountRate) / 100);
                            product.PriceWithDiscount = (Price - discountAmount).ToMoney();
                        }
                    }
                    
                }
            }
            return categories;
        }

        private static List<ProductQueryModel> MapProduct(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                Category = product.Category.Name,
                Delete = product.Delete

            }).Where(x => !x.Delete).ToList();
        }
      
        public ProductCategoryQueryModel GetProductCategoryWithProductsby(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
                          new {
                              x.ProductId,
                              x.UnitPrice
                          }).ToList();

            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.DicountRate,
                    x.ProductId,
                    x.EndDate
                }).ToList();


            var category = _context.ProductCategories
                .Include(x => x.products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProduct(x.products),
                    Slug=x.Slug,
                    Keywords=x.Keywords,
                    MetaDescription=x.MetaDescription,
                    Delete = x.Delete

                }).Where(x => !x.Delete)
                .AsNoTracking()
                .FirstOrDefault(x=>x.Slug==slug);
           
                foreach (var product in category.Products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var Price = inventory.FirstOrDefault(x => x.ProductId == product.Id).UnitPrice;
                        product.Price = Price.ToMoney();
                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int discountRate = discount.DicountRate;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((Price * discountRate) / 100);
                            product.PriceWithDiscount = (Price - discountAmount).ToMoney();
                        product.DiscountExpirationDate = discount.EndDate.ToDiscountFormat();
                           
                        }
                    }

                }
            
            return category;
        }
    }
}
