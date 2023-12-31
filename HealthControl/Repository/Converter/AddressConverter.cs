using Domain.Model;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Repository.Converter
{
    public class AddressConverter : ValueConverter<Address, string>
    {
        public AddressConverter()
            : base(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null))
        {
        }
    }

}
