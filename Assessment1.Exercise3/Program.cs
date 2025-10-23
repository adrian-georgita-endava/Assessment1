using Assessment1.Exercise3;

Console.WriteLine("Welcome to the Year Verifier");

int year;
Console.Write("Year to verify: ");
while (!int.TryParse(Console.ReadLine(), out year) || year < 0)
{
    Console.WriteLine("Please provide a valid year");
    Console.Write("Year to verify: ");
}

IPublicHolidays publicHolidays = new RomanianHolidays(year);
Calendar calendar = new Calendar(year, publicHolidays);

Console.WriteLine();
Console.WriteLine($"Leap year: {calendar.IsLeapYear}");
Console.WriteLine($"Days: {calendar.Days}");
Console.WriteLine($"Work Days: {calendar.WorkDays}");
Console.WriteLine($"Weeks: {calendar.Weeks}");
Console.WriteLine();
calendar.DisplayPublicHolidays();