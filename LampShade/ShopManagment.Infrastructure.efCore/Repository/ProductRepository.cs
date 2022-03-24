using _0_FramBase.Application;
using _0_FramBase.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagment.Domain.ProductAgg;
using ShopManagmentAplication.Contracts.Product.folder;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagment.Infrastructure.efCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;


        public ProductRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct{
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Id = x.Id,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
               // Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);

        }

        public Product GetCategoryWithProduct(long id)
        {
            return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetPruducts()
        {
            return _context.Products.Select(
                x => new ProductViewModel { 
                    Name = x.Name,
                    Id = x.Id
                }).ToList();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Select(x => new ProductViewModel
            {
                Id=x.Id,
                Category = x.Category.Name,
                Name = x.Name,
                Code = x.Code,
                CategoryId=x.CategoryId,
                Picture = x.Picture,
                CreationDate=x.CreationDate.ToFarsi()
               
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.CategoryId!=0)
                query = query.Where(x => x.CategoryId==searchModel.CategoryId);

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
