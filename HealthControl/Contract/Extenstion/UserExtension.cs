using Contract.ViewModel.User;
using Domain.Model.Order.Kit;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Extenstion
{
    public static class UserExtension
    {
        public static User ToUser(this UserDto dto)
        {
            if (dto == null)
                return new User();
            return new User(dto.Id,dto.Name, dto.Code, dto.Age, dto.UserName, dto.Address,dto.Score);

        }

    }
}
