using System;

namespace MathOperation
{
    internal class StratUp
    {
        static void Main(string[] args)
        {
            var mathOperation = new MathOperation();
            Console.WriteLine(mathOperation.Add(2, 3));
            Console.WriteLine(mathOperation.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperation.Add(2.2m, 3.3m, 4.4m));
        }
    }
}
