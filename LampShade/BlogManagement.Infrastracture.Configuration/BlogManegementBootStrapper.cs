using _0_FramBase.Infrastructure;
using _01_LampshadeQuery.Contract.Article;
using _01_LampshadeQuery.Contract.ArticleCategory;
using _01_LampshadeQuery.Query;
using BlogManagement.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.ArticleAgg;
using BlogManagement.ArticleCategoryAgg;
using BlogManagement.Infrastracture.Configuration.Permission;
using BlogManagement.Infrastracture.efcore;
using BlogManagement.Infrastracture.efcore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogManagement.Infrastracture.Configuration
{
    public  class BlogManegementBootStrapper
    {
        public static void Configur(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();


            services.AddTransient<IPermissionExposer, BlogPermissionExposer>();

            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
        }

    }
}
