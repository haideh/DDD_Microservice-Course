
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using Domain.DomainEvent;

namespace Domain.Model.Order.Kit
{
    public class Cart : IRequest<bool>
    {
        List<IRequest<bool>> events;
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public long Price { get; private set; }
        public int Status { get; private set; }
        public DateTime Date { get; private set; }
        public Address DeliveryAddress { get; private set; }

        public Cart()
        {
            Id = 0;
            events = new List<IRequest<bool>>();
        }
        public List<IRequest<bool>> GetEvents()
        {
            return events;
        }
        public void AddCart(int userId, long price, CartStatus status, Address deliveryAddress)
        {
            UserId = userId;
            Price = price;
            Status = (int) status;
            DeliveryAddress = deliveryAddress;
            Date = DateTime.Now;

           
        }
        public void CreateCartEvent(List<CartItem> cartItems)
        {
            this.events.Add(new CartCreatedEvent { CartItems = cartItems ,CartId=Id });
        }

    }
    public enum CartStatus
    {
        OK,
        Failed,
        Pending
    }
}
