namespace Design_Patterns
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Runtime.InteropServices;
    using System.Runtime.Intrinsics.X86;
    using System.Threading;
    using System.Xml.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            Animal cat = new Cat();
            Animal dog = new Dog();

            zoo.Add(cat);
            zoo.Add(dog);

            Console.WriteLine(String.Join(", ", zoo.Animals.Select(a => a.Name)));

            Zoo zoo2 = zoo.Clone;
            Console.WriteLine();
            Console.WriteLine(String.Join(", ", zoo2.Animals.Select(a => a.Name)));
            
            
            Console.WriteLine(Errorr.Errorr);
        }

        abstract class Animal
        {
            public Animal(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public virtual string ProduceSound { get; protected set; }

            public abstract string GetInfo();
        }

        class Cat : Animal
        {
            private string sound = "Mew mew";

            public Cat() : base("Pisana", 3)
            {
            }

            public override string ProduceSound 
            { 
                get => this.sound; 
                protected set => this.sound = value; 
            }

            public override string GetInfo()
            {
                return $"{this.GetType().Name} - {this.Age} - {this.Name}";
            }
        }

        class Dog : Animal
        {
            private string sound = "Baw baw";

            public Dog() : base("Sharo", 3)
            {
            }

            public override string ProduceSound 
            { 
                get => this.sound; 
                protected set => this.sound = value; 
            }

            public override string GetInfo()
            {
                return $"{this.GetType().Name} - {this.Age} - {this.Name}";
            }
        }

        class Zoo
        {
            public Zoo()
            {
                this.Animals = new List<Animal>();
            }

            public List<Animal> Animals { get; set; }

            public void Add(Animal animal) => this.Animals.Add(animal);

            public Zoo Clone => this.MemberwiseClone() as Zoo;
        }

        static class Errorr
        {
            public static string Errorr = "Error";
        }
    }
}
