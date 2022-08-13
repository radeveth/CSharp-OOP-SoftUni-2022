namespace AquaShop.Repositories
{
    using Contracts;
    using Models.Decorations;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private HashSet<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new HashSet<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models;

        public void Add(IDecoration model)
            => this.models.Add(model);

        public IDecoration FindByType(string type)
            => this.models.FirstOrDefault(m => m.GetType().Name.ToLower() == type.ToLower());

        public bool Remove(IDecoration model)
            => this.models.Remove(model);
    }
}
