using Domain.Model;
using Domain.Model.Order.Kit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Kit
{
    
    public class KitRulesDto
    {

        public int Id { get;  set; }
        public int KitId { get;  set; }
        public long Price { get;  set; }
        public DateTime Date { get;  set; }
        public bool IsAllowed { get;  set; }
      

    }
}
