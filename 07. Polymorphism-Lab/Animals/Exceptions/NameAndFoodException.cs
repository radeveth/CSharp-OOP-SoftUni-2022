using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Exceptions
{
    internal class NameAndFoodException : Exception
    {
        const string NAME_EXC = "Invalid name! Name cannot be null or white space!";

        public NameAndFoodException()
            : base(NAME_EXC)
        {
            Console.WriteLine(NAME_EXC);
        }
    }
}
