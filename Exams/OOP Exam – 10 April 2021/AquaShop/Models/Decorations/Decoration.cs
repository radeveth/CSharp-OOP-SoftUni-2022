namespace AquaShop.Models.Decorations
{
    using Contracts;
    using System;

    public abstract class IDecoration : Contracts.Decoration
    {
        private int comfort;
        private decimal price;

        public IDecoration(int comfort, decimal price)
        {
            this.comfort = comfort;
            this.price = price;
        }

        public int Comfort
        {
            get => this.comfort;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Comfort cannot be below than 0");
                }

                this.comfort = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be below than 0");
                }

                this.price = value;
            }
        }
    }
}
