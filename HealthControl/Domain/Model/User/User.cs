
using Domain.DomainEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.Model.User
{
    public class User : IRequest<bool>
    {

        IRequest<bool> events;

        public int Id { get; set; }
        public int UserIntroducerId { get; set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public int Score { get; private set; }
        public string Code { get; private set; }
        public int Age { get; private set; }
        private List<Address> _addresses;
        private Score _score;

        public User()
        {
            Id = 0;
            _addresses = new List<Address>();
        }
        public User(int id) { this.Id = id; }
        public User( int id,string name, string code, int age, string userName, string address, int score = 0)
        {
            Id = id;
          
            Name = name;
            Code = code;
            Age = age;
            UserName = userName;
            Address = address;
            Score = score;

        }
        public void Register(string name, string code, int age, string userName, string password, int userIntroducerId,int score=0)
        {
            UserIntroducerId = userIntroducerId;
            Name = name;
            Code = code;
            Age = age;
            UserName = userName;
            Password = password;
            Address = DTOJsonSerialize<List<Address>>.GetJson(_addresses);
            SetScore(score);

            this.events=(new UserCreatedEvent { UserIntroducerId = userIntroducerId });
        }

        public void Edit(int value)
        {
            SetScore(value);
        }
        public IRequest<bool> GetEvents()
        {
            return events;
        }
        private void SetScore(int value)
        {
            if (_score != null)
            {
                _score.ChangeScoreValue(value);
            }
            else
            {
                _score = new Score(value);

            }
            Score = _score.Value;
        }

        public void SetAddress(Address address)
        {
            _addresses.Add(address);
        }


    }


}
