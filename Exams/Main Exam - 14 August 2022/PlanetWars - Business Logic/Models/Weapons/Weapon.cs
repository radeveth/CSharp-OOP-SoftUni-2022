namespace PlanetWars.Models.Weapons
{
    using Contracts;
    using System;

    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;

        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get; set; }

        public int DestructionLevel
        {
            get => this.destructionLevel;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Destruction level cannot be zero or negative.");
                }
                else if (value > 10)
                {
                    throw new AggregateException("Destruction level cannot exceed 10 power points.");
                }

                this.destructionLevel = value;
            }
        }
    }
}
