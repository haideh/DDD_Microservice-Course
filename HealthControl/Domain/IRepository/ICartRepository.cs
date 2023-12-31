
using Domain.Model.Order.Kit;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.AbstractQuery;

namespace Domain.IRepository
{
    public interface ICartRepository : IAbstractGenericRepository<Cart>
    {
    }
}
