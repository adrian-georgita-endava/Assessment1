using Assessment1.Exercise8;

Console.WriteLine("Welcome to the Sequence Generator");

int numberOfTerms;
Console.Write("Enter the number of terms to generate: ");
while(!int.TryParse(Console.ReadLine(), out numberOfTerms) || numberOfTerms < 1)
{
    Console.WriteLine("Invalid number. Please enter a positive number");
    Console.Write("Enter the number of terms to generate: ");
}

string[] validSequences = ["fibonacci", "geometric", "prime", "factorial", "triangular", "perfect squares"];

Console.WriteLine("Sequence Types: 'Fibonacci', 'Geometric', 'Prime', 'Factorial' 'Triangular', 'Perfect Squares'");
Console.Write("Enter the type of sequence: ");
string? sequenceName = Console.ReadLine();
while (String.IsNullOrEmpty(sequenceName) || !validSequences.Contains(sequenceName.ToLower()))
{
    Console.WriteLine("Invalid Sequence Type");
    Console.WriteLine("Sequence Types: 'Fibonacci', 'Geometric', 'Prime', 'Factorial' 'Triangular', 'Perfect Squares'");
    Console.Write("Enter the type of sequence: ");
    sequenceName = Console.ReadLine();
}


sequenceName = sequenceName.ToLower();

try
{
    switch (sequenceName)
    {
        case "fibonacci":
            Sequence.PrintFibonacci(numberOfTerms);
            break;
        case "geometric":
            int firstTerm, ratio;
            Console.Write("Enter the first term of the geometric sequence: ");
            while (!int.TryParse(Console.ReadLine(), out firstTerm))
            {
                Console.WriteLine("Invalid Value. Please enter a valid positive numeric value!");
                Console.Write("Enter the first term of the geometric sequence: ");
            }

            Console.Write("Enter the ratio of the geometric sequence: ");
            while (!int.TryParse(Console.ReadLine(), out ratio))
            {
                Console.WriteLine("Invalid Value. Please enter a valid positive numeric value!");
                Console.Write("Enter the ratio of the geometric sequence: ");
            }

            Sequence.PrintGeometric(numberOfTerms, firstTerm, ratio);

            break;
        case "prime":
            Sequence.PrintPrimes(numberOfTerms);
            break;
        case "factorial":
            Sequence.PrintFactorial(numberOfTerms);
            break;
        case "triangular":
            Sequence.PrintTriangular(numberOfTerms);
            break;
        case "perfect squares":
            Sequence.PrintPerfectSquares(numberOfTerms);
            break;
        default:
            throw new Exception("Invalid Sequence Type");
    }
}
catch (Exception e)
{
    Console.WriteLine();
    Console.WriteLine(e.Message);
}