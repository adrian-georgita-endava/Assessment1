using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise14
{
    public class IndividualBankCustomer : IBankCustomer
    {
        public string Name { get; set; }
        public int CustomerId { get; }

        private string _firstName;
        private string _lastName;

        private static int _currentCustomerId = 0;

        public IndividualBankCustomer(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            Name = $"{_firstName} {_lastName}";
            CustomerId = _currentCustomerId++;
        }

        public override string ToString()
        {
            return $"[{CustomerId}] {Name}";
        }
    }
}
