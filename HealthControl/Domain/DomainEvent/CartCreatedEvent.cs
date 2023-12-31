using Domain.Model.Order.Kit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEvent
{
    public class CartCreatedEvent : IRequest<bool>
    {
        public List<CartItem> CartItems { get; set; }
       public int CartId { get; set; }  
      
    }
}
