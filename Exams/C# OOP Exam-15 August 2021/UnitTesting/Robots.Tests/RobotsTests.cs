namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [TestCase(0, 0)]
        [TestCase(10, 10)]
        [TestCase(100, 100)]
        public void Constructor_ShouldInicializate_Capacity
            (int capacity, int expectedCapacity)
        {
            // Arrange
            // Act
            // Assert

            var robotManager = new RobotManager(capacity);

            Assert.AreEqual(expectedCapacity, robotManager.Capacity);
        }

        [TestCase(-3)]
        [TestCase(-78)]
        public void Constructor_ShouldThrowExceptionAfterInvalidCapacityInput
            (int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [TestCase(0)]
        public void Count_ShouldReturnZero
            (int expectedCount)
        {
            RobotManager rm = new RobotManager(10);

            Assert.AreEqual(expectedCount, rm.Count);
        }

        [TestCase(3)]
        public void Count_ShouldReturnProperValue(int expectedCount)
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(new Robot("r1", 10));
            rm.Add(new Robot("r2", 20));
            rm.Add(new Robot("r3", 30));

            Assert.AreEqual(expectedCount, rm.Count);
        }

        [Test]
        public void AddMethod_ShouldThrowExceptionAfterInvalidParameters()
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(new Robot("r1", 10));
            rm.Add(new Robot("r2", 20));
            rm.Add(new Robot("r3", 30));

            Assert.Throws<InvalidOperationException>(() 
                => rm.Add(new Robot("r1", 10)));
        }

        [TestCase(1)]
        public void RemoveMethod_ShouldRemoveProperlyRobotByGivenName
            (int expectedCount)
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(new Robot("r1", 10));
            rm.Add(new Robot("r2", 20));
            rm.Add(new Robot("r3", 30));

            rm.Remove("r1");
            rm.Remove("r3");

            Assert.AreEqual(expectedCount, rm.Count);
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionAfterGivenInvalidParameters()
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(new Robot("r1", 10));
            rm.Add(new Robot("r2", 20));
            rm.Add(new Robot("r3", 30));

            Assert.Throws<InvalidOperationException>(()
                => rm.Remove("r4"));
        }

        [TestCase(4, 6)]
        [TestCase(5, 5)]
        [TestCase(0, 10)]
        public void WorkMethod_ShouldDecreaseBatery
            (int bateryUsage, int expectedBateryAfterWorking)
        {
            RobotManager rm = new RobotManager(10);
            Robot robot = new Robot("r2", 10);
            rm.Add(robot);

            rm.Work("r2", "clean", bateryUsage);

            Assert.AreEqual(expectedBateryAfterWorking, robot.Battery);
        }

        [TestCase(25)]
        [TestCase(100)]
        public void WorkMethod_ShouldThrowExceptionAfterInvalidParameters
            (int bateryUsage)
        {
            RobotManager rm = new RobotManager(10);
            rm.Add(new Robot("r1", 10));
            rm.Add(new Robot("r2", 20));
            rm.Add(new Robot("r3", 30));

            Assert.Throws<InvalidOperationException>(()
                => rm.Work("r2", "clean", bateryUsage));
        }

        [TestCase(20)]
        [TestCase(100)]
        public void ChargeNethod_ShouldIncreaseBateryToMaximumOfTheGivenRobot
            (int batery)
        {
            RobotManager rm = new RobotManager(10);
            Robot robot = new Robot("r2", batery);
            rm.Add(robot);

            rm.Work("r2", "clean", 15);
            rm.Charge("r2");

            Assert.AreEqual(batery, robot.Battery);
        }
    }
}
