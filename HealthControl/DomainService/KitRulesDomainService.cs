


using Domain.DomainService;
using Domain.Model;
using Domain.Model.Order.Kit;

namespace DomainService
{
    public class KitRulesDomainService : IKitRulesDomainService
    {
        static Dictionary<CurrencyType, Func<TestType, long>> PriceRuleDictionary;
        public KitRulesDomainService()
        {
            PriceRuleDictionary = new Dictionary<CurrencyType, Func<TestType, long>>();
            PriceRuleDictionary.Add(CurrencyType.Dollar, x => GetDollarTestPrice(x));
            PriceRuleDictionary.Add(CurrencyType.Rial, x => GetRialTestPrice(x));
            PriceRuleDictionary.Add(CurrencyType.Pound, x => GetPoundTestPrice(x));
        }

        private int GetDollarTestPrice(TestType type)
        {
            switch (type)
            {
                case TestType.HBS:
                    return 1000;
                case TestType.HIV:
                    return 2000;
                case TestType.TSH:
                    return 1500;
                default:
                    return 0;
            }
        }
        private int GetRialTestPrice(TestType type)
        {
            return -1;
        }
        private int GetPoundTestPrice(TestType type)
        {
            switch (type)
            {
                case TestType.HBS:
                    return 100;
                case TestType.HIV:
                    return 200;
                case TestType.TSH:
                    return 150;
                default:
                    return 0;
            }
        }

        public long CalculateKitPrice(List<TestType> testTypes, Country country,long basePrice)
        {
            long price = basePrice;
            foreach (var item in testTypes)
            {
                price += PriceRuleDictionary[country.Currency].Invoke(item);
            }
            return price;
        }
    }
}