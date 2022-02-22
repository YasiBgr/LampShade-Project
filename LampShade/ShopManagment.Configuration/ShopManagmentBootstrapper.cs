using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagment.Aplication;
using ShopManagment.Domain.ProductCategoryAgg;
using ShopManagment.Infrastructure.efCore;
using ShopManagment.Infrastructure.efCore.Repository;
using ShopManagmentAplication.Contracts.ProductCategory;


namespace ShopManagment.Configuration
{
    public class ShopManagmentBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
