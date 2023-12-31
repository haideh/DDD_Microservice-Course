using Domain.Model.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ViewModel.User;
using Contract.ViewModel.Order.Cart;

namespace QueryRepository.Mapping
{
    public class CartMapping : IEntityTypeConfiguration<CartDto>
    {
        public void Configure(EntityTypeBuilder<CartDto> builder)
        {
            builder.ToTable("Cart", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status);
            builder.Property(x => x.DeliveryAddress);
            builder.Property(x => x.UserId);
            builder.Property(x => x.Date);
            builder.Property(x => x.Price);
            builder.Property(x => x.Date);
            builder.Ignore(x => x.Address);
            builder.Ignore(x => x.CartItems);

        }
    }
}
