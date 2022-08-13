namespace Heroes.Repositories
{
    using System.Linq;
    using Heroes.Models.Weapons;
    using System.Collections.Generic;
    using Heroes.Repositories.Contracts;
    using Heroes.Models.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private HashSet<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new HashSet<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void Add(IWeapon model)
            => this.models.Add(model);

        public IWeapon FindByName(string name)
            => this.models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IWeapon model)
            => this.models.Remove(model);
    }
}
