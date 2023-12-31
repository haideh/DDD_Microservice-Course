
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
    public class Kit : IRequest<bool>
    {
        public int Id { get; private set; }
        public string Serial { get; private set; }
        public string Description { get; private set; }
        public string Guidline { get; private set; }
        public string TestTypes { get; private set; }

        public Kit()
        {
            Id = 0;

        }
        public void AddKit(string serial, string description, string guidline, string testTypes)
        {
            Serial = serial;
            Description = description;
            Guidline = guidline;
            TestTypes = testTypes;
        }

    }
    public enum TestType
    {
        HBS,
        HIV,
        TSH
    }
}
