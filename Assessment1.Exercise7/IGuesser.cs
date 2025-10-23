using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise7
{
    public interface IGuesser<T>
    {
        public int Guesses { get; }
        public T GetGuess();
        public bool ReadUserResponse();
    }
}
