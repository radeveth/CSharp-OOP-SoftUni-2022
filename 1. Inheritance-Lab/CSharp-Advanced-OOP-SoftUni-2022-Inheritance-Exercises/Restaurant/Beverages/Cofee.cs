using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cofee : HotBeverage
    {
        private const double CofeeMililiters = 50;
        private const decimal CofeePrice = 3.5M;
        private double caffeine;

        public Cofee(string name, double caffeine) 
            : base(name, CofeePrice, CofeeMililiters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get { return caffeine; } set { caffeine = value; } }
    }
}
