namespace Heroes.Models.Weapons
{
    using System;

    public class Mace : Weapon
    {
        private const int DAMAGE = 25;

        public Mace(string name, int durability)
            : base(name, durability, DAMAGE)
        {
        }
    }
}
