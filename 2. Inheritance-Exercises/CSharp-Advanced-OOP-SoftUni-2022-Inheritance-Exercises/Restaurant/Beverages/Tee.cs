using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Tee : HotBeverage
    {
        public Tee(string name, decimal price, double mililiters) : base(name, price, mililiters)
        {
        }
    }
}
