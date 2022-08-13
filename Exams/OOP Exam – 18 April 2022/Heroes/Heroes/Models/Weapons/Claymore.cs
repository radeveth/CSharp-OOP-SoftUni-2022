namespace Heroes.Models.Weapons
{
    using System;

    public class Claymore : Weapon
    {
        private const int DAMAGE = 20;

        public Claymore(string name, int durability) 
            : base(name, durability, DAMAGE)
        {
        }

    }
}
