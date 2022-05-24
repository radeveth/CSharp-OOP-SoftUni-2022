using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree.Core
{
    internal class Engine
    {
        private List<Person> people;
        private List<Product> products;

        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>(); 
        }

        public void Run()
        { 
            string[] peopleArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string person in peopleArgs)
            {
                string[] personArgs = person
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personArgs[0];
                double money = double.Parse(personArgs[1]);

                people.Add(new Person(name, money));
            }

            string[] productsArgs = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string product in productsArgs)
            {
                string[] productArgs = product
                    .Split("=", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = productArgs[0];
                double money = double.Parse(productArgs[1]);

                products.Add(new Product(name, money));
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            { 
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                Person targetPerson = people.FirstOrDefault(x => x.Name.Equals(personName));
                Product targetProduct = products.FirstOrDefault(x => x.Name.Equals(productName));

                if (targetProduct != null && targetPerson != null)
                {
                    targetPerson.BuyingProduct(targetProduct);
                }
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
