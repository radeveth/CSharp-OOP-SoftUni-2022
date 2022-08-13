namespace AquaShop.Models.Decorations
{
    public class Plant : IDecoration
    {
        private const int COMFORT_DEFAULT_VALUE = 5;
        private const decimal PRICE_DEFAULT_VALUE = 10;

        public Plant()
            : base(COMFORT_DEFAULT_VALUE, PRICE_DEFAULT_VALUE)
        {
        }
    }
}
