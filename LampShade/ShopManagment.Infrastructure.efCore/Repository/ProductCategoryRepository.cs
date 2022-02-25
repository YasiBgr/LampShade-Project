using _0_FramBase.Domain;
using _0_FramBase.Infrastructure;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagmentAplication.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.efCore.Repository
{
    public class ProductCategoryRepository :RepositoryBase<long,ProductCategory>,IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x=> new EditProductCategory()
            {
                Id=x.Id,
                Description=x.Description,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Name=x.Name,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductCategoryViewModel> GetList()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel { 
                Id=x.Id,
                Name=x.Name
            }).ToList();
        }

        public List<ProductCategoryViewModel> search(ProductCategorySearchModel searchModel)
        {
            var query= _context.ProductCategories.Select(x => new ProductCategoryViewModel() 
            { 
            Id=x.Id,
            Name=x.Name,
            CreationDate=x.CreationDate.ToString(),
            Pictiure=x.Picture
            });

           
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            
                query = query.Where(x => x.Name.Contains(searchModel.Name));
           
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
