namespace Heroes.Models.Map
{
    using Heroes;
    using System;
    using Contracts;
    using System.Linq;
    using System.Collections.Generic;

    public class Map : IMap
    {
        private string WINNING_MESSAGE = 
            "The {0} took {1} casualties but won the battle.";


        public string Fight(ICollection<IHero> players)
        {
            var knights = new HashSet<Knight>();
            var barbarians = new HashSet<Hero>();

            int numberOfDeathKnights = 0;
            int numberOfDeathBarbarians = 0;

            foreach (var player in players)
            {
                if (player is Knight knight)
                {
                    knights.Add(knight);
                }
                else if (player is Barbarian barbarian)
                {
                    barbarians.Add(barbarian);
                }
                else
                {
                    throw new InvalidOperationException("Invalid hero type.");
                }
            }

            while (true)
            {
                bool allKnightsAreDead = true;
                bool allBarbariansAreDead = true;

                int alaiveKnights = 0;
                int alaiveBarbarians = 0;

                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        allKnightsAreDead = false;
                        alaiveKnights++;

                        foreach (var barbarian in barbarians)
                        {
                            barbarian.TakeDamage(knight.Weapon.DoDamage());
                        }
                    }
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        allBarbariansAreDead = false;
                        alaiveBarbarians++;

                        foreach (var knight in knights)
                        {
                            knight.TakeDamage(barbarian.Weapon.DoDamage());
                        }
                    }
                }

                if (allKnightsAreDead)
                {
                    return $"The barbarians took {barbarians.Count - alaiveBarbarians} casualties but won the battle.";
                }
                else if (allBarbariansAreDead)
                {
                    return $"The knights took {knights.Count - alaiveKnights} casualties but won the battle.";
                }
            }

            throw new InvalidOperationException("Bug in map fight logic");
        }
    }
}