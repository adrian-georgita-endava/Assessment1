using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise14
{
    // Individual or Enterprise
    public interface IBankCustomer
    {
        public string Name { get; set; }
        public int CustomerId { get; }
        public string ToString();
    }
}
