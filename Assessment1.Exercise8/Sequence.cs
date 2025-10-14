using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public static class Sequence
    {
        public static void PrintFibonacci(int numberOfTerms)
        {
            Console.WriteLine("Fibonacci Sequence");

            long f1 = 0;
            long f2 = 1;

            if (numberOfTerms >= 1)
            {
                Console.Write($"{f1} ");
            }

            if(numberOfTerms >= 2)
            {
                Console.Write($"{f2} ");
            }

            if(numberOfTerms > 2)
            {
                for (int i = 2; i < numberOfTerms; i++)
                {
                    checked
                    {
                        long f3 = f1 + f2;
                        Console.Write($"{f3} ");
                        f1 = f2;
                        f2 = f3;
                    }
                }
            }
        }

        public static void PrintGeometric(int numberOfTerms, int firstTerm, int ratio)
        {
            Console.WriteLine("Geometric Sequence");

            long r = ratio;
            long a = firstTerm;

            if(numberOfTerms >= 1)
            {
                Console.Write($"{a} + ");
            }

            for (int i = 1; i < numberOfTerms; ++i)
            {
                checked
                {
                    Console.Write($"{a * r}");
                    r *= ratio;
                }

                if(i !=  numberOfTerms - 1)
                {
                    Console.Write(" + ");
                }
            }
        }

        public static void PrintPrimes(int numberOfTerms)
        {
            Console.WriteLine("Primes Sequence");

            if (numberOfTerms >= 1)
            {
                Console.Write("2 ");
            }

            long x = 3;
            for(int i = 1; i < numberOfTerms; i++)
            {
                bool foundPrime = false;
                while(!foundPrime)
                {
                    bool isPrime = true;
                    for(int d=2; d*d <= x; d++)
                    {
                        if(x%d == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if(isPrime)
                    {
                        foundPrime = true;
                        Console.Write($"{x} ");
                    }

                    checked
                    {
                        x++;
                    }
                }
            }
        }

        public static void PrintFactorial(int numberOfTerms)
        {
            Console.WriteLine("Factorial Sequence");

            long number = 1;
            for(int i=1; i <= numberOfTerms; ++i)
            {
                checked
                {
                    number *= i;
                    Console.Write($"{number} ");
                }
            }
        }

        public static void PrintPerfectSquares(int numberOfTerms)
        {
            Console.WriteLine("Perfect Squares Sequence");

            for (long i=1; i<=numberOfTerms; ++i)
            {
                checked
                {
                    Console.Write($"{i * i} ");
                }
            }
        }

        public static void PrintTriangular(int numberOfTerms)
        {
            Console.WriteLine("Triangular Sequence");
            for(int i = 1; i <= numberOfTerms; i++)
            {
                checked
                {
                    Console.Write($"{(i * (i + 1)) / 2} ");
                }
            }
        }
    }
}