namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Linq;
    using System.Text;
    using Fish.Contracts;
    using Aquariums.Contracts;
    using Decorations.Contracts;
    using System.Collections.Generic;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.Decorations = new HashSet<Decoration>();
            this.Fish = new HashSet<IFish>();
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity cannot be equiel ot below than zero.");
                }

                this.capacity = value;
            }
        }

        public int Comfort 
            => this.Decorations.Select(d => d.Comfort).Sum();

        public ICollection<Decoration> Decorations { get; set; }

        public ICollection<IFish> Fish { get; set; }

        public void AddDecoration(Decoration decoration)
            => this.Decorations.Add(decoration);

        public void AddFish(IFish fish)
        {
            if (this.Fish.Count + 1 > this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public bool RemoveFish(IFish fish)
            => this.Fish.Remove(fish);

        // First way
        //public string GetInfo()
        //    => this.ToString();
        public string GetInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} - ({this.GetType().Name})");
            result.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f => f.Name))}");
            result.AppendLine($"Decorations: {this.Decorations.Count}");
            result.AppendLine($"Comfort: {this.Comfort}");

            return result.ToString().Trim();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} - {this.GetType().Name}");
            result.AppendLine($"Fish: {(this.Fish.Any() ? string.Join(", ", this.Fish.Select(f => f.Name)) : "none")}");
            result.AppendLine($"Decorations: {this.Decorations.Count}");
            result.AppendLine($"Comfort: {this.Comfort}");

            return result.ToString().Trim();
        }
    }
}
