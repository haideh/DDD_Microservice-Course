using Contract.ViewModel.Address;
using Contract.ViewModel.User;
using Domain.Model;
using Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Extenstion
{
    public static class CountryExtension
    {
        public static Country ToCountry(this CountryDto dto)
        {
            
            return new Country(dto.Value,(int) dto.Currency);

        }

    }
}
