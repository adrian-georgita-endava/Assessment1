using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise3
{
    public class Calendar
    {
        public int Year { get; init; }

        private readonly IPublicHolidays _publicHolidays;

        public Calendar(int year, IPublicHolidays publicHolidays)
        {
            Year = year;
            _publicHolidays = publicHolidays;
        }

        public bool IsLeapYear => (Year % 400 == 0) || (Year % 4 == 0 && Year % 100 != 0);

        public int Days => IsLeapYear ? 366 : 365;
        public int Weeks => Days / 7;
        public int NumberOfFreeDays => _publicHolidays.Dates.Count;
        public int WorkDays => Days - Weeks * 2 - NumberOfFreeDays;

        public void DisplayPublicHolidays() => _publicHolidays.Display();
    }
}
