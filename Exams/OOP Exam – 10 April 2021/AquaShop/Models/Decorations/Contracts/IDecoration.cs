namespace AquaShop.Models.Decorations.Contracts
{
    using System;

    public interface Decoration
    {
        int Comfort { get; }

        decimal Price { get; }
    }
}
