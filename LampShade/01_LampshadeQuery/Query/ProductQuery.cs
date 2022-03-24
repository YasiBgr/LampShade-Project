using _0_FramBase.Application;
using _01_LampshadeQuery.Contract.Product;
using DiscountManagment.Infrastructure.efCore;
using InventoryManagement.Infrastructure.efCore;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.CommentAgg;
using ShopManagment.Domain.ProductPictureAgg;
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

        public ProductQueryModel GetProductDetails(string slug)
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
                         new {
                             x.ProductId, x.UnitPrice,x.Id, x.InStock}).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new
                { x.DicountRate, x.ProductId,x.EndDate }).ToList();

            
            var product = _context.Products
                .Include(x => x.Category)
                .Include(x=>x.ProductPictures)
                .Include(x=>x.Comments)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    code=x.Code,
                    Category=x.Category.Name,
                    Slug = x.Slug,
                    CategorySlug=x.Category.Slug,
                  Picture=x.Picture,
                  PictureAlt=x.PictureAlt,
                  PictureTitle=x.PictureTitle,
                  ShortDescription=x.ShortDescription,
                  Description=x.Description, 
                 Pictures=MapProductPicture(x.ProductPictures),
                 Comments=MapComment(x.Comments)
                }).AsNoTracking().FirstOrDefault(x=>x.Slug==slug);
                  

            if (product == null)
                return new ProductQueryModel();
            var productInventory = inventory.FirstOrDefault
                (x => x.ProductId == product.Id);
                if (productInventory != null)
                {

                product.IsInStock = productInventory.InStock;
                    var Price = productInventory.UnitPrice;
                product.Price = Price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    
                    //var inventoryCurrentCount = inventoryOperation.FirstOrDefault(x => x.InventoryId == item.InventoryId).CurrentCount;
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
            return product;
            }

        private static List<CommentQueryModel> MapComment(List<Comment> comments)
        {
            return comments.Where(x => x.Status == Statuses.Confirmed).Select(x => new CommentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                Status = x.Status
            }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<ProductPictureQueryModel> MapProductPicture(List<ProductPicture> productPictures)
        {
            return productPictures.Select(x => new ProductPictureQueryModel
            {
                ProductId = x.ProductId,
                IsDeleted = x.IsDeleted,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Picture = x.Picture
            }).Where(x => !x.IsDeleted).ToList();
        }

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
                         new {
                             x.ProductId,
                             x.UnitPrice,
                             x.Id,
                             x.InStock
                         }).ToList();

            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new
                { x.DicountRate, x.ProductId, x.EndDate }).ToList();


            var query = _context.Products
                .Include(x => x.Category).Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    ShortDescription=product.ShortDescription,
                    CategorySlug=product.Category.Slug,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    Slug = product.Slug,
                    Category = product.Category.Name

                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
           query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));
            var products = query.OrderByDescending(x => x.Id).ToList();


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
                        product.DiscountExpirationDate = discount.EndDate.ToDiscountFormat();
                    }
                }

            }
            return products;
        }
    }
    }
