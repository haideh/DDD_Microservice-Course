using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;
using Domain.Model.Order.Kit;

namespace Repository.Mapping
{

    public class CartMapping : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date);
            builder.Property(x => x.Status);
            builder.Property(x => x.Price);
            builder.Property(x => x.DeliveryAddress);       
            builder.Property(x => x.UserId);   
        }
    }
}
