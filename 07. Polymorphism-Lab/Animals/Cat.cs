using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            return $"Hi from child class aka {this.GetType().Name}. I am {this.Name} and my favourite food is {this.FavouriteFood}";
        }
    }
}
