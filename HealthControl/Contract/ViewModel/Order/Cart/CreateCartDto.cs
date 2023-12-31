using Contract.ViewModel.Address;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Cart
{
    public class CreateCartDto
    {
       
        public int UserId { get;  set; }
        public DateTime Date { get;  set; }
        public string DeliveryAddress { get; set; }
        public string CountryName { get; set; }
        public CurrencyType Currency { get; set; }
        public List<CreateCartItemDto> CartItemList { get; set; }
    }
}
