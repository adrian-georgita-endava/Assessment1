using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class PerfectSquaresSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public PerfectSquaresSequence(int numberOfItems)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            for (long i = 1; i <= numberOfItems; ++i)
            {
                checked
                {
                    _sequence.Add(i*i);
                }
            }
        }

        List<long> ISequence<long>.GetSequence()
        {
            return _sequence;
        }

        void ISequence<long>.Show()
        {
            Console.WriteLine("Perfect Squares Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
