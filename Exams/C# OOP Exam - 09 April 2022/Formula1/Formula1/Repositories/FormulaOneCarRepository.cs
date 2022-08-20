namespace Formula1.Repositories
{
    using System.Linq;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Repositories.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.models;

        public void Add(IFormulaOneCar model)
            => this.models.Add(model);

        public IFormulaOneCar FindByName(string name)
            => this.models.FirstOrDefault(m => m.Model == name);

        public bool Remove(IFormulaOneCar model)
            => this.models.Remove(model);
    }
}
