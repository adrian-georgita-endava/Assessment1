using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise15
{
    public interface IPromotion
    {
        string Name { get; set; }

        public bool IsApplicable(IProduct product);
        public decimal GetDiscount(IProduct product);
    }
}
