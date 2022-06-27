using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Summator.Tests
{
    [TestFixture]
    public class SummatorTests
    {
        [Test]
        public void SumOfDigits_ShouldWorkCorrectlyWithADigit()
        {
            // Arrange
            var summator = new Sum();
            var givenNumber = 8;
            var expectedResult = 8;

            // Act
            var result = summator.SumOfDigits(givenNumber);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void SumOfDigits_ShouldWorkCorrectlyWithMilloins()
        {
            var summator = new Sum();
            Assert.AreEqual(7, summator.SumOfDigits(1111111));
        }

        [Test]
        public void SumOfDigits_ShouldWorkCorrectlyWithNegativeMillions()
        {
            var summator = new Sum();
            Assert.AreEqual(7, summator.SumOfDigits(-1111111));
        }

        [Test]
        public void SumOfDigits_ShouldWorkCorrectlyWithZero()
        {
            var summator = new Sum();
            Assert.AreEqual(0, summator.SumOfDigits(0));
        }
    }
}
