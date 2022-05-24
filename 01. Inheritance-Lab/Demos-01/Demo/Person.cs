using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Person
    {
        //public Person(string name, int age, string adress)
        //{
        //    this.Name = name;
        //    this.Age = age;
        //    this.Adress = adress;
        //}

        public string Name { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
    }

    class Employee : Person
    {
        public string Company { get; set; }
    }

    class Student : Person
    {
        public string School { get; set; }
        public List<double> Grades { get; set; }
        public int GraduationYear { get; set; }
    }

    class HighSchoolStudent : Student
    {
        public List<int> NumberOfHall { get; set; }
    }

    class UniversetyStudent : Student
    {
        public DateTime PromDate { get; set; }
    }

}
