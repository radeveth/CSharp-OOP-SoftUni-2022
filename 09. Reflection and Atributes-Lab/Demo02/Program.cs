using System;
using System.Linq;
using System.Reflection;

namespace Demo02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(object).Assembly;
            Console.WriteLine("--------   " + assembly.GetTypes().Count() + "   --------");
            Console.WriteLine(new String('-', 80));

            foreach (var typeInfo in assembly.GetTypes())
            {
                Console.WriteLine($"{typeInfo.FullName} : {typeInfo.IsInterface}");
                Console.WriteLine(typeInfo.GetInterfaces());
                Console.WriteLine();
            }

            Assembly currExecution = Assembly.GetExecutingAssembly();
        }
    }
}
