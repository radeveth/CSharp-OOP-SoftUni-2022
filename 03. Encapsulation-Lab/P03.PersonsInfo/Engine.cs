using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.PersonsInfo
{
    public class Engine
    {
        private List<Person> people = new List<Person>();

        public Engine()
        {
            people = new List<Person>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var newPerson = GetPersonInfo(people);
                people.Add(newPerson);
            }

            decimal percentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(percentage));
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }


        private Person GetPersonInfo(List<Person> people)
        {
            string[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string name = tokens[0];
            string lastName = tokens[1];
            int age = int.Parse(tokens[2]);
            decimal salary = decimal.Parse(tokens[3]);

            return new Person(name, lastName, age, salary);
        }
    }
}
