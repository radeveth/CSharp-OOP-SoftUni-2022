using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TOMCAT_GENDER = "Male";

        public Tomcat(string name, int age)
            : base(name, age, TOMCAT_GENDER)
        {
        }

        protected override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
