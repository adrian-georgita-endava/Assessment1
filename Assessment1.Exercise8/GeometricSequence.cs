using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class GeometricSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public GeometricSequence(int numberOfItems, int firstTerm, int ratio)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            long r = ratio;
            long a = firstTerm;

            if (numberOfItems >= 1)
            {
                _sequence.Add(a);
            }

            for (int i = 1; i < numberOfItems; ++i)
            {
                checked
                {
                    _sequence.Add(a * r);
                    r *= ratio;
                }
            }
        }

        List<long> ISequence<long>.GetSequence()
        {
            return _sequence;
        }

        void ISequence<long>.Show()
        {
            Console.WriteLine("Geometric Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} +");
            }
        }
    }
}
