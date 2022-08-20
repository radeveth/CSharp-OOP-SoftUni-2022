namespace Formula1.Models.Race
{
    using System;
    using Formula1.Utilities;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class Race : IRace
    {
        private bool tookPlace;
        private string raceName;
        private int numberOfLaps;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = false;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => this.raceName;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));
                }

                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }

                this.numberOfLaps = value;
            }
        }

        public bool TookPlace 
        { 
            get => this.tookPlace;
            set => this.tookPlace = value;
        }

        public ICollection<IPilot> Pilots
            => this.pilots;

        public void AddPilot(IPilot pilot)
            => this.Pilots.Add(pilot);

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"The {this.RaceName} race has:")
                .AppendLine($"Participants: {this.Pilots.Count}")
                .AppendLine($"Number of laps: {this.NumberOfLaps}")
                .AppendLine($"Took place: {(this.TookPlace == true ? "Yes" : "No")}");

            return sb.ToString().TrimEnd();
        }
    }
}
