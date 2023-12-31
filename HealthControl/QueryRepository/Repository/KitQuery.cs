using Contract.Query;
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
    public class KitQuery : IKitQuery
    {
        private readonly HealthQueryContext _context;


        public KitQuery(HealthQueryContext context)
        {
            _context = context;
        }

        public KitDto? GetById(int id)
        {
            return _context.Kits.Where(x => x.Id == id).Select(x => new KitDto()
            {
                Id = x.Id,
                Serial = x.Serial,
                Description = x.Description,
                Guidline = x.Guidline,
                TestTypes = x.TestTypes
            }).FirstOrDefault();

        }

    }
}
