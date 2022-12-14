using _0_FramBase.Application;
using _0_FramBase.Application.ZarinPal;
using _0_FramBase.Infrastructure;
using AccountManagement.Configuration;
using BlogManagement.Infrastracture.Configuration;
using CommentManagement.Configuration;
using DiscountManagment.Configurations;
using InventoryManagement.Configuration;
using InventoryManagment.Presentation.Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagment.Configuration;
using ShopManagment.Presentation.Api;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_FramBase.Application.Email;
using _0_FramBase.Application.Sms;
using _01_LampshadeQuery.Contract.Orders;
using _01_LampshadeQuery.Query;
using ShopManagment.Domain.Services;
using ShopManagment.Infrastructure.AccountAcl;
using ShopManagment.Infrastructure.InventoryAcl;

namespace ServiseHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("LampShadeDB");
            ShopManagmentBootstrapper.Configure(services, connectionString);
            DiscountManagmentBootStrapper.Configure(services, connectionString);
            InventoryManagementBootStrapper.Configure(services, connectionString);
            BlogManegementBootStrapper.Configur(services, connectionString);
            CommentManagementBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IShopAccountAcl, ShopAccountAcl>();
            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
            services.AddTransient<IOrderQuery, OrderQuery>();

            services.AddRazorPages().AddApplicationPart(typeof(ProductController).Assembly)
                .AddApplicationPart(typeof(InventoryController).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ColleagueUser }));
                options.AddPolicy("Shop", builder => builder.RequireRole(new List<string> { Roles.Administrator }));
                options.AddPolicy("Discount", builder => builder.RequireRole(new List<string> { Roles.Administrator }));
                options.AddPolicy("Account", builder => builder.RequireRole(new List<string> { Roles.Administrator }));
            });

            services.AddRazorPages()
                .AddMvcOptions(option => option.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(option =>
                {
                    option.Conventions.AuthorizeAreaFolder("Administrator", "/", "AdminArea");
                    option.Conventions.AuthorizeAreaFolder("Shop", "/Shop", "Shop");
                    option.Conventions.AuthorizeAreaFolder("Discount", "/Discount", "Discount");
                    option.Conventions.AuthorizeAreaFolder("Account", "/Account", "Account");
                }).AddApplicationPart(typeof(ProductController).Assembly)
                .AddApplicationPart(typeof(InventoryController).Assembly).AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
