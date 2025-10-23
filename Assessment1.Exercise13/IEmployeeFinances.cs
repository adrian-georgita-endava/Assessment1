using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise13
{
    // Interface because we might have employees with multiple income sources
    public interface IEmployeeFinances
    {
        public DateOnly StartDate { get; init; }
        public int HoursWorkedPerWeek { get; set; }
        public Dictionary<int, decimal> HourlyRates { get; set; }
        public decimal GetTotalNetSalary();
        public decimal GetMonthlyGrossSalary();
        public decimal GetMonthlyGrossSalary(int year);
        public decimal GetMonthlyNetSalary();
        public decimal GetMonthlyNetSalary(int year);
    }
}
