namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int INITIAL_SIZE = 3;
        private const int INCREASE_SIZE = 3;

        private int size;

        public FreshwaterFish(string name, string species, decimal price) 
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
