using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise2
{
    public class Course
    {
        public string Code { get; init; }
        public string Title { get; init; }
        public List<Enrollement> Enrollements { get; } = new();

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}
