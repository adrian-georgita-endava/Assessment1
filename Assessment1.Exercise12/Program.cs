using Assessment1.Exercise12;

Console.WriteLine("Welcome to the Accounting Division Calculator");

Input input = new Input();

Console.WriteLine("Please enter the two numbers you want to divide: ");
decimal numerator, denominator;
numerator = input.ReadDecimal("Numerator");
denominator = input.ReadDecimal("Denominator");

Console.WriteLine("Please enter the number of decimals you want");
int decimals = input.ReadInt("Decimals", 0);

try
{
    decimal result = AccountingMath.SafeDivide(numerator, denominator, decimals);
    Console.WriteLine($"Result: {result}");
}
catch(Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}