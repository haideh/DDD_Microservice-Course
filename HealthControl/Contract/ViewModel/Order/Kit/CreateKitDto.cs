using Domain.Model.Order.Kit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Kit
{
    
    public class CreateKitDto
    {

        public string Serial { get;  set; }
        public string Description { get;  set; }
        public string Guidline { get;  set; }
        public List<TestType> TestTypes { get;  set; }

    }
}
