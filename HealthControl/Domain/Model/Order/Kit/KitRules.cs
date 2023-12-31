
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
    public class KitRules : IRequest<bool>
    {

        public int Id { get; private set; }
        public bool IsAllowed { get; private set; }
        public long Price { get; private set; }
        public int KitId { get; private set; }
        public Country Country { get; private set; }
        public DateTime Date { get; private set; }

        public KitRules()
        {
            Id = 0;

        }
        public void AddKitsRule(long price, int kitId , Country country)
        {
            IsAllowed = price == -1 ? false : true;
            Price = price;
            KitId = kitId;
            Country = country;
            Date = DateTime.Now;
        }

    }

}
