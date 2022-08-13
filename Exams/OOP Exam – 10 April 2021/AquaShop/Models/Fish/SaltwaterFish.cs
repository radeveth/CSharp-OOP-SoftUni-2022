namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;
        private const int INCREASE_SIZE = 2;

        private int size;

        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.size = INITIAL_SIZE;
        }

        public override int Size
            => size;

        public override void Eat()
            => this.size += INCREASE_SIZE;
    }
}
