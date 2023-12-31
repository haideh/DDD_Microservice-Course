using Domain.Model.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ViewModel.User;
using Contract.ViewModel.Order.Discount;

namespace QueryRepository.Mapping
{
    public class DiscountMapping : IEntityTypeConfiguration<DiscountDto>
    {
        public void Configure(EntityTypeBuilder<DiscountDto> builder)
        {
            builder.ToTable("Discount", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.DiscountPercent);
            builder.Property(x => x.MaxValue);
            builder.Property(x => x.MinValue);
            builder.Property(x => x.EndDate);
  

        }
    }
}
