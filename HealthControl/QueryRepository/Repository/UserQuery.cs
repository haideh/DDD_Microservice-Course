using Contract.Query;
using Contract.ViewModel.Order.KitRules;
using Contract.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QueryRepository.Repository
{
    public class UserQuery : IUserQuery
    {
        private readonly HealthQueryContext _context;


        public UserQuery(HealthQueryContext context)
        {
            _context = context;
        }

        public bool IsExist(string userName)
        {
            return _context.Users.Where(x => x.UserName == userName ).Any();

        }
        public  UserDto? GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id).Select(x => new UserDto()
            {
                Age = x.Age,
                Address = x.Address,
                Code = x.Code,
                Id = x.Id,
                Name = x.Code,
                Score = x.Score,
                UserName = x.UserName,

            }).FirstOrDefault();

        }
        public CountryKitDto? GetCountryKitByUserId(int id)
        {
            return _context.CountryKits.Where(x => x.userId == id).Select(x => new CountryKitDto()
            {
                userId  = x.userId,
                Id = x.Id,
                Serial = x.Serial,
                Description = x.Description,
                Guidline = x.Guidline,
                TestTypes = x.TestTypes

            }).FirstOrDefault();

        }

    }
}
