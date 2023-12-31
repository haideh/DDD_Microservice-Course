
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ValueObject;

namespace Domain.Model
{
    public class Score:ValueObject<Score>
    {
        public int Value { get; private set; }
        public bool IsValid { get; private set; }
        public Score(int value)
        {
            Value = value;
        }
        public void ChangeScoreStatus(bool isValid)
        {
            IsValid = isValid;
        }
        public void ChangeScoreValue(int value)
        {
            Value = value;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
            yield return IsValid;
        }
    }
}
