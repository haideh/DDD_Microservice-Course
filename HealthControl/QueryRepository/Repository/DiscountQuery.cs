using Contract.Query;
using Contract.ViewModel.Order.Discount;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository.Repository
{
    public class DiscountQuery : IDiscountQuery
    {
        private readonly HealthQueryContext _context;


        public DiscountQuery(HealthQueryContext context)
        {
            _context = context;
        }

        public DiscountDto? GetValidDiscount(long price)
        {
            return _context.Discounts.Where(x => x.StartDate >=DateTime.Now && x.EndDate<=DateTime.Now 
            && x.MaxValue>=price && x.MinValue<=price).Select(x => new DiscountDto()
            {
                Id = x.Id,
                EndDate= x.EndDate,
                DiscountPercent= x.DiscountPercent,
                MaxValue= x.MaxValue,
                MinValue= x.MinValue,
                StartDate=x.StartDate
            }).FirstOrDefault();

        }

    }
}
