namespace AquaShop.Models.Decorations
{

    public class Ornament : IDecoration
    {
        private const int COMFORT_DEFAULT_VALUE = 1;
        private const decimal PRICE_DEFAULT_VALUE = 5;

        public Ornament() 
            : base(COMFORT_DEFAULT_VALUE, PRICE_DEFAULT_VALUE)
        {
        }
    }
}
