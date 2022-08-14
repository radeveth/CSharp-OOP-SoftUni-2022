namespace PlanetWars.Repositories
{
    using Contracts;
    using System.Collections.Generic;
    using Models.MilitaryUnits.Contracts;
    using System.Linq;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private HashSet<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new HashSet<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

        public void AddItem(IMilitaryUnit model)
            => this.models.Add(model);

        public IMilitaryUnit FindByName(string name)
            => this.models.FirstOrDefault(m => m.GetType().Name.ToLower() == name.ToLower());

        public bool RemoveItem(string name)
        {
            var model = this.FindByName(name);

            return this.models.Remove(model);
        }
    }
}
