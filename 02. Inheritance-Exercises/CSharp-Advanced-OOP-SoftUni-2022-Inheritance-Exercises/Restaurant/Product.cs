using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;


        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        

        public string Name 
        {
            get 
            {
                return name;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name cannot be null or whitespace.");
                }

                name = value;
            }
        }

        public decimal Price 
        {
            get 
            { 
                return price;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArithmeticException("The price cannot be zero or smaller than zero.");
                }
            }
        }
    }
}
