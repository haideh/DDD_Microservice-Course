
using Domain.Model;
using Domain.Model.Order.Kit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Contract.ViewModel.Order.KitRules
{
    public class CountryKitDto
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Description { get; set; }
        public string Guidline { get; set; }
        public string TestTypes { get; set; }
        public List<TestType> TestType
        {
            get
            {
                return DTOJsonSerialize<List<TestType>>.GetDTO(TestTypes);
            }
        }
        public int userId { get; set; }
    }
}
