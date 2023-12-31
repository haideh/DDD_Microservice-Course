
using Contract.ViewModel.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Contract.ViewModel.Order.Cart
{
    public class CartDto
    {
        public int Id { get;  set; }
        public int UserId { get;  set; }
        public long Price { get;  set; }
        public int Status { get;  set; }
        public DateTime Date { get;  set; }
        public string DeliveryAddress { get; set; }
        public AddressDto Address
        {
            get
            {
                return DTOJsonSerialize<AddressDto>.GetDTO(DeliveryAddress);
            }
        }
        public List<CartItemDto> CartItems { get;  set; }
    }
}
