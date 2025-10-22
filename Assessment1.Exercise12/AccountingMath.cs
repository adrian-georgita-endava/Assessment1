using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise12
{
    public static class AccountingMath
    {
        public static decimal SafeDivide(decimal numerator, decimal denominator, int decimals)
        {
            if(denominator == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0");
            }

            decimal result = numerator / denominator;

            return Math.Round(result, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
