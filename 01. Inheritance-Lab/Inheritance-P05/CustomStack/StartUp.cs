using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var myStack = new StackOfStrings();

            Console.WriteLine(myStack.IsEmpty());

            for (int i = 0; i < 6; i++)
            {
                myStack.Push(i.ToString());
            }

            Console.WriteLine(myStack.IsEmpty());
            Console.WriteLine(String.Join(", ", myStack));

            var list = new List<string>()
            { 
                "1", "2", "3", "4", "5", "6"
            };

            myStack.AddRange(list);

            Console.WriteLine(String.Join(", ", myStack));
        }
    }
}
