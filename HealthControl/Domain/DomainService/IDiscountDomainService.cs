using Domain.Model;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainService
{
    public interface IDiscountDomainService
    {
        long CalculateTotalPrice(Discount discount, User user,long basePrice);
    }
}
