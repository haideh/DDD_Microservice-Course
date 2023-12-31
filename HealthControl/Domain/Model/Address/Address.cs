
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ValueObject;

namespace Domain.Model
{
    public class Address: ValueObject<Address>
    {
        public string Value { get; private set; }
        public Country Country { get; private set; }
        public Address(string value, Country country)
        {
            Value = value.Trim();
            Country = country;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
            yield return Country;
        }
    }
}
