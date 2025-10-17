using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise1
{
    public class PolishNotationEvaluator : IExpressionEvaluator
    {
        private readonly Dictionary<char, int> _operators;

        public PolishNotationEvaluator(Dictionary<char, int> operators)
        {
            _operators = operators;
        }

        public int Evaluate(string expression)
        {
            if(!IsValidExpression(expression))
            {
                throw new Exception("Invalid expression!");
            }

            string polishExpression = GetPolishNotation(expression);

            var numbersStack = new Stack<int>();

            foreach (var item in polishExpression.Split(' '))
            {
                if (int.TryParse(item, out int number))
                {
                    numbersStack.Push(number);
                }
                else
                {
                    if (numbersStack.Count < 2)
                    {
                        throw new Exception("Invalid Expression");
                    }

                    int number2 = numbersStack.Pop();
                    int number1 = numbersStack.Pop();
                    int result;
                    switch (item)
                    {
                        case "+":
                            result = MathOperations.Add(number1, number2);
                            break;
                        case "-":
                            result = MathOperations.Substract(number1, number2);
                            break;
                        case "*":
                            result = MathOperations.Multiply(number1, number2);
                            break;
                        case "/":
                            result = MathOperations.Divide(number1, number2);
                            break;
                        case "%":
                            result = MathOperations.Modulo(number1, number2);
                            break;
                        default:
                            throw new Exception($"Invalid Operator: '{item}'");
                    }

                    numbersStack.Push(result);
                }
            }

            if (numbersStack.Count != 1)
            {
                throw new Exception("Invalid Expression");
            }

            return numbersStack.Pop();
        }

        public bool IsValidExpression(string expression)
        {
            expression = expression.Replace(" ", "");
            foreach (char c in expression)
            {
                if (!char.IsDigit(c) && !_operators.ContainsKey(c))
                {
                    return false;
                }
            }
            return true;
        }

        private string GetPolishNotation(string expression)
        {
            var operatorsStack = new Stack<char>();
            var polishNotation = new List<string>();
            var number = String.Empty;

            expression = expression.Replace(" ", "");

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    if (number.Length > 0)
                    {
                        polishNotation.Add(number);
                        number = String.Empty;
                    }

                    if (c == '(')
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
                        while (operatorsStack.Count > 0 && operatorsStack.Peek() != '('
                            && _operators.GetValueOrDefault(operatorsStack.Peek(), 0) >= _operators.GetValueOrDefault(c, 0))
                        {
                            polishNotation.Add(operatorsStack.Pop().ToString());
                        }

                        operatorsStack.Push(c);
                    }
                }
            }

            if (number.Length > 0)
            {
                polishNotation.Add(number);
            }

            while (operatorsStack.Count > 0)
            {
                if (operatorsStack.Peek() == '(')
                {
                    throw new Exception("Unbalanced parantheses");
                }
                polishNotation.Add(operatorsStack.Pop().ToString());
            }

            return String.Join(" ", polishNotation);
        }
    }
}
