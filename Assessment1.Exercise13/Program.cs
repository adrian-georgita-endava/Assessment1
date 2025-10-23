using Assessment1.Exercise13;
using System.Security.Principal;

Console.WriteLine("Welcome to the Salary Calculator");

Console.WriteLine("How many hours do you work per week?");
Console.Write("Weekly Working Hours: ");
int weeklyWorkedHours;
while (!int.TryParse(Console.ReadLine(), out weeklyWorkedHours) || weeklyWorkedHours < 0)
{
    Console.WriteLine("Please provide a valid positive number!");
    Console.Write("Weekly Working Hours: ");
}

Console.WriteLine("When did you start working? Please provide the date in the 'dd.mm.yyyy' format.");
Console.Write("Start Date: ");
DateOnly startDate;
while(!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out startDate) || startDate > DateOnly.FromDateTime(DateTime.UtcNow))
{
    Console.WriteLine("Please provide a valid date in the 'dd.mm.yyyy' format!");
    Console.Write("Start Date: ");
}

IEmployeeFinances employeeFinances = new EmployeeFinances(startDate, weeklyWorkedHours);

Console.WriteLine($"Current Year Monthly Gross Salary: {employeeFinances.GetMonthlyGrossSalary()}");
Console.WriteLine($"Current Year Monthly Taxes Paid: {employeeFinances.GetMonthlyGrossSalary() - employeeFinances.GetMonthlyNetSalary()}");
Console.WriteLine($"Total Net Income: {employeeFinances.GetTotalNetSalary()}");