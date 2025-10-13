Console.WriteLine("Welcome to the Average Grade Evaluator");

int grade = -1;
int count = 0;
double avg = 0;
do
{
    Console.Write("Please enter a grade (0 - 100) or '-1' to stop: ");
    if(int.TryParse(Console.ReadLine(), out grade))
    {
        if(grade == -1)
        {
            break;
        }

        if(grade < -1 || grade > 100)
        {
            Console.WriteLine("Invalid Grade! Please provide a grade in the range (0 - 100) or '-1' to stop");
            continue;
        }

        count++;
        avg += grade;
    }
    else
    {
        Console.WriteLine("Invalid Grade! Please provide a grade in the range (0 - 100) or '-1' to stop");
        continue;
    }
} while (grade != -1);

if (count > 0)
{
    Console.WriteLine($"Average Grade: {avg / count}");
}
else
{
    Console.WriteLine("No grades provided");
}