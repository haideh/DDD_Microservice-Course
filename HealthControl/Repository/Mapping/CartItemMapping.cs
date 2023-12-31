using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;
using Domain.Model.Order.Kit;

namespace Repository.Mapping
{

    public class CartItemMapping : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CartId);
            builder.Property(x => x.KitId);
            builder.Property(x => x.Count);
        }
    }
}
