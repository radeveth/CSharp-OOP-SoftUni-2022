namespace PlanetWars.Repositories
{
    using System;
    using Contracts;
    using Models.Planets;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private HashSet<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new HashSet<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.models;

        public void AddItem(IPlanet model)
            => this.models.Add(model);

        public IPlanet FindByName(string name)
            => this.models.FirstOrDefault(m => m.Name.ToLower() == name.ToLower());

        public bool RemoveItem(string name)
        {
            var model = this.FindByName(name);

            return this.models.Remove(model);
        }
    }
}
