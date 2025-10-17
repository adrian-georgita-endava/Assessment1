using Assessment1.Exercise4;
using System.Text;

Console.WriteLine("Welcome to the Authentificator");

Dictionary<string, string> accounts = new Dictionary<string, string>();
accounts.Add("user", Hasher.SHA256Hash("pass"));
accounts.Add("user2", Hasher.SHA256Hash("pass2"));

IAuthentificator authentificator = new DictionaryAuthentificator(accounts);

string? username;
string? password;
const int NUMBER_OF_RETRIES = 3;

Console.Write("Username: ");
username = Console.ReadLine();
while(String.IsNullOrEmpty(username))
{
    Console.WriteLine("Please provide a valid username");
    Console.Write("Username: ");
    username = Console.ReadLine();
}

bool isSuccessful = false;
for (int i = 0; i < NUMBER_OF_RETRIES; i++)
{
    Console.Write("Password: ");
    password = Console.ReadLine();

    if(!String.IsNullOrEmpty(password) && authentificator.Authentificate(username, password))
    {
        isSuccessful = true;
        break;
    }

    Console.WriteLine("Invalid Credentials. Please try again!");
    Console.WriteLine($"Tries left: {NUMBER_OF_RETRIES - i - 1}");
}

if(isSuccessful)
{
    Console.WriteLine("Authentification successful!");
}
else
{
    Console.WriteLine("Invalid Credentials!");
}