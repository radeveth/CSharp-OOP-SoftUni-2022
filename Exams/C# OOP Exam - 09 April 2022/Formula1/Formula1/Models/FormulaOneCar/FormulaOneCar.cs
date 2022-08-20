namespace Formula1.Models.FormulaOneCar
{
    using System;
    using Formula1.Utilities;
    using Formula1.Models.Contracts;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }

        public string Model
        {
            get => this.model;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidF1CarModel, value));
                }

                this.model = value;
            }
        }

        public int Horsepower
        {
            get => this.horsepower;
            set
            {
                if (value < 900 || value > 1050)
                {
                    throw new AggregateException(String.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }

                this.horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.engineDisplacement;
            set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new AggregateException(String.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }

                this.engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
            => this.EngineDisplacement / this.Horsepower * laps;
    }
}
