using System;

namespace Demo03.Models
{
    public class Animal : IAnimal
    {
        private string name;
        private int age;
        private string sound;
        private int energy;

        public Animal()
        {

        }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public Animal(string name, int age, string sound, int energy)
            : this(name, age)
        {
            this.Sound = sound;
            this.Energy = energy;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public int Age 
        { 
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                this.age = value;
            }
        }
        public string Sound
        {
            get => this.sound;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.sound = value;
            }
        }
        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }
                this.energy = value;
            }
        }

        public string Eat(string food)
        {
            this.Energy++;
            return $"{this.GetType().Name} with name {this.Name} eat {food}.";
        }

        public bool IsHaveEnergy()
        {
            return this.Energy > 5;
        }

        public string ProduceSoud()
        {
            return $"{this.GetType().Name} with name {this.Name} say {this.Sound}.";
        }
    }
}
