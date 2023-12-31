using Contract.ViewModel.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Cart
{
    public class CreateCartItemDto
    {
        public int KitId { get;  set; }
        public int Count { get;  set; }
    }
}
