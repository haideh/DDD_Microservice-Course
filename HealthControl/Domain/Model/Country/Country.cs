
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ValueObject;

namespace Domain.Model
{
    public class Country : ValueObject<Country>
    {
        public string Value { get; private set; }
        public CurrencyType Currency { get; private set; }
        public Country(string value, int currency)
        {
            Value = value.Trim();
            Currency = (CurrencyType)currency;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
            yield return Currency;
        }
    }

    public enum CurrencyType
    {
        Dollar,
        Rial,
        Pound

    }
}
