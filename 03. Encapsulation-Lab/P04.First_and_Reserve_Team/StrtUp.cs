using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.First_and_Reserve_Team
{
    public class StrtUp
    {
        static void Main(string[] args)
        {
            Team team = new Team("SoftUni");

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                var newPerson = GetPersonInfo();
                team.AddPerson(newPerson);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count()} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count()} players.");
        }

        private static Person GetPersonInfo()
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
