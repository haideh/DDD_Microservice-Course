using Contract.ViewModel.Order.Kit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ViewModel.Order.KitRules;

namespace QueryRepository.Mapping
{
    public class CountryKitMapping : IEntityTypeConfiguration<CountryKitDto>
    {
        public void Configure(EntityTypeBuilder<CountryKitDto> builder)
        {
            builder.ToTable("CountryKitListView", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Serial);
            builder.Property(x => x.Description);
            builder.Property(x => x.Guidline);
            builder.Property(x => x.TestTypes);
            builder.Ignore(x => x.TestType);
            builder.Property(x => x.userId);
        }
    }
}
