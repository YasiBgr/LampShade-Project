using DiscountManagmengDomain.ColleagueDiscount;
using DiscountManagmengDomain.CustomerDiscount;
using DiscountManagment.Application;
using DiscountManagment.Application.Contract.ColleagueDiscount;
using DiscountManagment.Application.Contract.CustomerDiscount;
using DiscountManagment.Infrastructure.efCore;
using DiscountManagment.Infrastructure.efCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using _0_FramBase.Infrastructure;
using DiscountManagment.Configurations.Permission;

namespace DiscountManagment.Configurations
{
    public class DiscountManagmentBootStrapper
    {
        public static void Configure(IServiceCollection servises,string connectionstring)
        {
            servises.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            servises.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();


            servises.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            servises.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();

            servises.AddTransient<IPermissionExposer, DiscountPermissionExposer>();


            servises.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
