

using DiscountManagmengDomain.ColleagueDiscount;
using DiscountManagmengDomain.CustomerDiscount;
using DiscountManagment.Infrastructure.efCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagment.Infrastructure.efCore
{
    public class DiscountManagmentContext : DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscounts { get; set; }

        public DiscountManagmentContext( DbContextOptions<DiscountManagmentContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
