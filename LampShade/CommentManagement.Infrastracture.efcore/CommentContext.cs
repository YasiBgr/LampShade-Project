using CommentManagement.CommentAgg;
using CommentManagement.Infrastracture.efcore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastracture.efcore
{
    public class CommentContext:DbContext
    {

        public DbSet<Comment> Comments { get; set; }
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        var assembly = typeof(CommentMapping).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
