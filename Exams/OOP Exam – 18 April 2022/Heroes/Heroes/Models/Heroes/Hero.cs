namespace Heroes.Models.Heroes
{
    using System;
    using System.Text;
    using Contracts;

    public abstract class Hero : IHero
    {
        private const int UNACCEPTABLE_VALUE = 0;

        // Field may be readonly
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }


        public string Name 
        {
            get => this.name;
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }

                this.name = value;
            } 
        }

        public int Health
        {
            get => this.health;
            protected set
            {
                if (value < UNACCEPTABLE_VALUE)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }

                this.health = value;
            }
        }

        public int Armour
        {
            get => this.armour;
            protected set
            {
                if (value < UNACCEPTABLE_VALUE)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
            }
        }


        public IWeapon Weapon
        {
            get => this.weapon;
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                this.weapon = value;
            }
        }

        public bool IsAlive
            => this.Health > UNACCEPTABLE_VALUE;

        public void AddWeapon(IWeapon weapon)
            => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            int armourLeft = this.Armour - points;

            if (armourLeft > UNACCEPTABLE_VALUE)
            {
                this.Armour = armourLeft;
            }
            else
            {
                this.Armour = 0;

                int damage = -armourLeft;

                int healthLeft = this.Health - damage;

                if (healthLeft > UNACCEPTABLE_VALUE)
                {
                    this.Health = healthLeft;
                }
                else
                {
                    this.Health = 0;
                    // Hear is dead in that case
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                .AppendLine($"{this.GetType().Name} - {this.Name}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armour: {this.Armour}")
                .AppendLine($"--Weapon: {(this.Weapon == null ? "Unarmed" : this.Weapon.Name.ToLower())}");

            return result.ToString().TrimEnd();
        }
    }
}
