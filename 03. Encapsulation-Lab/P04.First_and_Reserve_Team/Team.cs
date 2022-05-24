using System;
using System.Collections.Generic;
using System.Text;

namespace P04.First_and_Reserve_Team
{
    public class Team
    {
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name { get { return this.name; } }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get { return this.firstTeam.AsReadOnly(); }
        }

        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }



        public void AddPerson(Person person)
        {
            if (person.Age < 40)
            { 
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
