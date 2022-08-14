namespace PlanetWars.Core
{
    using System;
    using Contracts;
    using System.Linq;
    using Models.Planets;
    using PlanetWars.Repositories;
    using Repositories.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using System.Collections.Generic;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using System.Text;

    public class Controller : IController
    {
        private ICollection<string> availableMilitaryUnitsTypes;
        private ICollection<string> availableWeaponTypes;

        private IRepository<IPlanet> planets;

        public Controller()
        {
            this.planets = new PlanetRepository();

            this.availableMilitaryUnitsTypes = new List<string>()
            {
                "AnonymousImpactUnit",
                "SpaceForces",
                "StormTroopers"
            };

            this.availableWeaponTypes = new List<string>()
            {
                "BioChemicalWeapon",
                "NuclearWeapon",
                "SpaceMissiles"
            };
        }

        // TODO: Can to Optimizate the code
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!this.availableMilitaryUnitsTypes.Any(x => x.ToLower() == unitTypeName.ToLower()))
            {
                throw new InvalidOperationException($"{unitTypeName} still not available!");
            }

            if (planet.Army.Any(a => a.GetType().Name.ToLower() == unitTypeName.ToLower()))
            {
                throw new InvalidOperationException($"{unitTypeName} already added to the Army of {planetName}!");
            }

            IMilitaryUnit unit;

            unit = unitTypeName switch
            {
                nameof(AnonymousImpactUnit) => new AnonymousImpactUnit(),
                nameof(SpaceForces) => new SpaceForces(),
                nameof(StormTroopers) => new StormTroopers(),
                _ => throw new InvalidOperationException($"{unitTypeName} still not available!")
            };

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return $"{unitTypeName} added successfully to the Army of {planetName}!";
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (planet.Weapons.Any(w => w.GetType().Name.ToLower() == weaponTypeName))
            {
                throw new InvalidOperationException($"{weaponTypeName} already added to the Weapons of {planetName}!");
            }
            if (!this.availableWeaponTypes.Any(w => w.ToLower() == weaponTypeName.ToLower()))
            {
                throw new InvalidOperationException($"{weaponTypeName} still not available!");
            }

            IWeapon weapon;
            weapon = weaponTypeName switch
            {
                nameof(BioChemicalWeapon) => new BioChemicalWeapon(destructionLevel),
                nameof(NuclearWeapon) => new NuclearWeapon(destructionLevel),
                nameof(SpaceMissiles) => new SpaceMissiles(destructionLevel),
                _ => throw new InvalidOperationException($"{weaponTypeName} still not available!");
            };

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);

            return $"{planetName} purchased {weaponTypeName}!";
        }

        public string CreatePlanet(string name, double budget)
        {
            if (this.planets.FindByName(name) != null)
            {
                return $"Planet {name} is already added!";
            }

            // var planet = new IPlanet(name, budget);
            // this.planets.AddItem(planet);

            this.planets.AddItem(new IPlanet(name, budget));
            return $"Successfully added Planet: {name}";
        }

        public string ForcesReport()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in this.planets.Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name))
            {
                report.AppendLine(planet.PlanetInfo().Trim());
            }

            return report.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanetInWar = this.planets.FindByName(planetOne);
            var secondPlanetInWar = this.planets.FindByName(planetTwo);

            var militaryPowerOfFirstPlanet = firstPlanetInWar.MilitaryPower;
            var militaryPowerOfSecondPlanet = secondPlanetInWar.MilitaryPower;

            if (militaryPowerOfFirstPlanet > militaryPowerOfSecondPlanet)
            {
                return SpaceCombatResult(firstPlanetInWar, secondPlanetInWar);
            }
            else if (militaryPowerOfFirstPlanet < militaryPowerOfSecondPlanet)
            {
                return SpaceCombatResult(secondPlanetInWar, firstPlanetInWar);
            }
            else if (militaryPowerOfFirstPlanet == militaryPowerOfSecondPlanet)
            {
                if (firstPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()) &&
                   !secondPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()))
                {
                    return SpaceCombatResult(firstPlanetInWar, secondPlanetInWar);
                }
                else if (secondPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()) &&
                        !firstPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()))
                {
                    return SpaceCombatResult(secondPlanetInWar, firstPlanetInWar);
                }
                else if ((firstPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()) &&
                         secondPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()))
                                                                                                                    ||
                       (!firstPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower()) &&
                        !secondPlanetInWar.Weapons.Any(w => w.GetType().Name.ToLower() == "NuclearWeapon".ToLower())))
                {
                    firstPlanetInWar.Spend(firstPlanetInWar.Budget / 2);
                    secondPlanetInWar.Spend(secondPlanetInWar.Budget / 2);

                    return "The only winners from the war are the ones who supply the bullets and the bandages!";
                }
            }

            return "Have a bug!";
        }

        private string SpaceCombatResult(IPlanet winner, IPlanet loser)
        {
            loser.Spend(loser.Budget / 2);
            winner.Spend(winner.Budget / 2);
            winner.Budget += loser.Budget / 2;

            return $"{winner.Name} destructed {loser.Name}!";
        }

        public string SpecializeForces(string planetName)
        {
            var planet = this.planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException($"Planet {planetName} does not exist!");
            }
            if (!planet.Army.Any())
            {
                throw new InvalidOperationException("No units available for upgrade!");
            }

            double costsForIncreasingArmyEndurance = 1.25;
            planet.Spend(costsForIncreasingArmyEndurance);

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            return $"{planetName} has upgraded its forces!";
        }

        //private IMilitaryUnit CreateUnit(string unitType, IPlanet planet)
        //{
        //    if (unitType.ToLower() == "AnonymousImpactUnit".ToLower())
        //    {
        //        var unit = new AnonymousImpactUnit();
        //        planet.Spend(unit.Cost);

        //        return unit;
        //    }
        //    else if (unitType.ToLower() == "SpaceForces".ToLower())
        //    {
        //        var unit = new SpaceForces();
        //        planet.Spend(unit.Cost);

        //        return unit;
        //    }
        //    else if (unitType.ToLower() == "StormTroopers".ToLower())
        //    {
        //        var unit = new StormTroopers();
        //        planet.Spend(unit.Cost);

        //        return unit;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException($"{unitTypeName} still not available!");
        //    }
        //}

        //private IWeapon CreateWeapon(IPlanet planet, string weaponType, int destructionLevel)
        //{
        //    if (weaponType.ToLower() == "BioChemicalWeapon".ToLower())
        //    {
        //        var weapon = new BioChemicalWeapon(destructionLevel);
        //        planet.Spend(weapon.Price);
        //        return weapon;
        //    }
        //    else if (weaponType.ToLower() == "NuclearWeapon".ToLower())
        //    {
        //        var weapon = new NuclearWeapon(destructionLevel);
        //        planet.Spend(weapon.Price);
        //        return weapon;
        //    }
        //    else if (weaponType.ToLower() == "SpaceMissiles".ToLower())
        //    {
        //        var weapon = new SpaceMissiles(destructionLevel);
        //        planet.Spend(weapon.Price);
        //        return weapon;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
