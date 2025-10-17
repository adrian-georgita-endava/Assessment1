using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise4
{
    public interface IAuthentificator
    {
        public bool Authentificate(string user, string password);
    }
}
