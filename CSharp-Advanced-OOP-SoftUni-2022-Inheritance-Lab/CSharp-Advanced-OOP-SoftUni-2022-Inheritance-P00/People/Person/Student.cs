using System;
using System.Collections.Generic;
using System.Text;

namespace People
{
    public class Student : Person
    {
        public Student()
        {

        }

        // !!! NOTE: In C# Constructors are not inherited
        public Student(string name, string adress)
            : base(name, adress)
        {

        }

        public Student(string name, string adress, string school)
            : this(name, adress)
        {
            this.School = school;
        }

        private string school;
        public string School
        {
            get { return school; }
            set { school = value; }
        }

        public List<double> Grades { get; set; }
    }

    public class HighSchoolStudent : Student
    {
        public HighSchoolStudent()
        {

        }

        public HighSchoolStudent(string name, string adress, string school, int numberOfClass)
            : base(name, adress, school)
        {
            this.NumberOfClass = NumberOfClass;
        }

        public int NumberOfClass { get; set; }
    }

    public class UniversityStudent : Student
    {
        public UniversityStudent()
        {

        }

        public UniversityStudent(string name, string adress, string school, int semester)
            : base(name, adress, school)
        {
            this.Semester = semester;
        }

        public int Semester { get; set; }
    }
}
