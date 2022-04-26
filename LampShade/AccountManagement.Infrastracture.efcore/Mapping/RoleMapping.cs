using AccountManagement.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.efcore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.OwnsMany(x => x.Permissions, naigationBuilder =>
            {

                naigationBuilder.HasKey(x => x.Id);
                naigationBuilder.ToTable("RolePermission");
                naigationBuilder.Ignore(x => x.Name);
                naigationBuilder.WithOwner(x => x.Role);


            });
        }
    }
}
