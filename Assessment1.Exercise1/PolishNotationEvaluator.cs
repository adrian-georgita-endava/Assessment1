using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assessment1.Exercise1
{
    public class PolishNotationEvaluator : IExpressionEvaluator
    {
        private readonly Dictionary<char, int> _operators;

        private Dictionary<string, Func<int, int, int>> _operations;

        private Stack<int> _numbersStack = new();

        private IExpression _polishExpression;
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

            _polishExpression = new PolishExpression(operators);
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

            string polishExpression = _polishExpression.Build(expression);

            _numbersStack = new Stack<int>();

            EvaluateThePostfixExpression(polishExpression);

            if (_numbersStack.Count != 1)
            {
                throw new Exception("Invalid Expression");
            }

            return _numbersStack.Pop();
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

        private void EvaluateThePostfixExpression(string polishExpression)
        {
            foreach (var item in polishExpression.Split(' '))
            {
                if (int.TryParse(item, out int number))
                {
                    _numbersStack.Push(number);
                    continue;
                }

                PerformAtomicOperationOnTwoNumbers(item);
            }
        }

        private void PerformAtomicOperationOnTwoNumbers(string operationSymbol)
        {
            if (_numbersStack.Count < 2)
            {
                throw new Exception("Invalid Expression");
            }

            if (!_operations.ContainsKey(operationSymbol))
            {
                throw new Exception($"Invalid Operator: '{operationSymbol}'");
            }

            int number2 = _numbersStack.Pop();
            int number1 = _numbersStack.Pop();
            int result;   

            result = _operations[operationSymbol].Invoke(number1, number2);

            _numbersStack.Push(result);
        }
    }
}
