namespace PlanetWars.Models.Planets
{
    using System;
    using Contracts;
    using Weapons.Contracts;
    using MilitaryUnits.Contracts;
    using System.Collections.Generic;
    using PlanetWars.Repositories.Contracts;
    using PlanetWars.Repositories;
    using System.Linq;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.Weapons;
    using System.Text;

    public class IPlanet : Contracts.IPlanet
    {
        private IRepository<IMilitaryUnit> units;
        private IRepository<IWeapon> weapons;

        private string name;
        private double budget;

        public IPlanet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;

            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Planet name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget's amount cannot be negative.");
                }

                this.budget = value;
            }
        }

        public double MilitaryPower
            => this.CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
            => this.units.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
            => this.weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder result = new StringBuilder();
            result
                .AppendLine($"Planet: {this.Name}")
                .AppendLine($"--Budget: {this.Budget} billion QUID")
                .AppendLine($"Forces: {(this.units.Models.Any() ? string.Join(", ", this.units.Models.Select(u => u.GetType().Name)) : "No units")}")
                .AppendLine($"--Combat equipment: {(this.weapons.Models.Any() ? string.Join(",", this.weapons.Models.Select(w => w.GetType().Name)) : "No weapons")}")
                .AppendLine($"--Military Power: {this.MilitaryPower}");

            return result.ToString().Trim();
        }

        public void Profit(double amount)
            => this.Budget += amount;

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException("Budget too low!");
            }

            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var militaryUnit in this.units.Models)
            {
                militaryUnit.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double sumOfUnitEndurances = this.units.Models.Select(units => units.EnduranceLevel).Sum();
            double sumOfWeaponDestructionLevels = this.weapons.Models.Select(w => w.DestructionLevel).Sum();

            double toatlAmount = sumOfUnitEndurances + sumOfWeaponDestructionLevels;

            if (this.units.Models.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                toatlAmount += toatlAmount * 0.3;
            }
            else if (this.units.Models.Any(u => u.GetType().Name == nameof(NuclearWeapon)))
            {
                toatlAmount += toatlAmount * 0.45;
            }

            return Math.Round(toatlAmount, 3);
        }
    }
}
