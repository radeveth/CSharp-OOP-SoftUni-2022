using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping_Spree
{
    internal class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }


        public string Name 
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Name cannot be empty");
                }

                this .name = value;
            }
        }

        public double Money 
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> Products
        {
            get { return this.products; }
            private set { this.products = value; }
        }

        public string BuyingProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.Name} can't afford {product.Name}";
            }

            this.Money -= product.Cost;
            this.Products.Add(product);
            return $"{this.Name} bought {product.Name}";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Products.Count == 0)
            {
                sb.Append("Nothing bought");
            }
            else if (this.Products.Count != 0)
            {
                sb.Append(String.Join(", ", this.Products.Select(p => p.Name)));
            }

            return $"{this.Name} - {string.Join(", ", sb)}";

        }
    }
}
