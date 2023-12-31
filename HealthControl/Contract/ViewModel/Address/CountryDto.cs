
using Contract.ViewModel.User;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ValueObject;

namespace Contract.ViewModel.Address
{
    public class CountryDto : ValueObject<CountryDto>
    {
        public string Value { get;  set; }
        public CurrencyType Currency { get;  set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
            yield return Currency;
        }
    }
    public class AddressDto:ValueObject<AddressDto>
    {
        public string Value { get;  set; }
        public CountryDto Country { get;  set; }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
            yield return Country;
        }
    }
}
