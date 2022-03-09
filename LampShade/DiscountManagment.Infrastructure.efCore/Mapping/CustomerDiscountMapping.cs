using DiscountManagmengDomain.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagment.Infrastructure.efCore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {

            builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.Id);
        }
    }
}
