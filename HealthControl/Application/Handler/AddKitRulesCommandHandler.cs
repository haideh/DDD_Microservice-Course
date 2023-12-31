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
    public class AddKitRulesCommandHandler : IRequestHandler<KitRules, bool>
    {
        private readonly IKitRulesRepository _kitRulesRepository;

        public AddKitRulesCommandHandler(IKitRulesRepository kitRulesRepository)
        {
            _kitRulesRepository = kitRulesRepository;

        }


        public Task<bool> Handle(KitRules request, CancellationToken cancellationToken)
        {

            _kitRulesRepository.Add(request);

            return Task.FromResult<bool>(true);


        }
    }
}
