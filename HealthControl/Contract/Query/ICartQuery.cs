using Contract.ViewModel.Order.Cart;
using Contract.ViewModel.Order.Kit;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Query
{
    public interface ICartQuery
    {
        CartDto? GetCartById(int id);
    }
}
