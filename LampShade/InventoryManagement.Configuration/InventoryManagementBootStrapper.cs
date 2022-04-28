using _0_FramBase.Infrastructure;
using InventoryManagement.Applicatopn.Contracts.Inventory;
using InventoryManagement.Configuration.Permission;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.efCore;
using InventoryManagement.Infrastructure.efCore.Repository;
using InventoryManagementApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using _01_LampshadeQuery.Contract.Inventory;
using _01_LampshadeQuery.Query;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootStrapper

    {
           public static void Configure(IServiceCollection services, string Connectionstring)
            {
                services.AddTransient<IInventoryRepository, InventoryRepository>();
                services.AddTransient<IInventoryApplication, InventoryApplication>();
         
            services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
                
            services.AddTransient<IInventoryQuery, InventoryQuery>();


            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(Connectionstring));
            }
     

    }
}
