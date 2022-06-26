using System;
using System.Linq;
using Demo03.Models;
using System.Reflection;

namespace Demo03
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter type of animal: ");
            var typeOfAnimal = Console.ReadLine();

            Console.Write("Enater name: ");
            var name = Console.ReadLine();
            
            Console.Write("Enater age: ");
            var age = Console.ReadLine();

            Console.Write("Enater spund: ");
            var sound = Console.ReadLine();
            
            Console.Write("Enater energy: ");
            var enery = Console.ReadLine();

            var baseNamespace = "Demo03.Models";
            var type = Type.GetType($"{baseNamespace}.{typeOfAnimal}");


            var animal = Activator.CreateInstance
                (type, name, int.Parse(age), sound, int.Parse(enery)) as Animal;

            var type2 = typeof(Animal);

            Console.WriteLine(animal.GetType().Name);
            var fields = type2.GetFields
                (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            var methods = type2.GetMethods((BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static));
            foreach (var field in fields)
            {
                Console.WriteLine(field);
            }
            Console.WriteLine(new String('-', 80));
            foreach (var method in methods)
            {
                Console.WriteLine(method);
                foreach (var methodInfo in method.GetParameters())
                {
                    Console.WriteLine(methodInfo);
                }
            }
        }
    }
}
