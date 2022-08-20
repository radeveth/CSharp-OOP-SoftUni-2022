namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.models;

        public void Add(IPilot model)
            => this.models.Add(model);

        public IPilot FindByName(string name)
            => this.models.FirstOrDefault(m => m.FullName == name);

        public bool Remove(IPilot model)
            => this.models.Remove(model);
    }
}
