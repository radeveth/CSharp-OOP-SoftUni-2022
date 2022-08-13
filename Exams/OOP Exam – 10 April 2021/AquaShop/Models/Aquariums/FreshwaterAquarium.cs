namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using Fish;
    using System.Collections.Generic;

    public class FreshwaterAquarium : Aquarium
    {
        private const int CAPACITY = 50;

        public FreshwaterAquarium(string name) 
            : base(name, CAPACITY)
        {
        }
    }
}
