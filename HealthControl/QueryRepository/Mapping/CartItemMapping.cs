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
    public class CartItemMapping : IEntityTypeConfiguration<CartItemDto>
    {
        public void Configure(EntityTypeBuilder<CartItemDto> builder)
        {
            builder.ToTable("CartItem", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Count);
            builder.Property(x => x.KitId);
            builder.Property(x => x.CartId);

        }
    }
}
