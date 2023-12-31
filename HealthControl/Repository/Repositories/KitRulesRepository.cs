
using Domain.IRepository;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.AbstractQuery;

namespace Repository.Repositories
{
    public class KitRulesRepository : AbstractGenericRepository<KitRules>, IKitRulesRepository
    {
        private readonly HealthContext _context;
        public KitRulesRepository(HealthContext context) : base(context)
        {
            _context = context;
        }
    }
}
