namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double PRICE = 1.5;
        public NuclearWeapon(int destructionLevel)
            : base(destructionLevel, PRICE)
        {
        }
    }
}
