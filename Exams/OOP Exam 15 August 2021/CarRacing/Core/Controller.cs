using System;
using System.Text;
using System.Linq;
using CarRacing.Models.Maps;
using CarRacing.Models.Cars;
using CarRacing.Repositories;
using CarRacing.Models.Racers;
using CarRacing.Core.Contracts;
using CarRacing.Utilities.Messages;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar newCar;
            if (type == "SuperCar")
            {
                newCar = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                newCar = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            
            this.cars.Add(newCar);

            return $"Successfully added car {newCar.Make} {newCar.Model} ({newCar.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar targetCar = this.cars.FindBy(carVIN);
            if (targetCar == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            IRacer newRacer;
            if (type == "ProfessionalRacer")
            {
                newRacer = new ProfessionalRacer(username, targetCar);
            }
            else if (type == "TunedCar")
            {
                newRacer = new StreetRacer(username, targetCar);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            this.racers.Add(newRacer);
            return $"Successfully added racer {username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.FindBy(racerOneUsername);
            if (racerOne == null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            IRacer racerTwo = this.racers.FindBy(racerTwoUsername);
            if (racerTwo == null)
            {
                throw new ArgumentException(
                    String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var racers = this.racers.Models
                .OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username);


            StringBuilder sb = new StringBuilder();
            foreach (IRacer racer in racers)
            {
                sb.Append(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
