using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModel.Order.Discount
{
    public class CreateDiscountDto
    {
        
        public int MaxValue { get;  set; }
        public int MinValue { get;  set; }

        public int DiscountPercent { get;  set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
    }
}
