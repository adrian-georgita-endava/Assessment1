using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class FactorialSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public FactorialSequence(int numberOfItems)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            long number = 1;
            for (int i = 1; i <= numberOfItems; ++i)
            {
                checked
                {
                    number *= i;
                    _sequence.Add(number);
                }
            }
        }

        List<long> ISequence<long>.GetSequence()
        {
            return _sequence;
        }

        void ISequence<long>.Show()
        {
            Console.WriteLine("Factorial Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
