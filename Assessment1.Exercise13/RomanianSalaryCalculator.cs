using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise13
{
    public class RomanianSalaryCalculator : ISalaryCalculator
    {
        private readonly decimal _pensionContributionRate = 0.25M;
        private readonly decimal _healthInsuranceContributionRate = 0.10M;
        private readonly decimal _incomeTaxRate = 0.10M;

        public decimal GetMonthlyGrossSalary(int hoursWorkedPerWeek, decimal hourlyTariff) => hoursWorkedPerWeek * hourlyTariff;
        public decimal GetMonthlyNetSalary(decimal grossSalary)
        {
            decimal netSalary = grossSalary;
            netSalary -= grossSalary * _pensionContributionRate;
            netSalary -= grossSalary * _healthInsuranceContributionRate;
            netSalary -= (netSalary * _incomeTaxRate);
            return netSalary;
        }
    }
}
