using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise2
{
    public class Enrollement
    {
        public int StudentId { get; init; }
        public Student Student { get; init; }
        
        public string CourseCode { get; init; } = String.Empty;
        public Course Course { get; init; }

        public List<int> Grades { get; } = new List<int>();

        public Enrollement(Student student, Course course)
        {
            Student = student;
            StudentId = student.Id;

            Course = course;
            CourseCode = course.Code;
        }

        public int GetAverageGrade()
        {
            return Grades.Count > 0 ? (int) Grades.Average(x => x) : 0;
        }
    }
}
