Console.WriteLine("Welcome to the Multiplications Table");

int number;

Console.Write("Please enter a number: ");
while(!int.TryParse(Console.ReadLine(), out number) || number <= 0)
{
    Console.WriteLine("Invalid Number!");
    Console.Write("Please enter a valid positive number: ");
}

Console.WriteLine($"Mutliplications Table for X = {number}");
for(int i = 1; i <= number; i++)
{
    for(int j= 1; j <= number; j++)
    {
        Console.WriteLine($"{i} x {j} = {i*j}");
    }
}