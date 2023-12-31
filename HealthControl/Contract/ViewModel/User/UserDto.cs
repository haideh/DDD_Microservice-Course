
using Contract.ViewModel.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Contract.ViewModel.User
{

    public class UserDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public List<AddressDto> Addresses
        {
            get
            {
                return DTOJsonSerialize<List<AddressDto>>.GetDTO(Address);
            }
        }
        public string Code { get; set; }
        public int Age { get; set; }

    }

}
