using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.efCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagement.Infrastructure.efCore
{
    public class InventoryContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryOperations> InventoryOperation { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
