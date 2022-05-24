using Animals.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    internal class Animal
    {
        private string name;
        private string favouriteFood;
        public Animal(string name, string favoriteFood)
        {

        }

        public string Name 
        {
            get => this.name;
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NameAndFoodException();
                }
                this.name = value;
            }
        }

        public string FavouriteFood 
        {
            get => this.favouriteFood;
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new NameAndFoodException();
                }
                this.favouriteFood = value;
            }
        }
        public virtual string ExplainSelf()
        { 
            return $"Hi from base class {this.GetType().Name}!";
        }
    }
}
