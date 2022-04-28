using _0_FramBase.Infrastructure;
using AccountManagement.AccountAgg;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account.folder;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Configuration.Permission;
using AccountManagement.Infrastracture.efcore;
using AccountManagement.Infrastracture.efcore.Repository;
using AccountManagement.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IAccountRepository,AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleApplication, RoleApplication>();

            services.AddTransient<IPermissionExposer, AccountPermissionExposer>();


            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
