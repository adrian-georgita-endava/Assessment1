using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public class TriangularSequence : ISequence<long>
    {
        private List<long> _sequence;
        private int _numberOfItems;

        public TriangularSequence(int numberOfItems)
        {
            _sequence = new List<long>();
            _numberOfItems = numberOfItems;

            for (int i = 1; i <= numberOfItems; i++)
            {
                checked
                {
                    _sequence.Add((i*(i+1))/2);
                }
            }
        }

        List<long> ISequence<long>.GetSequence()
        {
            return _sequence;
        }

        void ISequence<long>.Show()
        {
            Console.WriteLine("Triangular Sequence");
            foreach(var item in _sequence)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
