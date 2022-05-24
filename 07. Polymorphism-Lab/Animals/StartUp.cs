using System;

namespace Animals
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Shushi", "Whiskas");
            Animal dog = new Dog("Sharo", "Meat");


            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
