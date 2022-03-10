using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.efCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);
            builder.OwnsMany(x => x.Operations, modelBuilde =>
               {
                   modelBuilde.ToTable("InventoryOperations");
                   modelBuilde.HasKey(x => x.Id);
                   modelBuilde.Property(x => x.Description).HasMaxLength(1000);
                   modelBuilde.WithOwner
                   (x => x.Inventory).HasForeignKey(x => x.InventoryId);
               });
        }
    }
}
