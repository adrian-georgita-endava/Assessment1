using Assessment1.Exercise14;

Console.WriteLine("Welcome to the Bank Account Manager");

BankHandler bankHandler = new BankHandler();

IBankCustomer indCustomer1 = new IndividualBankCustomer("First", "Last");
bankHandler.AddAccount(new IndividualBankAccount(indCustomer1));

IBankCustomer indCustomer2 = new IndividualBankCustomer("First2", "Last2");
bankHandler.AddAccount(new IndividualBankAccount(indCustomer2));

string? cmd;
do
{
    bankHandler.Interact();
    Console.Write("Continue? y/n: ");
    cmd = Console.ReadLine();
} while (!string.IsNullOrEmpty(cmd) && cmd.ToLower() != "n");