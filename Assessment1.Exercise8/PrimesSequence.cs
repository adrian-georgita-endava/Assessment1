using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class PrimesSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public PrimesSequence(int numberOfItems)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            if (numberOfItems >= 1)
            {
                _sequence.Add(2);
            }

            long x = 3;
            for (int i = 1; i < numberOfItems; i++)
            {
                bool foundPrime = false;
                while (!foundPrime)
                {
                    bool isPrime = true;
                    for (int d = 2; d * d <= x; d++)
                    {
                        if (x % d == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        foundPrime = true;
                        _sequence.Add(x);
                    }

                    checked
                    {
                        x++;
                    }
                }
            }
        }

        List<long> ISequence<long>.GetSequence()
        {
            return _sequence;
        }

        void ISequence<long>.Show()
        {
            Console.WriteLine("Primes Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
