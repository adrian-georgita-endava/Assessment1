using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class FibonacciSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public FibonacciSequence(int numberOfItems)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            if(numberOfItems >= 1)
            {
                _sequence.Add(0);
            }

            if(numberOfItems >= 2)
            {
                _sequence.Add(1);
            }

            if(numberOfItems > 2)
            {
                for(int i=2; i < numberOfItems; i++)
                {
                    checked
                    {
                        long x = _sequence[i-2] + _sequence[i-1];
                        _sequence.Add(x);
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
            Console.WriteLine("Fibonacci Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
