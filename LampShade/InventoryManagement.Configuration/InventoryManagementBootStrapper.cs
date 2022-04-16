using InventoryManagement.Applicatopn.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.efCore;
using InventoryManagement.Infrastructure.efCore.Repository;
using InventoryManagementApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootStrapper

    {
           public static void Configure(IServiceCollection services, string Connectionstring)
            {
                services.AddTransient<IInventoryRepository, InventoryRepository>();
                services.AddTransient<IInventoryApplication, InventoryApplication>();

                services.AddDbContext<InventoryContext>(x => x.UseSqlServer(Connectionstring));
            }
     

    }
}
