using Contract;
using Domain.IRepository;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler
{
    public class RegisterCommandHandler : IRequestHandler<User, bool>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler( IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public Task<bool> Handle(User user, CancellationToken cancellationToken)
        {
            
            _userRepository.Add(user);
            return Task.FromResult<bool>(true); 

        }
    }
}
