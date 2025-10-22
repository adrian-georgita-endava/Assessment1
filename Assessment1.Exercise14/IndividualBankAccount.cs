using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise14
{
    public class IndividualBankAccount : IBankAccount
    {
        public int AccountNumber { get; }
        public decimal Balance { get; set; }
        public IBankCustomer Customer { get; }

        private static int _currentAccountNumber = 0;

        public IndividualBankAccount(IBankCustomer customer)
        {
            Customer = customer;
            AccountNumber = _currentAccountNumber++;
        }

        public void Deposit(decimal amount) => Balance += (amount > 0 ? amount : 0);

        public bool Withdraw(decimal amount)
        {
            if(Balance < amount)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }
        public bool Transfer(IBankAccount account, decimal amount)
        {
            if (Balance < amount)
            {
                return false;
            }

            account.Deposit(amount);
            this.Withdraw(amount);
            return true;
        }

        public override string ToString()
        {
            return $"[Bank Account: {AccountNumber}] Balance: {Balance}";
        }
    }
}
