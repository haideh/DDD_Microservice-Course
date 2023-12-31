using Contract;
using Domain.IRepository;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class AddCartCommandHandler : IRequestHandler<Cart, bool>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;

        }


        public Task<bool> Handle(Cart request, CancellationToken cancellationToken)
        {

            _cartRepository.Add(request);
            _cartRepository.SaveChanges();
            return Task.FromResult<bool>(true);


        }
    }
}
