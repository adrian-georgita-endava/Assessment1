using Assessment1.Exercise1;

Console.WriteLine("Welcome to the Calculator");
Console.Write("Please enter the expression to evaluate: ");
string? expression = Console.ReadLine();

Dictionary<char, int> operatorsList = new()
{
    {'+', 1 }, {'-', 1 },
    {'*', 2 }, {'/', 2 }, {'%', 2 },
    {'(', 0 }, {')', 1 }
};

IExpressionEvaluator evaluator = new PolishNotationEvaluator(operatorsList);

while(String.IsNullOrEmpty(expression))
{
    Console.WriteLine("Please enter a valid expression! Valid Operators: '+ - * / % ( )'");
    Console.Write("Expression to evaluate: ");
    expression = Console.ReadLine();
}

try
{
    int result = evaluator.Evaluate(expression);

    Console.WriteLine($"Result: {result}");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}