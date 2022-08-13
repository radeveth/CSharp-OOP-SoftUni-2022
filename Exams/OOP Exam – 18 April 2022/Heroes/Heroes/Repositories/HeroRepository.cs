namespace Heroes.Repositories
{
    using Contracts;
    using System.Linq;
    using Heroes.Models.Heroes;
    using Heroes.Models.Contracts;
    using System.Collections.Generic;

    public class HeroRepository : IRepository<IHero>
    {
        private HashSet<IHero> models;

        public HeroRepository()
        {
            this.models = new HashSet<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.models;

        public void Add(IHero model) 
            => this.models.Add(model);

        public IHero FindByName(string name)
            => this.models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IHero model)
            => this.models.Remove(model);
    }
}
