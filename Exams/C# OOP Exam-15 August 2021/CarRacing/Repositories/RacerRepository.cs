using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;

        public RacerRepository()
        {
            this.racers = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.racers;

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            this.racers.Add(racer);
        }

        public IRacer FindBy(string username)
        {
            return this.racers.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IRacer racer)
        {
            return this.racers.Remove(racer);
        }
    }
}
