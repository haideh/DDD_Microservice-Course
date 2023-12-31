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
    public class AddDiscountCommandHandler : IRequestHandler<Discount, bool>
    {
        private readonly IDiscountRepository _discountRepository;

        public AddDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;

        }


        public Task<bool> Handle(Discount request, CancellationToken cancellationToken)
        {

            _discountRepository.Add(request);
            return Task.FromResult<bool>(true);


        }
    }
}
