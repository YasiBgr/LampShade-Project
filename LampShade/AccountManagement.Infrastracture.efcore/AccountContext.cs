using AccountManagement.Infrastracture.efcore.Mapping;
using AccountManagement.RoleAgg;
using CommentManagement.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastracture.efcore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
