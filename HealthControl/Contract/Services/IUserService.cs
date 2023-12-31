using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Services
{
    public interface IUserService
    {
        bool Register(CreateUserDto dto);
        UserDto? GetUserById(int id);
        CountryKitDto? GetCountryKitByUserId(int id);
    }
}
