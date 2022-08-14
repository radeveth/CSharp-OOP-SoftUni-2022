namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using Contracts;

    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private const int INITIAL_ENDURANCE_LEVEL = 1;

        private double cost;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = INITIAL_ENDURANCE_LEVEL;
        }
        public double Cost 
        { 
            get => this.cost;
            set => this.cost = value;
        }

        public int EnduranceLevel { get; set; }

        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel + 1 > 20)
            {
                throw new ArgumentException("Endurance level cannot exceed 20 power points.");
            }

            this.EnduranceLevel++;
        }
    }
}
