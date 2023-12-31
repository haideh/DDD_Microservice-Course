
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Domain.Model.Order.Kit
{
    public class Discount : IRequest<bool>
    {
        //[Id], [MaxValue], [MinValue], [StartDate], [EndDate], [DiscountPercent]
        public int Id { get; private set; }
        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }
      
        public int DiscountPercent { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public Discount()
        {
            Id = 0;

        }
        public Discount(int id,int maxValue, int minValue, int discountPercent, DateTime startDate, DateTime endDate)
        {
            Id = id;
            MaxValue = maxValue;
            MinValue = minValue;
            DiscountPercent = discountPercent;
            StartDate = startDate;
            EndDate = endDate;
        }
        public void AddDiscount(int maxValue,int minValue, int discountPercent,DateTime startDate,DateTime endDate)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            DiscountPercent = discountPercent;
            StartDate = startDate;
            EndDate = endDate;
        }

    }

}
