using Contract.ViewModel.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Cart
{
    public class CartItemDto
    {
        public int Id { get;  set; }
        public int KitId { get;  set; }
        public int CartId { get;  set; }
        public int Count { get;  set; }
    }
}
