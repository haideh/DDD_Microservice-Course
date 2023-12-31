using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;
using Domain.Model.Order.Kit;

namespace Repository.Mapping
{

    public class DiscountMapping : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.MinValue);
            builder.Property(x => x.DiscountPercent);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.MaxValue);
        }
    }
}
