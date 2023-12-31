
using Domain.IRepository;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.AbstractQuery;

namespace Repository.Repositories
{
    public class UserRepository : AbstractGenericRepository<User>, IUserRepository
    {
        private readonly HealthContext _context;
        public UserRepository(HealthContext context) : base(context)
        {
            _context = context;
        }
    }
}
