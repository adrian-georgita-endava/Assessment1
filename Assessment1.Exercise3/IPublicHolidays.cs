using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise3
{
    public interface IPublicHolidays
    {
        public Dictionary<DateOnly, string> Dates { get; }

        public DateOnly GetEasterDate();

        public void Display();
    }
}
