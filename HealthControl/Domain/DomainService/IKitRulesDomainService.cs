using Domain.Model;
using Domain.Model.Order.Kit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainService
{
    public interface IKitRulesDomainService
    {
        long CalculateKitPrice(List<TestType> testTypes, Country country,long basePrice);
    }
}
