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

ISequence<long> sequence;

try
{
    switch (sequenceName)
    {
        case "fibonacci":
            sequence = new FibonacciSequence(numberOfTerms);
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

            sequence = new GeometricSequence(numberOfTerms, firstTerm, ratio);
            break;
        case "prime":
            sequence = new PrimesSequence(numberOfTerms);
            break;
        case "factorial":
            sequence = new FactorialSequence(numberOfTerms);
            break;
        case "triangular":
            sequence = new TriangularSequence(numberOfTerms);
            break;
        case "perfect squares":
            sequence = new PerfectSquaresSequence(numberOfTerms);
            break;
        default:
            throw new Exception("Invalid Sequence Type");
    }

    sequence.Show();
}
catch (Exception e)
{
    Console.WriteLine();
    Console.WriteLine(e.Message);
    if(e.Message.Contains("overflow"))
    {
        Console.WriteLine("Please use a smaller number of terms!");
    }
}