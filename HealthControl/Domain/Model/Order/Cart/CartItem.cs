
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Domain.Model.Order.Kit
{
    public class CartItem : IRequest<bool>
    {
        public int Id { get; private set; }
        public int KitId { get; private set; }
        public int CartId { get; private set; }
        public int Count { get; private set; }

        public CartItem() { Id = 0; }
        public CartItem( int kitId, int count)
        {
            Id = 0;
            KitId = kitId;
            Count = count;
        }
        public void setCartId(int cartId)
        {
            CartId = cartId;
        }
    }
}
