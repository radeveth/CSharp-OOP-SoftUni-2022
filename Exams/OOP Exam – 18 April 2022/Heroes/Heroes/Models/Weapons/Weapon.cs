namespace Heroes.Models.Weapons
{
    using System;
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private const int UNACCEPTABLE_VALUE = 0;


        // Fields may be readonly
        private string name;
        private int durability;
        private int damage;

        protected Weapon(string name, int durability, int damage)
        {
            this.Name = name;
            this.Durability = durability;
            this.Damage = damage;
        }

        public string Name 
        {
            get => this.name; 
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Durability 
        {
            get => this.durability; 
            protected set
            {
                if (value < UNACCEPTABLE_VALUE)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }

                this.durability = value;
            }
        }

        public int Damage 
        {
            get => this.damage;
            protected set
            {
                if (value < UNACCEPTABLE_VALUE)
                {
                    throw new ArgumentException("Damage cannot be below 0.");
                }

                this.damage = value;
            }
        }
        public int DoDamage()
        {
            if (this.Durability == 0)
            {
                return 0;
            }

            this.Durability--;

            return this.Durability;
        }
    }
}
