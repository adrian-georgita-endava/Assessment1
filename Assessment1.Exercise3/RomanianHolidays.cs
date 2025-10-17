using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise3
{
    public class RomanianHolidays : IPublicHolidays
    {
        private Dictionary<DateOnly, string> _dates;
        private int _year;
        public Dictionary<DateOnly, string> Dates { get => _dates;  }

        public RomanianHolidays(int year)
        {
            _dates = new Dictionary<DateOnly, string>();
            _year = year;

            AddFixedHolidays();
            AddVariableHolidays();
        }

        public DateOnly GetEasterDate()
        {
            int a = _year % 4;
            int b = _year % 7;
            int c = _year % 19;
            int d = (19 * c + 15) % 30;
            int e = (2 * a + 4 * b - d + 34) % 7;
            int month = (int) Math.Floor((double) ((d + e + 114) / 31));
            int day = ((d + e + 114) % 31) + 1;

            DateOnly julianEaster = new DateOnly(_year, month, day);

            DateOnly gregorianEaster = julianEaster.AddDays(13);

            return gregorianEaster;
        }

        private void AddFixedHolidays()
        {
            _dates.Add(new DateOnly(_year, 1, 1), "New Year's Day");
            _dates.Add(new DateOnly(_year, 1, 2), "Day after New Year's Day");
            _dates.Add(new DateOnly(_year, 1, 6), "Epiphany");
            _dates.Add(new DateOnly(_year, 1, 7), "Synaxis of St. John the Baptizer");
            _dates.Add(new DateOnly(_year, 1, 24), "Unification Day");
            _dates.Add(new DateOnly(_year, 5, 1), "Labor Day");
            _dates.Add(new DateOnly(_year, 8, 15), "St. Mary's Day");
            _dates.Add(new DateOnly(_year, 11, 30), "St. Andrew's Day");
            _dates.Add(new DateOnly(_year, 12, 1), "National Day");
            _dates.Add(new DateOnly(_year, 12, 25), "Christmas Day");
            _dates.Add(new DateOnly(_year, 12, 26), "Second day of Christmas");
        }

        private void AddVariableHolidays()
        {
            DateOnly easter = GetEasterDate();

            _dates.Add(easter.AddDays(-2), "Orthodox Easter");
            _dates.Add(easter.AddDays(-1), "Orthodox Easter");
            _dates.Add(easter, "Orthodox Easter");
            _dates.Add(easter.AddDays(1), "Orthodox Easter");

            _dates.Add(easter.AddDays(49), "Orthodox Pentecost");
            _dates.Add(easter.AddDays(50), "Orthodox Pentecost");
        }

        public void Display()
        {
            Console.WriteLine($"Public Holidays of {_year}");
            foreach (var key in _dates.Keys.Order())
            {
                Console.WriteLine($"{key.ToString("dd/MM/yyyy")} - {_dates[key]}");
            }
        }
    }
}
