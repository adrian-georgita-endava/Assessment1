Console.WriteLine("Welcome to the Calculator");
Console.Write("Please enter the expression to evaluate: ");
string? expression = Console.ReadLine();

char[] operators = ['+', '-', '*', '/', '%', '(', ')'];

bool IsValidExpression(string expression)
{
    expression = expression.Replace(" ", "");
    foreach (char c in expression)
    {
        if(!char.IsDigit(c) && !operators.Contains(c))
        {
            return false;
        }
    }
    return true;
}

while(String.IsNullOrEmpty(expression) || !IsValidExpression(expression))
{
    Console.WriteLine("Please enter a valid expression! Valid Operators: '+ - * / % ( )'");
    Console.Write("Expression to evaluate: ");
    expression = Console.ReadLine();
}

string ToPolishNotation(string expression)
{
    var operatorsStack = new Stack<char>();
    var polishNotation = new List<string>();

    expression = expression.Replace(" ", "");

    foreach (char c in expression)
    {
        if (char.IsDigit(c))
        {
            polishNotation.Add(c.ToString());
        }
        else if (c == '(')
        {
            operatorsStack.Push(c);
        }
        else if (c == ')')
        {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != '(')
            {
                polishNotation.Add(operatorsStack.Pop().ToString());
            }

            if (operatorsStack.Count == 0)
            {
                throw new Exception("Unbalanced parantheses");
            }

            operatorsStack.Pop();
        }
        else
        {
            while (operatorsStack.Count > 0 && operatorsStack.Peek() != '(')
            {
                polishNotation.Add(operatorsStack.Pop().ToString());
            }

            operatorsStack.Push(c);
        }
    }

    while(operatorsStack.Count > 0)
    {
        if(operatorsStack.Peek() == '(')
        {
            throw new Exception("Unbalanced parantheses");
        }
        polishNotation.Add(operatorsStack.Pop().ToString());
    }

    return String.Join(" ", polishNotation);
}

int Evaluate(string expression)
{
    var numbersStack = new Stack<int>();

    foreach(var item in expression.Split(' '))
    {
        if(int.TryParse(item, out int number))
        {
            numbersStack.Push(number);
        }
        else
        {
            if(numbersStack.Count < 2)
            {
                throw new Exception("Invalid Expression");
            }

            int number2 = numbersStack.Pop();
            int number1 = numbersStack.Pop();
            switch(item)
            {
                case "+":
                    numbersStack.Push(number1 + number2);
                    break;
                case "-":
                    numbersStack.Push(number1 - number2);
                    break;
                case "*":
                    numbersStack.Push(number1 * number2);
                    break;
                case "/":
                    numbersStack.Push(number1 / number2);
                    break;
                case "%":
                    numbersStack.Push(number1 % number2);
                    break;
                default:
                    throw new Exception($"Invalid Operator: '{item}'");
            }
        }
    }

    if(numbersStack.Count != 1)
    {
        throw new Exception("Invalid Expression");
    }

    return numbersStack.Pop();
}


try
{
    var polishExpression = ToPolishNotation(expression);
    Console.WriteLine($"Polish Expression: {polishExpression}");
    int result = Evaluate(polishExpression);

    Console.WriteLine($"Result: {result}");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}