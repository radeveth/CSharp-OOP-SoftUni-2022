using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Student : Person
    {
        public string school;
        public string School
        {
            get { return school; }
            set { school = value; }
        }

        public List<double> Grades { get; set; }
    }

    public class HighSchoolStudent : Student
    {
        public int Class { get; set; }
    }

    public class UniversityStudent : Student
    {
        public int Semester { get; set; }
    }
}
