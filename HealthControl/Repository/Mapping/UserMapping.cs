using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User = Domain.Model.User.User;

namespace Repository.Mapping
{

    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.UserName);
            builder.Property(x => x.Password);
            builder.Property(x => x.Code);
            builder.Property(x => x.Age);
            builder.Property(x => x.Address);
            builder.Property(x => x.Score);

        }
    }
}
