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
    public class CountryConverter : ValueConverter<Country, string>
    {
        public CountryConverter()
            : base(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Country>(v, (JsonSerializerOptions)null))
        {
        }
    }

}
