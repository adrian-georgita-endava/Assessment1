using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise13
{
    public interface ISalaryCalculator
    {
        public decimal GetMonthlyGrossSalary(int hoursWorkedPerWeek, decimal hourlyTariff);
        public decimal GetMonthlyNetSalary(decimal grossSalary);
    }
}
