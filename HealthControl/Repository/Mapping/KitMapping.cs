using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;
using Domain.Model.Order.Kit;

namespace Repository.Mapping
{

    public class KitMapping : IEntityTypeConfiguration<Kit>
    {
        public void Configure(EntityTypeBuilder<Kit> builder)
        {
            builder.ToTable("Kit", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Serial);
            builder.Property(x => x.Description);
            builder.Property(x => x.Guidline);
            builder.Property(x => x.TestTypes);       
        }
    }
}
