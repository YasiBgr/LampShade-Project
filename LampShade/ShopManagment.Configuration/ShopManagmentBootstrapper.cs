using _01_LampshadeQuery.Contract;
using _01_LampshadeQuery.Contract.Product;
using _01_LampshadeQuery.Contract.ProductCategory;
using _01_LampshadeQuery.Contract.Slide;
using _01_LampshadeQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Aplication;
using ShopManagment.Domain.OrderAgg;
using ShopManagment.Domain.ProductAgg;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Domain.ProductPictureAgg;
using ShopManagment.Domain.Services;
using ShopManagment.Domain.SliderAgg;
using ShopManagment.Infrastructure.efCore;
using ShopManagment.Infrastructure.efCore.Repository;
using ShopManagment.Infrastructure.InventoryAcl;
using ShopManagmentAplication.Contracts.Order;
using ShopManagmentAplication.Contracts.Product.folder;
using ShopManagmentAplication.Contracts.ProductCategory;
using ShopManagmentAplication.Contracts.ProductPictureFolder;
using ShopManagmentAplication.Contracts.Slide.Folder;

namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ICartCalculatorService, CartCalculatorService>();

            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
                                                     

            services.AddSingleton<ICartService, CartService>();


            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
