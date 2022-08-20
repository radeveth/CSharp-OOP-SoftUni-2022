namespace Formula1.Models.Pilot
{
    using System;
    using Formula1.Utilities;
    using Formula1.Models.Contracts;
    using System.Text;

    public class Pilot : IPilot
    {
        private bool canRace;
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.CanRace = canRace;
        }

        public string FullName
        {
            get => this.fullName;
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new AggregateException(String.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get => this.numberOfWins;
            set => this.numberOfWins = value;
        }

        public bool CanRace
        {
            get => this.canRace;
            set => this.canRace = value;
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
            => $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
    }
}
