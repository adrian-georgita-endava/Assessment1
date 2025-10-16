using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise2
{
    public class Student
    {
        public int Id { get; init; }
        public string FirstName { get; init; } = String.Empty;
        public string LastName { get; init; } = String.Empty;
        public List<Enrollement> Enrollements { get; } = new();

        private static int _currentId = 0;

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = _currentId++;
        }

        public int GetAverageGrade()
        {
            return (int) Enrollements.Where(e => e.Grades.Count > 0).Average(e => e.GetAverageGrade());
        }

        public int GetAverageCourseGrade(string courseCode)
        {
            Enrollement? enrollement = Enrollements.FirstOrDefault(e => e.CourseCode == courseCode);
            if (enrollement == null)
                throw new Exception("Student is not enrolled to this course");

            return enrollement.GetAverageGrade();
        }

        public void Enroll(Course course)
        {
            Enrollements.Add(new Enrollement(this, course));
        }
    }
}
