using Contract.ViewModel.Address;
using Domain.Model;
using Domain.Model.Order.Kit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Kit
{
    
    public class CreateKitRulesDto
    {
        public int KitId { get;  set; }
        public long Price { get;  set; }
        public CountryDto Country { get;  set; }
      

    }
}
