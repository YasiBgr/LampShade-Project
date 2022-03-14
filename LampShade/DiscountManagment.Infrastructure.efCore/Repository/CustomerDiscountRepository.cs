using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using DiscountManagmengDomain.CustomerDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Infrastructure.efCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Infrastructure.efCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount 
            {
            Id=x.Id,
            DicountRate=x.DicountRate,
            EndDate=x.EndDate.ToString(),
            Occasion=x.Occasion,
            ProductId=x.ProductId,
            StartDate=x.StartDate.ToString()
            }).FirstOrDefault(x => x.Id == id);
            
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel command)
        {
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name,x.CategoryId }).ToList();
            var category = _shopContext.ProductCategories.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                DicountRate = x.DicountRate,
                EndDate = x.EndDate.ToFarsi(),
                Occasion = x.Occasion,
                ProductId = x.ProductId,
                Id = x.Id,
                StartDate = x.StartDate.ToFarsi(),
                EndDateGr=x.EndDate,
                StartDateGr=x.StartDate,
                CreationDate=x.CreationDate.ToFarsi()
                
                
            });
            if (command.ProductId > 0)
                query = query.Where(x => x.ProductId == command.ProductId);

            if (!string.IsNullOrWhiteSpace(command.StartDate))
            {
                query = query.Where(x => x.StartDateGr < command.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(command.EndDate))
            {
                query = query.Where(x => x.EndDateGr < command.EndDate.ToGeorgianDateTime());
            }
            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount => discount.Product = product.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);
            discounts.ForEach(discount => discount.CategortId = product.FirstOrDefault(x => x.Id == discount.ProductId).CategoryId);
            discounts.ForEach(discount => discount.ProductCategory = category.FirstOrDefault(x => x.Id == discount.CategortId)?.Name);
            return discounts;
           
        }
    }
}
