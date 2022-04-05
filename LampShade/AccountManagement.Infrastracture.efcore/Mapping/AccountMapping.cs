using CommentManagement.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.efcore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Fullname).HasMaxLength(100);
            builder.Property(x => x.Username).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(1000);
            builder.Property(x => x.Mobail).HasMaxLength(20);
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500);
            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RollId);
        }
    }
}
