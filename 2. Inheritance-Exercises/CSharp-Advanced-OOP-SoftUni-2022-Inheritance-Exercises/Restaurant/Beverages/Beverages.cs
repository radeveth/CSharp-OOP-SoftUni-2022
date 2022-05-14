using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverages : Product
    {
        private double mililiters;
        public Beverages(string name, decimal price, double mililiters) 
            : base(name, price)
        {
            this.Mililiters = mililiters;
        }


        public double Mililiters 
        {
            get { return mililiters; }
            set { mililiters = value; }
        }

    }
}
