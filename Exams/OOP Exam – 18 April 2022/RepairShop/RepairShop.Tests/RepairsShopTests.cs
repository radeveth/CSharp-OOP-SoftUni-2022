using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [TestCase("GarageTest1", 1)]
            [TestCase("GarageTest2", 5)]
            [TestCase("GarageTest3", 100)]
            public void Garage_Constructor_Should_Initialize_Correctly_Properties(string name, int mechanicsAvailable)
            {
                Garage garage = new Garage(name, mechanicsAvailable);

                Assert.AreEqual(garage.Name, name);
                Assert.AreEqual(garage.MechanicsAvailable, mechanicsAvailable);
            }

            [TestCase(null, 5)]
            [TestCase("", 5)]
            public void Garage_Class_Should_Encapsulate_Name_Property_Correctly(string name, int mechanicsAvailable)
            {
                Assert.Throws<ArgumentNullException>(
                    () => new Garage(name, mechanicsAvailable), "Invalid garage name.");
            }

            [TestCase("GarageTest1", 0)]
            [TestCase("GarageTest2", -30)]
            public void Garage_Class_Should_Encapsulate_MechanicsAvailable_Property_Correctly(string name, int mechanicsAvailable)
            {
                Assert.Throws<ArgumentException>(
                    () => new Garage(name, mechanicsAvailable), "At least one mechanic must work in the garage.");
            }

            [TestCase("CarTestName", 1, 1)]
            [TestCase("CarTestName", 2, 2)]
            [TestCase("CarTestName", 3, 3)]
            public void Garage_AddCare_Method_Should_Work_Correctly_With_Given_Proper_Data
                (string carName, int numberOfIssues, int carsInGarage)
            {
                Garage garage = new Garage("TestGarage", 10);
                for (int i = 1; i <= carsInGarage; i++)
                {
                    garage.AddCar(new Car(carName, numberOfIssues));
                }


                Assert.AreEqual(garage.CarsInGarage, carsInGarage);
            }


            [TestCase(1, "CarTestName", 3, 1)]
            [TestCase(30, "CarTestName", 3, 30)]
            [TestCase(60, "CarTestName", 3, 60)]
            public void Garage_AddCare_Method_Should_Throw_Exception_If_Do_Not_Have_Available_Mechanic
                (int mechanicsAvailable, string carName, int numberOfIssues, int carsInGarage)
            {
                Garage garage = new Garage("TestGarage", mechanicsAvailable);
                for (int i = 1; i <= carsInGarage; i++)
                {
                    garage.AddCar(new Car(carName, numberOfIssues));
                }

                Assert.Throws<InvalidOperationException>(
                    () => garage.AddCar(new Car(carName, numberOfIssues)), "No mechanic available.");
            }

            [TestCase("TestModelCar", 0)]
            [TestCase("TestModelCar", 3)]
            [TestCase("TestModelCar", 30)]
            [TestCase("TestModelCar", 50)]
            public void Garage_FixCar_Method_Should_Remove_Issues_From_The_Given_Car_With_Proper_Given_Parameters
                (string carModel, int numberOfIssues)
            {
                Garage garage = new Garage("TestGarageName", 5);
                Car car = new Car(carModel, numberOfIssues);
                garage.AddCar(car);

                garage.FixCar(carModel);

                Assert.AreEqual(0, car.NumberOfIssues);
            }

            [TestCase("NonExistingCarModel")]
            public void Garage_FixCar_Method_Should_Throw_Exception_When_Non_Existing_Car_Model_Is_Given
                (string carModel)
            {
                Garage garage = new Garage("TestGarageName", 5);

                Assert.Throws<InvalidOperationException>(
                    () => garage.FixCar(carModel), $"The car {carModel} doesn't exist.");
            }

            [TestCase(20, 5)]
            [TestCase(20, 15)]
            [TestCase(20, 50)]
            public void Garage_RemoveFixedCar_Should_Remove_All_Cars_That_Not_Have_Issues
                (int numberOfCarsThatHaveIssues, int numberOfFixedCars)
            {
                Garage garage = new Garage("TestGarageName", numberOfCarsThatHaveIssues + numberOfFixedCars + 5);
                for (int i = 0; i < numberOfCarsThatHaveIssues; i++)
                {
                    garage.AddCar(new Car("TestCarModel", 5)); // Random issues
                }
                for (int i = 0; i < numberOfFixedCars; i++)
                {
                    garage.AddCar(new Car("TestCarModel", 0));
                }

                int result = garage.RemoveFixedCar();

                Assert.AreEqual(numberOfFixedCars, result);
            }

            [TestCase(20, 0)]
            public void Garage_RemoveFixedCar_Should_Throw_Exception_When_Do_Not_Have_Cars_To_Fixed
                (int numberOfCarsThatHaveIssues, int numberOfFixedCars)
            {
                Garage garage = new Garage("TestGarageName", numberOfCarsThatHaveIssues + numberOfFixedCars + 5);
                for (int i = 0; i < numberOfCarsThatHaveIssues; i++)
                {
                    garage.AddCar(new Car("TestCarModel", 5)); // Random issues
                }

                Assert.Throws<InvalidOperationException>(
                    () => garage.RemoveFixedCar(), "No fixed cars available.");
            }
        }
    }
}