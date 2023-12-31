using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Query
{
    public interface IUserQuery
    {
        bool IsExist(string userName);
        UserDto? GetById(int id);
        CountryKitDto? GetCountryKitByUserId(int id);
    }
}
