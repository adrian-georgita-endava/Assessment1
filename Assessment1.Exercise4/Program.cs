using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Welcome to the Authentificator");

string validUsername = "user";
string validPassword = "d74ff0ee8da3b9806b18c877dbf29bbde50b5bd8e4dad7a3a725000feb82e8f1"; // pass

string? username;
string? password;
const int NUMBER_OF_RETRIES = 3;

string SHA256Hash(string input)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder builder = new StringBuilder();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2")); ;
        }

        return builder.ToString();
    }
}

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

    if(username == validUsername && !String.IsNullOrEmpty(password) && SHA256Hash(password) == validPassword)
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