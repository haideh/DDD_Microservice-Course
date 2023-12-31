
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.User
{


    public class CreateUserDto
    {
        
        public int UserIntroducerId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public CurrencyType Currency { get; set; }
        public string Code { get; set; }
        public int Age { get; set; }
        public int Score { get; set; }

    }

}
