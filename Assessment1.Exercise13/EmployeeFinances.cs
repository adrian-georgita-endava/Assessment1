using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise13
{
    public class EmployeeFinances : IEmployeeFinances
    {
        public DateOnly StartDate { get; init; }
        public int HoursWorkedPerWeek { get; set; }
        public Dictionary<int, decimal> HourlyRates { get; set; }

        private ISalaryCalculator _salaryCalculator;

        public EmployeeFinances(DateOnly startDate, int hoursWorkedPerWeek)
        {
            StartDate = startDate;
            HourlyRates = new();
            HoursWorkedPerWeek = hoursWorkedPerWeek;
            _salaryCalculator = new RomanianSalaryCalculator();
            AddHourlyRatesPerYear();
        }

        public decimal GetTotalNetSalary()
        {
            decimal total = 0;
            int startYear = StartDate.Year; ;
            int currentYear = DateTime.UtcNow.Year;

            for (int year = startYear; year <= currentYear; year++)
            {
                total += (GetMonthlyNetSalary(year) * GetWorkedMonths(year));
            }

            return total;
        }
        public decimal GetMonthlyGrossSalary() => _salaryCalculator.GetMonthlyGrossSalary(HoursWorkedPerWeek, HourlyRates[DateTime.UtcNow.Year]);
        public decimal GetMonthlyGrossSalary(int year) => HourlyRates.ContainsKey(year) ? _salaryCalculator.GetMonthlyGrossSalary(HoursWorkedPerWeek, HourlyRates[year]) : throw new Exception($"There is no hourly rate for the year: {year}");
        public decimal GetMonthlyNetSalary() => _salaryCalculator.GetMonthlyNetSalary(GetMonthlyGrossSalary());
        public decimal GetMonthlyNetSalary(int year) => HourlyRates.ContainsKey(year) ? _salaryCalculator.GetMonthlyNetSalary(GetMonthlyGrossSalary(year)) : throw new Exception($"There is no hourly rate for the year: {year}");

        private int GetWorkedMonths(int year)
        {
            if(year == StartDate.Year)
            {
                return 12 - StartDate.Month - 1;
            }

            if(year == DateTime.UtcNow.Year)
            {
                return DateTime.UtcNow.Month - 1;
            }

            return 12;
        }

        private void AddHourlyRatesPerYear()
        {
            int startYear = StartDate.Year;
            int currentYear = DateTime.UtcNow.Year;

            for (int year = startYear; year <= currentYear; year++)
            {
                decimal hourlyRate = AskHourlyRate(year);
                AddHourlyRate(year, hourlyRate);
            }
        }

        private void AddHourlyRate(int year, decimal hourlyRate) => HourlyRates.Add(year, hourlyRate);

        private decimal AskHourlyRate(int year)
        {
            Console.WriteLine($"What was your hourly rate for the year: {year}?");
            decimal hourlyRate;
            Console.Write("Hourly Rate: ");
            while (!decimal.TryParse(Console.ReadLine(), out hourlyRate) || hourlyRate < 0)
            {
                Console.WriteLine("Invalid Hourly Rate! Please provide a valid positive value!");
                Console.Write("Hourly Rate: ");
            }

            return hourlyRate;
        }
    }
}
