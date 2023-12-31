using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;
using Domain.Model.Order.Kit;

namespace Repository.Mapping
{

    public class KitRulesMapping : IEntityTypeConfiguration<KitRules>
    {
        public void Configure(EntityTypeBuilder<KitRules> builder)
        {
            builder.ToTable("KitRules", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsAllowed);
            builder.Property(x => x.Price);
            builder.Property(x => x.KitId);
            builder.Property(x => x.Date);       
            builder.Property(x => x.Country);       
        }
    }
}
