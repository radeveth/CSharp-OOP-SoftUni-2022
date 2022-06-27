namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Constructor_ShouldSetValueOfFuelAmount()
        {
            var car = new Car("Audi", "RS6", 10, 60);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("", "RS6", 10, 60)]
        [TestCase("Audi", "", 10, 60)]
        [TestCase("Audi", "RS6", 0, 60)]
        [TestCase("Audi", "RS6", 10, 0)]
        public void SetterOfProperties_ShouldThrow_ArgumentException_WhenOneOfParametersIsInvalid
            (string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>
                (() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [TestCase(3, 3)]
        [TestCase(35, 35)]
        [TestCase(60, 60)]
        public void Refuel_ShouldIncreaseFuelAmountByGivenFuel
            (double givenFuel, double expectFuelAmountAfterRefueling)
        {
            var car = new Car("Audi", "RS6", 10, 60);
            car.Refuel(givenFuel);
            Assert.AreEqual(expectFuelAmountAfterRefueling, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void 
            Refuel_ShouldThrow_ArgumentException_WhenGivenFuelIsInvalid(double givenFuel)
        {
            var car = new Car("Audi", "RS6", 10, 60);
            Assert.Throws<ArgumentException>(() => car.Refuel(givenFuel));
        }

        [TestCase(120)]
        [TestCase(60)]
        public void      Refuel_ShouldSetFuelAmountToBeEqualToFuelCapacity_WhenAfterRefuelOperationFuelAmountIsMoterThanFuelCapacity(double givenFuel)
        {
            var car = new Car("Audi", "RS6", 10, 60);
            car.Refuel(givenFuel);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [TestCase(60, 50, 55)]
        [TestCase(60, 100, 50)]
        [TestCase(50, 450, 5)]
        public void 
            Drive_ShouldDecreaseFuelAmountAfterDriveOperationWithValidParameters
            (double giveFuelToRefuel, double distanceToDrive, double expectedFuelAmount)
        {
            var car = new Car("Audi", "RS6", 10, 60);
            car.Refuel(giveFuelToRefuel);
            car.Drive(distanceToDrive);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [TestCase(1, 50)]
        [TestCase(5, 100)]
        [TestCase(44, 450)]
        public void Drive_ShouldThrow_InvalidOperationException_WhenAfterDriveOperation_NeededFuelIsMoreThanFuelAmount
            (double giveFuelToRefuel, double distanceToDrive)
        {
            var car = new Car("Audi", "RS6", 10, 60);
            car.Refuel(giveFuelToRefuel);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distanceToDrive));
        }
    }
}