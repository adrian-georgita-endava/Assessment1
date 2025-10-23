using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise14
{
    // Individual or Enterprise
    public interface IBankAccount
    {
        public int AccountNumber { get; }
        public decimal Balance { get; set; }
        public IBankCustomer Customer { get; }
        public void Deposit(decimal amount);
        public bool Withdraw(decimal amount);
        public bool Transfer(IBankAccount account, decimal amount);

        public string ToString();
    }
}
