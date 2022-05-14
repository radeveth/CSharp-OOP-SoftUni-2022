using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kittens : Cat
    {
        private const string KITTEN_GENDER = "Female";

        public Kittens(string name, int age)
            : base(name, age, KITTEN_GENDER)
        {
        }

        protected override string ProduceSound()
        {
            return "Meow";
        }
    }
}
