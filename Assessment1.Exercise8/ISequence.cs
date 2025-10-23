using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise8
{
    public interface ISequence<T>
    {
        public List<T> GetSequence();

        public void Show();
    }
}
