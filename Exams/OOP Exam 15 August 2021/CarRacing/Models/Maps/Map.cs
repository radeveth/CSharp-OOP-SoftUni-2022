using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            else if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return $"Race cannot be completed because both racers are not available!";
            }

            racerOne.Car.Drive();
            racerTwo.Car.Drive();

            double chancheForWinOfRacerOne = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            double chancheForWinOfRacerTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            if (racerOne.RacingBehavior == "strict")
            {
                chancheForWinOfRacerOne *= 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                chancheForWinOfRacerOne *= 1.1;
            }

            if (racerTwo.RacingBehavior == "strict")
            {
                chancheForWinOfRacerTwo *= 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                chancheForWinOfRacerTwo *= 1.1;
            }

            bool isRacerOneWin = chancheForWinOfRacerOne > chancheForWinOfRacerTwo;

            if (isRacerOneWin)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! " +
                    $"{racerOne.Username} is the winner!";
            }
            else if (!isRacerOneWin)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! " +
                    $"{racerTwo.Username} is the winner!";
            }

            return null;
        }
    }
}
