using Assessment1.Exercise2;

Console.WriteLine("Welcome to the Average Grade Evaluator");

var courses = new List<Course>()
{
    new Course(code: "TI.DI.101", title: "Mathematics"),
    new Course(code: "TI.DI.102", title: "Informatics"),
    new Course(code: "TI.DI.103", title: "Physics"),
};

var student1 = new Student(firstName: "FirstName", lastName: "LastName");
student1.Enroll(courses[0]);
student1.Enroll(courses[1]);
student1.Enroll(courses[2]);

int grade;
foreach(var enrollement in student1.Enrollements)
{
    grade = -1;
    Console.WriteLine($"Please enter the grades for the {enrollement.Course.Title} course or '-1' to continue");
    do
    {
        Console.Write("Grade: ");
        while (!int.TryParse(Console.ReadLine(), out grade) || grade < -1 || grade > 100)
        {
            Console.WriteLine("Invalid Grade! Please enter a value between ( 0 - 100 ) or '-1' to continue.");
            Console.Write("Grade: ");
        }

        if (grade == -1)
            break;

        enrollement.Grades.Add(grade);

    } while (grade != -1);
}

Console.WriteLine($"Average Grade: {student1.GetAverageGrade()}") ;
foreach(var enrollement in student1.Enrollements)
{
    Console.WriteLine($"Average Grade for the {enrollement.Course.Title} course is: {enrollement.GetAverageGrade()}");
}