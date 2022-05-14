using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private const int MAX_CHILD_AGE = 15;

        public Child(string name, int age)
            : base(name, age)
        {

        }

        public override int Age
        {
            get 
            {
                return base.Age;
            }
            protected set
            {
                if (value <= MAX_CHILD_AGE)
                {
                    base.Age = value;
                }
            }
        }
    }
}
