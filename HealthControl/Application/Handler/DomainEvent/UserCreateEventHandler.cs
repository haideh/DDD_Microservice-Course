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

    public class UserCreateEventHandler : IRequestHandler<UserCreatedEvent, bool>
    {
        private readonly IUserQuery _userQuery;
        private readonly IUserRepository _userRepository;
        public UserCreateEventHandler(IUserQuery userQuery, IUserRepository userRepository)
        {
            _userQuery = userQuery;
            _userRepository = userRepository;
        }
        public Task<bool> Handle(UserCreatedEvent user, CancellationToken cancellationToken)
        {
            //Get By Id 
            var userInfo = _userQuery.GetById(user.UserIntroducerId);
            if (userInfo != null)
            {
                //Update 
                User u = new User(user.UserIntroducerId);
               _userRepository.Update(u,x=>x.Edit(100));

            }
            return Task.FromResult<bool>(true);
        }

        
    }
}
