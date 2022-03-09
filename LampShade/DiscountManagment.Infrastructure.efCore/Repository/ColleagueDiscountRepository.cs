using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using DiscountManagmengDomain.ColleagueDiscount;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using ShopManagment.Infrastructure.efCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Infrastructure.efCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountManagmentContext _context;
        private readonly ShopContext _shopcontext;

        public ColleagueDiscountRepository(DiscountManagmentContext context, ShopContext shopcontext) : base(context)
        {
            _context = context;
            _shopcontext = shopcontext;
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _context.ColleagueDiscounts.Select(x => new EditColleagueDiscount 
            {
            Id=x.Id,
            DiscountRate=x.DiscountRate,
            ProducrId=x.ProductId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            var products = _shopcontext.Products.Select(x => new { x.Id, x.Name });
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel 
            {
            Id=x.Id,
            CreationDate=x.CreationDate.ToFarsi(),
            DiscountRate=x.DiscountRate,
            ProductId=x.ProductId
            });

            if (command.ProductId>0)
                query = query.Where(x => x.ProductId == command.ProductId);
            var discounts = query.OrderByDescending(x => x.Id).ToList();
            discounts.ForEach(discount => 
            discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
        }
    }
}
