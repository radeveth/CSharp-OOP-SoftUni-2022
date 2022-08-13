namespace Heroes.Core
{
    using System;
    using System.Linq;
    using Heroes.Models.Map;
    using Heroes.Repositories;
    using Heroes.Models.Heroes;
    using Heroes.Models.Weapons;
    using Heroes.Core.Contracts;
    using Heroes.Models.Contracts;
    using System.Collections.Generic;
    using Heroes.Repositories.Contracts;
    using System.Text;

    public class Controller : IController
    {
        private const string REPORTING_NAME_FOR_HERO_WITHOUT_WEAPON = "Unarmed";

        private IRepository<IHero> heros;
        private IRepository<IWeapon> weapons;

        public Controller()
        {
            this.heros = new HeroRepository();
            this.weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = this.heros.FindByName(heroName);
            IWeapon weapon = this.weapons.FindByName(weaponName);

            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            try
            {
                hero.AddWeapon(weapon);
                this.weapons.Remove(weapon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            IHero hero = this.heros.FindByName(name);

            if (hero != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            try
            {
                hero = type switch
                {
                    nameof(Barbarian) => new Barbarian(name, health, armour),
                    nameof(Knight) => new Knight(name, health, armour),
                    _ => throw new InvalidOperationException("Invalid hero type.")
                };

                this.heros.Add(hero);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return type == nameof(Barbarian) 
                ? $"Successfully added Barbarian {name} to the collection." 
                : $"Successfully added Sir {name} to the collection.";

        }

        public string CreateWeapon(string type, string name, int durability)
        {
            IWeapon weapon = this.weapons.FindByName(name);

            if (weapon != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            try
            {
                weapon = type switch
                {
                    nameof(Claymore) => new Claymore(name, durability),
                    nameof(Mace) => new Mace(name, durability),
                    _ => throw new InvalidOperationException("Invalid weapon type.")
                };

                this.weapons.Add(weapon);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return $"A {type} {name} is added to the collection.";

        }

        public string HeroReport()
        {
            StringBuilder result = new StringBuilder();

            foreach (var hero in this.heros.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name))
            {
                result.AppendLine(hero.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            ICollection<IHero> players = this.heros
                .Models
                .Where(h => IsHaveRquirments(h))
                .ToList();

            return map.Fight(players);
        }

        private bool IsHaveRquirments(IHero hero)
            => hero.Weapon != null && hero.IsAlive;
    }
}