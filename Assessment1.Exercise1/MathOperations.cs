using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise1
{
    public static class MathOperations
    {
        public static int Add(int a, int b) => a + b;
        public static int Substract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;
        public static int Divide(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by 0");
        public static int Modulo(int a, int b) => a % b;
    }
}
