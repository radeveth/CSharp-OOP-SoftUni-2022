namespace PlanetWars.Repositories
{
    using Contracts;
    using Models.Weapons.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private HashSet<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model)
            => this.models.Add(model);

        public IWeapon FindByName(string name)
            => this.models.FirstOrDefault(m => m.GetType().Name.ToLower() == name.ToLower());

        public bool RemoveItem(string name)
        {
            var model = this.FindByName(name);

            return this.models.Remove(model);
        }
    }
}
