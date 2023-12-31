using Contract;
using Contract.Query;
using Contract.Services;
using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using Domain.Model;
using Domain.Model.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IUserQuery _userQuery;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(IMediator mediator, IUserQuery userQuery, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _userQuery = userQuery;
            _unitOfWork = unitOfWork;
        }

        public bool Register(CreateUserDto dto)
        {
            if (_userQuery.IsExist(dto.UserName))
            {
                return false;
            }
            User user = new User();
            user.SetAddress(new Address(dto.Address, new Country(dto.CountryName, (int)dto.Currency)));
            user.Register(dto.Name, dto.Code, dto.Age, dto.UserName, dto.Password, dto.UserIntroducerId);

            _unitOfWork.BeginTransaction();

            _mediator.Send(user);


            _mediator.Send(user.GetEvents());


            var result = _unitOfWork.CommitTransaction();

            if (result)
            {
                return true;
            }
            else
            {
                _unitOfWork.Rollback();
                return false;
            }

        }

        public UserDto? GetUserById(int id)
        {
            return _userQuery.GetById(id);
        }

        public CountryKitDto? GetCountryKitByUserId(int id)
        {
            return _userQuery.GetCountryKitByUserId(id);
        }
    }
}
