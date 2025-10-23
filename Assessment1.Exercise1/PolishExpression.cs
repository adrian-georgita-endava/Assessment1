using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise1
{
    public sealed class PolishExpression : IExpression
    {
        private readonly Dictionary<char, int> _operators;

        private Stack<char> _operatorsStack = new();
        private List<string> _polishNotation = new();

        public PolishExpression(Dictionary<char, int> operators) => _operators = operators;

        /// <summary>
        /// Returns the Postfix Notation of an expression if possible ( a+b => ab+ )
        /// </summary>
        /// <param name="expression">The expression we want to obtain the notation for</param>
        /// <returns>A string representing the postfix notation of an expression</returns>
        /// <exception cref="Exception"></exception>
        public string Build(string expression)
        {
            _operatorsStack = new Stack<char>();
            _polishNotation = new List<string>();
            var number = string.Empty;

            expression = expression.Replace(" ", "");

            number = BuildThePostfixExpressionBasedOnTheInitialExpression(expression, number);

            if (number.Length > 0)
            {
                _polishNotation.Add(number);
            }

            AddRemainingOperators();

            return string.Join(" ", _polishNotation);
        }

        private string BuildThePostfixExpressionBasedOnTheInitialExpression(string expression, string number)
        {
            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                    continue;
                }

                if (number.Length > 0)
                {
                    _polishNotation.Add(number);
                    number = string.Empty;
                }

                if (c == '(')
                {
                    _operatorsStack.Push(c);
                    continue;
                }

                if (c == ')')
                {
                    AddTheOperatorsOfASubExpression(c);
                    continue;
                }

                AddOperatorsWithHigherPrecedence(c);
                _operatorsStack.Push(c);
            }

            return number;
        }
            
        private void AddTheOperatorsOfASubExpression(char c)
        {
            while (_operatorsStack.Count > 0 && _operatorsStack.Peek() != '(')
            {
                _polishNotation.Add(_operatorsStack.Pop().ToString());
            }

            if (_operatorsStack.Count == 0)
            {
                throw new Exception("Unbalanced parantheses");
            }

            _operatorsStack.Pop();
        }

        private void AddOperatorsWithHigherPrecedence(char c)
        {
            while (_operatorsStack.Count > 0 && _operatorsStack.Peek() != '('
                            && _operators.GetValueOrDefault(_operatorsStack.Peek(), 0) >= _operators.GetValueOrDefault(c, 0))
            {
                _polishNotation.Add(_operatorsStack.Pop().ToString());
            }
        }

        private void AddRemainingOperators()
        {
            while (_operatorsStack.Count > 0)
            {
                if (_operatorsStack.Peek() == '(')
                {
                    throw new Exception("Unbalanced parantheses");
                }
                _polishNotation.Add(_operatorsStack.Pop().ToString());
            }
        }
    }
}
