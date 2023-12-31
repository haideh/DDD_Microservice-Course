using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWorkEf : IUnitOfWork
    {
        private readonly HealthContext _context;

        public UnitOfWorkEf(HealthContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public bool CommitTransaction()
        {
            var hasChanges = _context.ChangeTracker.HasChanges();
            if (!hasChanges)
            {
                Rollback();
                return true;
            }

            var result = _context.SaveChanges();
            _context.Database.CommitTransaction();
            return result > 0;
        }

        public void Rollback()
        {
            var hasChanges = _context.ChangeTracker.HasChanges();
            if (hasChanges)
                _context.Database.RollbackTransaction();
        }

    }
}
