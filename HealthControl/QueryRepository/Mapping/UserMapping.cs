using Domain.Model.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.ViewModel.User;

namespace QueryRepository.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.UserName);
            builder.Property(x => x.Code);
            builder.Property(x => x.Age);
            builder.Property(x => x.Address);
            builder.Ignore(x => x.Addresses);

        }
    }
}
