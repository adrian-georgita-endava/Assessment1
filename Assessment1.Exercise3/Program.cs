Console.WriteLine("Welcome to the Year Verifier");

int year;
Console.Write("Year to verify: ");
while (!int.TryParse(Console.ReadLine(), out year) || year < 0)
{
    Console.WriteLine("Please provide a valid year");
    Console.Write("Year to verify: ");
}

var freeDays = new Dictionary<int, string>()
{
    {1, "1 Ianuarie - Anul Nou" },
    {2, "2 Ianuarie - Anul Nou" },
    {6, "2 Ianuarie - Boboteaza"},
    {7, "7 Ianuarie - Sfantul Ioan Botezatorul" },
    {24, "24 Ianuarie - Ziua Unirii Principatelor Romane" },
    {108, "18 Aprilie - Paste Ortodox"},
    {109, "19 Aprilie - Paste Ortodox"},
    {110, "20 Aprilie - Paste Ortodox"},
    {111, "21 Aprilie - Paste Ortodox"},
    {121, "1 Mai - Ziua Muncii" },
    {152, "1 Iunie - Ziua Copilului" },
    {159, "8 Iunie - Rusalii" },
    {160, "9 Iunie - Rusalii" },
    {227, "15 August - Adormirea Maicii Domnului" },
    {334, "30 Noiembrie - Sfantul Andrei" },
    {335, "1 Decembrie - Ziua Nationala a Romaniei" },
    {359, "25 Decembrie - Craciunul" },
    {360, "26 Decembrie - Craciunul" }
};

bool isLeapYear = (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
int days = isLeapYear ? 366 : 365;
int weeks = days / 7;
int numberOfFreeDays = freeDays.Count;
int workDays = days - weeks * 2 - numberOfFreeDays;

Console.WriteLine($"Leap year: {isLeapYear}");
Console.WriteLine($"Days: {days}");
Console.WriteLine($"Work Days: {workDays}");
Console.WriteLine($"Weeks: {weeks}");
Console.WriteLine("Free Days");
foreach (int key in freeDays.Keys)
{
    Console.WriteLine(freeDays[key]);
}