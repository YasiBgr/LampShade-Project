using CommentManagement.Application;
using CommentManagement.Application.Contracts.Comment.folder;
using CommentManagement.CommentAgg;
using CommentManagement.Infrastracture.efcore;
using CommentManagement.Infrastracture.efcore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Configuration
{
    public  class CommentManagementBootstrapper
    {

        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddDbContext<CommentContext>(x => x.UseSqlServer(connectionstring));
        }
    }
    }
