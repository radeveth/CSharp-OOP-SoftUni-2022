namespace Formula1.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Formula1.Utilities;
    using Formula1.Models.Race;
    using Formula1.Repositories;
    using Formula1.Models.Pilot;
    using Formula1.Core.Contracts;
    using Formula1.Models.Contracts;
    using System.Collections.Generic;
    using Formula1.Models.FormulaOneCar;
    using System.Reflection;

    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.formulaOneCarRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IFormulaOneCar car = this.formulaOneCarRepository.FindByName(carModel);
            IPilot pilot = this.pilotRepository.FindByName(pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            pilot.AddCar(car);
            this.formulaOneCarRepository.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, car.Model);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = this.raceRepository.FindByName(raceName);
            IPilot pilot = this.pilotRepository.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (pilot == null || !pilot.CanRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);

            return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = this.formulaOneCarRepository.FindByName(type);

            if (car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, type));
            }

            car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type)),
            };

            this.formulaOneCarRepository.Add(car);

            return String.Format(String.Format(OutputMessages.SuccessfullyCreateCar, type, model));
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = this.pilotRepository.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilot = new Pilot(fullName);
            this.pilotRepository.Add(pilot);

            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            race = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race);

            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pilot in pilotRepository.Models.OrderBy(m => m.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var race in this.raceRepository.Models.Where(m => m.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> threeFastestPilots = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();

            race.TookPlace = true;
            threeFastestPilots[0].WinRace();

            StringBuilder result = new StringBuilder();
            result
                .AppendLine(String.Format(OutputMessages.PilotFirstPlace, threeFastestPilots[0].FullName, raceName))
                .AppendLine(String.Format(OutputMessages.PilotSecondPlace, threeFastestPilots[1].FullName, raceName))
                .AppendLine(String.Format(OutputMessages.PilotThirdPlace, threeFastestPilots[2].FullName, raceName));

            return result.ToString().TrimEnd();
        }
    }
}