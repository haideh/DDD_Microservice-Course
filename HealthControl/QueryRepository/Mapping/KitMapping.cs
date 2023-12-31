using Domain.Model.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ViewModel.User;
using Contract.ViewModel.Order.Kit;

namespace QueryRepository.Mapping
{
    public class KitMapping : IEntityTypeConfiguration<KitDto>
    {
        public void Configure(EntityTypeBuilder<KitDto> builder)
        {
            builder.ToTable("Kit", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Serial);
            builder.Property(x => x.Description);
            builder.Property(x => x.Guidline);
            builder.Property(x => x.TestTypes);
            builder.Ignore(x => x.TestType);
        }
    }
}
