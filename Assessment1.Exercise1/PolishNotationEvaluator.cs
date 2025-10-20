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

        private Dictionary<string, Func<int, int, int>> _operations;
        public PolishNotationEvaluator(Dictionary<char, int> operators)
        {
            _operators = operators;

            _operations = new Dictionary<string, Func<int, int, int>>()
            {
                {"+", MathOperations.Add },
                {"-", MathOperations.Substract },
                {"*", MathOperations.Multiply },
                {"/", MathOperations.Divide },
                {"%", MathOperations.Modulo },
            };
        }

        /// <summary>
        /// Evaluates an expression in the postfix notation and returns the result
        /// </summary>
        /// <param name="expression">The postfix expression</param>
        /// <returns>The result of the evaluated expression</returns>
        /// <exception cref="Exception"></exception>
        public int Evaluate(string expression)
        {
            if(!IsValidExpression(expression))
            {
                throw new Exception("Invalid expression!");
            }

            string polishExpression = GetPolishNotation(expression);

            var numbersStack = new Stack<int>();

            // Iterates trough all the elements of the postfix expression
            foreach (var item in polishExpression.Split(' '))
            {
                // If the current item is a number, add it to the numbers stack
                if (int.TryParse(item, out int number))
                {
                    numbersStack.Push(number);
                }
                // If it's an operator
                else
                {
                    // If there aren't two numbers on the stack, the expression is invalid (eg. a+ instead of ab+)
                    if (numbersStack.Count < 2)
                    {
                        throw new Exception("Invalid Expression");
                    }

                    int number2 = numbersStack.Pop();
                    int number1 = numbersStack.Pop();
                    int result;
                    // Checks if there is a corresponding function for the operator
                    if(!_operations.ContainsKey(item))
                    {
                        throw new Exception($"Invalid Operator: '{item}'");
                    }

                    result = _operations[item].Invoke(number1, number2);

                    numbersStack.Push(result);
                }
            }

            // There's more than a number after evaluating the expression, meaning there's probably a missing operator
            if (numbersStack.Count != 1)
            {
                throw new Exception("Invalid Expression");
            }

            // The final result should be the single number remaining
            return numbersStack.Pop();
        }

        /// <summary>
        /// Checks if the expression contains invalid characters. Only digits and operators provided in the constructor are valid characters.
        /// </summary>
        /// <param name="expression">A string containing the expression to evaluate</param>
        /// <returns>True, if the expression doesn't contain invalid characters and False otherwise</returns>
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

        /// <summary>
        /// Returns the Postfix Notation of an expression if possible ( a+b => ab+ )
        /// </summary>
        /// <param name="expression">The expression we want to obtain the notation for</param>
        /// <returns>A string representing the postfix notation of an expression</returns>
        /// <exception cref="Exception"></exception>
        private string GetPolishNotation(string expression)
        {
            var operatorsStack = new Stack<char>();
            var polishNotation = new List<string>();
            var number = String.Empty;

            expression = expression.Replace(" ", "");

            // Iterates trough all the characters in the expression
            foreach (char c in expression)
            {
                // Handle numbers with more than one digit
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    // Check if we previously created a number and add it to the notation
                    if (number.Length > 0)
                    {
                        polishNotation.Add(number);
                        number = String.Empty;
                    }

                    // Start of a subexpression
                    if (c == '(')
                    {
                        operatorsStack.Push(c);
                    }
                    // Ending of a subexpression
                    else if (c == ')')
                    {
                        // Add all operators of the subexpression to the notation until we meet the start of the subexpression
                        while (operatorsStack.Count > 0 && operatorsStack.Peek() != '(')
                        {
                            polishNotation.Add(operatorsStack.Pop().ToString());
                        }

                        // We don't have the corresponding start of the subexpression
                        if (operatorsStack.Count == 0)
                        {
                            throw new Exception("Unbalanced parantheses");
                        }

                        operatorsStack.Pop();
                    }
                    // The current element is an operator
                    else
                    {
                        // Add the operators with a higher precedence from the subexpression to the postfix notation
                        while (operatorsStack.Count > 0 && operatorsStack.Peek() != '('
                            && _operators.GetValueOrDefault(operatorsStack.Peek(), 0) >= _operators.GetValueOrDefault(c, 0))
                        {
                            polishNotation.Add(operatorsStack.Pop().ToString());
                        }

                        operatorsStack.Push(c);
                    }
                }
            }

            // Add the remaining number if there is one
            if (number.Length > 0)
            {
                polishNotation.Add(number);
            }

            // Add the remaining operators
            while (operatorsStack.Count > 0)
            {
                // The initial expression is missing a closing paranthese
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
