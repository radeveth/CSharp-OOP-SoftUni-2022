using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person : Object
    {
        private const int PERSON_MIN_AGE = 0;

        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            { 
                return name;
            }
            set
            { 
                name = value;
            }
        }

        public virtual int Age
        {
            get
            { 
                return age;
            }
            protected set 
            {
                if (value >= PERSON_MIN_AGE)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {name}, Age: {age}");
            return stringBuilder.ToString();
        }
    }
}
