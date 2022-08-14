using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [TestCase("TestPlanetName", 5)]
            [TestCase("TestPlanetName", 50)]
            [TestCase("TestPlanetName", 102.6)]
            [TestCase("TestPlanetName", 4262.6)]
            public void Planet_Constructor_Should_Initialize_Correctly_Properties(string name, double budget)
            {
                Planet planet = new Planet(name, budget);

                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(budget, planet.Budget);
            }

            [TestCase(null, 10)]
            [TestCase("", 10)]
            public void Planet_Encapsulation_Should_Work_Correctly_On_Name_Property(string name, double budget)
            {
                Assert.Throws<ArgumentException>(
                    () => new Planet(name, budget), "Invalid planet Name");

            }

            [TestCase("TestPlanetName", -70.6)]
            [TestCase("TestPlanetName", -3833.5)]
            public void Planet_Encapsulation_Should_Work_Correctly_On_Budget_Property(string name, double budget)
            {
                Assert.Throws<ArgumentException>(
                    () => new Planet(name, budget), "Budget cannot drop below Zero!");
            }

            [TestCase("TestWeaponName", 50, 5, 5)]
            [TestCase("TestWeaponName", 10, 10, 10)]
            public void Planet_AddWeapon_Method_Should_Work_Correctly
                (string name, double price, int destructionLevel, int numberOfWeapons)
            {
                Planet planet = new Planet("TestPlanetName", 100);
                var weapons = new List<Weapon>();
                for (int i = 1; i <= numberOfWeapons; i++)
                {
                    var weapon = new Weapon($"{name}{i}", price, destructionLevel);
                    
                    weapons.Add(weapon);
                    planet.AddWeapon(weapon);
                }


                Assert.AreEqual(planet.Weapons, weapons);
                Assert.AreEqual(planet.Weapons.Count, weapons.Count);
                Assert.AreEqual(planet.MilitaryPowerRatio, weapons.Sum(d => d.DestructionLevel));
            }

            [TestCase("TestWeaponName", 50, 5)]
            [TestCase("TestWeaponName", 10, 10)]
            public void Planet_AddWeapon_Method_Should_Throw_Exception
                (string name, double price, int destructionLevel)
            {
                Planet planet = new Planet("TestPlanetName", 100);
                Weapon weapon = new Weapon(name, price, destructionLevel);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(
                    () => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");
            }


            [TestCase(10, 10.5)]
            [TestCase(10, 1832.5)]
            public void Planet_Profit_Method_Should_Work_Corrctly(double initialBudget, double amountOfProfit)
            {
                Planet planet = new Planet("PlanetTestName", initialBudget);

                double bidgetAfterOperation = initialBudget + amountOfProfit;
                planet.Profit(amountOfProfit);

                Assert.AreEqual(bidgetAfterOperation, planet.Budget);
            }


            [TestCase("TestWeaponName", 50, 5)]
            [TestCase("TestWeaponName", 10, 10)]
            public void Planet_RemoveWeapon_Method_Should_Work_Correctly
                (string name, double price, int destructionLevel)
            {
                Planet planet = new Planet("TestPlanetName", 100);
                Weapon weapon = new Weapon(name, price, destructionLevel);

                var weapons = new List<Weapon>();

                planet.AddWeapon(weapon);
                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(weapons, planet.Weapons);
                Assert.AreEqual(weapons.Sum(d => d.DestructionLevel), planet.MilitaryPowerRatio);
            }

            [TestCase("TestWeaponName", 50, 5, 6)]
            [TestCase("TestWeaponName", 10, 10, 11)]
            public void Plant_UpgradeWeapon_Should_Work_Correctly
                (string name, double price, int destructionLevel, int destructionLevelAfterOperation)
            {
                Planet planet = new Planet("TestPlanetName", 100);
                Weapon weapon = new Weapon(name, price, destructionLevel);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);

                Assert.AreEqual(destructionLevelAfterOperation, weapon.DestructionLevel);
            }

            [TestCase("TestWeaponName", 50, 5, 3)]
            [TestCase("TestWeaponName", 10, 10, 4)]
            public void Plant_UpgradeWeapon_Should_Throw_Exception
                (string name, double price, int destructionLevel, int destructionLevelForOperation)
            {
                Planet planet = new Planet("TestPlanetName", 100);
                Weapon weapon = new Weapon(name, price, destructionLevel);

                Assert.Throws<InvalidOperationException>(
                    () => planet.UpgradeWeapon(weapon.Name), 
                    $"{weapon.Name} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void Planet_DestructOpponent_Should_Work_Correctly()
            {
                Weapon weapon1 = new Weapon("TestWeaponName1", 50, 5);
                Weapon weapon2 = new Weapon("TestWeaponName2", 50, 3);

                Planet planet1 = new Planet("TestPlanetName1", 100);
                Planet planet2 = new Planet("TestPlanetName2", 100);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                string resultMessage = $"{planet2.Name} is destructed!";

                string actualMessage = planet1.DestructOpponent(planet2);

                Assert.AreEqual(resultMessage, actualMessage);
            }

            [Test]
            public void Planet_DestructOpponent_Should_Throw_Message()
            {
                Weapon weapon1 = new Weapon("TestWeaponName1", 50, 5);
                Weapon weapon2 = new Weapon("TestWeaponName2", 50, 3);

                Planet planet1 = new Planet("TestPlanetName1", 100);
                Planet planet2 = new Planet("TestPlanetName2", 100);

                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);

                Assert.Throws<InvalidOperationException>(
                    () => planet2.DestructOpponent(planet1));
            }
        }
    }
}
