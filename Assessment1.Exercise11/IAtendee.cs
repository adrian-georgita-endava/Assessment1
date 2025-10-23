using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise11
{
    public interface IAtendee
    {
        public void Update(IEvent @event);

        public bool RequestAnswer(IEvent @event);
    }
}
