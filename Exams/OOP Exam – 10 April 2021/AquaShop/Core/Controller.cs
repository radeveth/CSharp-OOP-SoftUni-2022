namespace AquaShop.Core
{
    using System;
    using Contracts;
    using Models.Fish;
    using System.Linq;
    using Repositories;
    using Models.Aquariums;
    using Models.Decorations;
    using Repositories.Contracts;
    using Models.Aquariums.Contracts;
    using System.Collections.Generic;

    using Decoration = Models.Decorations.Contracts.Decoration;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new HashSet<IAquarium>();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                nameof(FreshwaterAquarium) => new FreshwaterAquarium(aquariumName),
                nameof(SaltwaterAquarium) => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException("Invalid aquarium type.")
            };

            aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                nameof(Ornament) => new Ornament(),
                nameof(Plant) => new Plant(),
                _ => throw new InvalidOperationException("Invalid decoration type.")
            };

            decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = fishType switch
            {
                nameof(SaltwaterFish) => new SaltwaterFish(fishName, fishSpecies, price),
                nameof(FreshwaterFish) => new FreshwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException("Invalid fish type.")
            };

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            // !!!
            //if (aquarium == null)
            //{
            //    throw new InvalidOperationException($"There isn't a aquarium with given name ({aquariumName}).");
            //}

            if (!IsMatching(aquarium, fishType))
            {
                return "Water not suitable.";
            }
            else if (IsMatching(aquarium, fishType))
            {
                aquarium.AddFish(fish);
                return $"Successfully added {fishType} to {aquariumName}.";
            }

            return "There are a bug";
        }

        private bool IsMatching(IAquarium aquarium, string fishType)
        {
            int aquariumWordLength = ("aquarium".Length);
            string aquariumType = aquarium.GetType().Name;

            int fishWordLength = ("fish".Length);

            string waterInAquarium = aquariumType.Substring(0, aquariumType.Length - aquariumWordLength).ToLower();
            string fishWater = fishType.Substring(0, fishType.Length - fishWordLength).ToLower();

            return waterInAquarium == fishWater;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value =
                (aquarium.Fish.Select(f => f.Price).Sum()) +
                (aquarium.Decorations.Select(d => d.Price).Sum());

            // !!!
            //if (aquarium == null)
            //{
            //    throw new InvalidOperationException($"There isn't a aquarium with given name ({aquariumName}).");
            //}

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            // !!!
            //if (aquarium == null)
            //{
            //    throw new InvalidOperationException($"There isn't a aquarium with given name ({aquariumName}).");
            //}

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = this.decorations.FindByType(decorationType);

            // !!!
            //if (aquarium == null)
            //{
            //    throw new InvalidOperationException($"There isn't a aquarium with given name ({aquariumName}).");
            //}
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                result.AppendLine(aquarium.GetInfo().Trim());
            }

            return result.ToString().Trim();
        }
    }
}
