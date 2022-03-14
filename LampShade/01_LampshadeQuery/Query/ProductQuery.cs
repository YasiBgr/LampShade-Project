using _0_FramBase.Application;
using _01_LampshadeQuery.Contract.Product;
using DiscountManagment.Infrastructure.efCore;
using InventoryManagement.Infrastructure.efCore;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.efCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _context = context;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductQueryModel> GetLatestArrivals()
        {

            var products = _context.Products.Include(x => x.Category).Select(x => new ProductQueryModel
            {
                Name = x.Name,
                Category = x.Category.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Id = x.Id
            }).OrderByDescending(x=>x.Id).Take(6).ToList();



            var inventory = _inventoryContext.Inventory.Select(x =>
               new {
                   x.ProductId,
                   x.UnitPrice
               }).ToList();

            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new
                {
                    x.DicountRate,
                    x.ProductId
                }).ToList();
            foreach (var product in products)
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
                    }
                }

            }

            return products;
        }
    }
}
