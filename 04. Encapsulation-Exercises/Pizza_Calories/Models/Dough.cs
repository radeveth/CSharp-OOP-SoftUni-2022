using System;

namespace Pizza_Calories.Models
{
    internal class Dough
    {
        private string flour;
        private string type;
        private double weight;

        public Dough(string bakingType, string flour, double weight)
        {
            this.Type = bakingType.ToLower();
            this.Flour = flour.ToLower();
            this.Weight = weight;
        }

        private string Type
        {
            get => this.type;
            set
            {
                if (!value.Equals("white") && !value.Equals("wholegrain"))
                {
                    throw new ArgumentException
                        (String.Format(Exceptions.ExceptionMessages.InvalidTypeOfDough));
                }

                this.type = value;
            }
        }
        private string Flour
        {
            get => this.flour;
            set
            {
                if (!value.Equals("homemade") && !value.Equals("chewy") && !value.Equals("crispy"))
                {
                    throw new ArgumentException
                        (String.Format(Exceptions.ExceptionMessages.InvalidTypeOfFlour));
                }

                this.flour = value;
            }
        }
        private double Weight 
        {
            get => this.weight;
            set
            {
                if (value < 1|| value > 200)
                {
                    throw new ArgumentException
                        (String.Format(Exceptions.ExceptionMessages.InvalidWeightOfDough));
                }
            }
        }

        public double GetCalories()
        {
            double doughModifire = GetDoughModifire();
            double flourModifire = GetFlourModifire();

            return (2 * this.Weight) * doughModifire * flourModifire;
        }

        private double GetDoughModifire()
        {
            switch (this.Type)
            {
                case "wholegrain": return 1;
                    break;
                case "white": return 1.5;
                    break;
                default: return 0;
                    break;
            }
        }

        private double GetFlourModifire()
        {
            switch (this.Flour)
            {
                case "crispy": return 0.9;
                    break;
                case "chewy": return 1.1;
                    break;
                case "homemade": return 1;
                    break;
                default: return 0;
                    break;
            }
        }
    }
}
