using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";

        private readonly List<Animals> animals;

        public Engine()
        {
            animals = new List<Animals>();
        }

        public void Run()
        {
            string command;
            while ((command = System.Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string[] tokens = System.Console.ReadLine()
                    .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Animals animal = GetAnimal(command, tokens);

                animals.Add(animal);
            }

            foreach (Animals animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animals GetAnimal(string command, string[] tokens)
        {
            Animals animal = null;

            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            string gender = null;
            if (tokens.Length >= 3)
            {
                gender = tokens[2];
            }

            if (command == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (command == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (command == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (command == "Kitten")
            {
                animal = new Kittens(name, age);
            }
            else if (command == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
