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
    public class AddKitCommandHandler : IRequestHandler<Kit, bool>
    {
        private readonly IKitRepository _kitRepository;
      
        public AddKitCommandHandler(IKitRepository kiiRepository)
        {
            _kitRepository = kiiRepository;
        }

 
        public Task<bool> Handle(Kit request, CancellationToken cancellationToken)
        {
 
            _kitRepository.Add(request);
            return Task.FromResult<bool>(true);
        }
    }
}
