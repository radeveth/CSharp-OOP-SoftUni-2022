using Pizza_Calories.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories.Models
{
    internal class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type.ToLower();
            this.Weight = weight;
        }

        private string Type 
        { 
            get => this.type;
            set
            {
                if (!value.Equals("sauce") && 
                    !value.Equals("cheese") && 
                    !value.Equals("veggies") && 
                    !value.Equals("meat"))
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidTopping, value));
                }

                this.type = value;
            }
        }
        private double Weight 
        { 
            get => weight;
            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException
                        (String.Format(ExceptionMessages.InvalidToppingWeight));
                }

                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double typeModifire = GetTypeModifire();
            return this.Weight * typeModifire;
        }

        private double GetTypeModifire()
        {
            switch (this.Type)
            {
                case "sauce": return 0.9;
                    break;
                case "cheese": return 1.1;
                    break;
                case "veggies": return 0.8;
                    break;
                case "meat": return 1.3;
                    break;
                default: return 0;
                    break;
            }
        }
    }
}
