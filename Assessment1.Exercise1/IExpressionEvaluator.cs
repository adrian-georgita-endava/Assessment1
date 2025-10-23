using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise1
{
    public interface IExpressionEvaluator
    {
        public int Evaluate(string expression);

        public bool IsValidExpression(string expression);
    }
}
