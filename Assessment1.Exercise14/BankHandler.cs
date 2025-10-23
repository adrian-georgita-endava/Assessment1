using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise14
{
    public class BankHandler
    {
        private Dictionary<int, IBankAccount> _bankAccounts;

        public BankHandler()
        {
            _bankAccounts = new();
        }

        public void AddAccount(IBankAccount account) => _bankAccounts.Add(account.AccountNumber, account);

        public void Interact()
        {
            int accountNumber = ReadAccountNumber();
            OperationEnum operation = ReadOperation();
            IBankAccount account = _bankAccounts[accountNumber];

            if (!PerformOperation(account, operation))
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                Console.WriteLine(account.ToString());
            }
        }

        private bool PerformOperation(IBankAccount account, OperationEnum operation)
        {
            int amount;
            switch (operation)
            {
                case OperationEnum.Transfer:
                    IBankAccount receivingAccount = _bankAccounts[ReadAccountNumber()];
                    amount = ReadAmount();
                    return account.Transfer(receivingAccount, amount);
                case OperationEnum.Deposit:
                    amount = ReadAmount();
                    account.Deposit(amount);
                    return true;
                case OperationEnum.Withdraw:
                    amount = ReadAmount();
                    return account.Withdraw(amount);
                case OperationEnum.Balance:
                    return true;
                default: return false;
            }
        }

        private OperationEnum ReadOperation()
        {
            Console.WriteLine("Enter the type of operation you want to perform (Deposit/Withdraw/Transfer/Balance)");
            OperationEnum operation;
            Console.Write("Operation: ");
            while(!Enum.TryParse(Console.ReadLine(), ignoreCase:true, out operation))
            {
                Console.WriteLine("Please enter a valid operation: 'Deposit' / 'Withdraw' / 'Transfer' / 'Balance' ");
                Console.Write("Operation: ");
            }

            return operation;
        }

        private int ReadAmount()
        {
            int amount;
            Console.Write("Amount: ");
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.WriteLine("Please enter a valid amount!");
                Console.Write("Amount: ");
            }

            return amount;
        }

        private int ReadAccountNumber()
        {
            int number;
            Console.Write("Account Number: ");
            while (!int.TryParse(Console.ReadLine(), out number) || number < 0 || !_bankAccounts.ContainsKey(number))
            {
                Console.WriteLine("Please enter a valid account number!");
                Console.Write("Account Number: ");
            }

            return number;
        } 
    }
}