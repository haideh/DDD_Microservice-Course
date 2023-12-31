using Contract.Query;
using Contract.ViewModel.User;
using Domain.DomainEvent;
using Domain.IRepository;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Model.User.User;

namespace Application.Handler.DomainEvent
{

    public class CartCreateEventHandler : IRequestHandler<CartCreatedEvent, bool>
    {

        private readonly ICartItemRepository _cartItemRepository;
        public CartCreateEventHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository=cartItemRepository;
        }
        public Task<bool> Handle(CartCreatedEvent cart, CancellationToken cancellationToken)
        {

            foreach (var item in cart.CartItems)
            {
                 item.setCartId(cart.CartId);    
                _cartItemRepository.Add(item);
            }
            return Task.FromResult<bool>(true);
        }

        
    }
}
