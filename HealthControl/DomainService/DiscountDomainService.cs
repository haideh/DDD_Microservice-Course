


using Domain.DomainService;
using Domain.Model;
using Domain.Model.Order.Kit;
using Domain.Model.User;

namespace DomainService
{
    public class DiscountDomainService : IDiscountDomainService
    {

        public DiscountDomainService()
        {

        }


        public long CalculateTotalPrice(Discount discount, User user, long basePrice)
        {
            long total = basePrice;
            if (basePrice <= discount.MaxValue && basePrice >= discount.MinValue)
            {
                total = basePrice - (discount.DiscountPercent * basePrice) / 100;
            }
            if (user.Score >= 0)
            {
                total = total - (user.Score * basePrice) / 100;
            }
            return total;
        }
    }
}