using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList()
            { 
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"
            };

            list.GetRandomElement();
            Console.WriteLine(string.Join(", ", list));
            list.RemoveRandomElement();
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
