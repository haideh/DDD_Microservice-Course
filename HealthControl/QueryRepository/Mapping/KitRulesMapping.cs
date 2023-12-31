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
    public class KitRulesMapping : IEntityTypeConfiguration<KitRulesDto>
    {
        public void Configure(EntityTypeBuilder<KitRulesDto> builder)
        {
            builder.ToTable("KitRules", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsAllowed);
            builder.Property(x => x.Price);
            builder.Property(x => x.Date);
            builder.Property(x => x.KitId);
        }
    }
}
