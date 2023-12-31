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
    public class KitRulesQuery : IKitRulesQuery
    {
        private readonly HealthQueryContext _context;


        public KitRulesQuery(HealthQueryContext context)
        {
            _context = context;
        }

        public KitRulesDto? GetKitRules(int kitId)
        {
            return _context.KitRules.Where(x => x.Date <=DateTime.Now && x.KitId==kitId && x.IsAllowed).Select(x => new KitRulesDto()
            {
                Id = x.Id,
                KitId= x.KitId,
                Date= x.Date,   
                IsAllowed= x.IsAllowed, 
                Price = x.Price 
            }).FirstOrDefault();

        }

    }
}
