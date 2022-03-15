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
    class InventoryOperationMapping : IEntityTypeConfiguration<InventoryOperations>
    {
        public void Configure(EntityTypeBuilder<InventoryOperations> builder)
        {
            builder.ToTable("InventoryOperations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Operation);
            builder.Property(x => x.OperationDate);
            builder.Property(x => x.OperatorId);
            builder.Property(x => x.OrderId);
            builder.Property(x => x.Description);
            builder.Property(x => x.CurrentCount);
            builder.Property(x => x.Count);
            builder.Property(x => x.InventoryId);
            builder.HasOne(x => x.Inventory).WithMany(x => x.Operations).HasForeignKey(x => x.InventoryId);
              
        }
    }
}
