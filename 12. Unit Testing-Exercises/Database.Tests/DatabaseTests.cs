namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new int[] { 1, 2, 673, 1009, 0, 8876})]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue, 0})]
        [TestCase(new int[0])]
        public void Constructor_ShouldReturnValidData(int[] parameters)
        {
            var database = new Database(parameters);

            Assert.AreEqual(parameters.Length, database.Count);
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, 4)]
        [TestCase(new int[] { 10, 15}, new int[0], 2)]
        [TestCase(new int[0], new int[] { 10, 15 }, 2)]
        [TestCase(new int[0], new int[0], 0)]
        [TestCase(new int[0], new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 }, 16)]
        public void Add_ShouldAddNewElementToDataAndIncreaseCounter
            (int[] parametersForConstructor, int[] parametersToAdd, int expectedCount)
        {
            var database = new Database(parametersForConstructor);
            for (int i = 0; i < parametersToAdd.Length; i++)
            {
                database.Add(parametersToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}, 17)]
        public void Add_ShouldThrow_InvalidOperationException_WhenNumberOfElementsAreMoreThan16
            (int[] parametersForConstructor, int parameterToAdd)
        {
            var database = new Database(parametersForConstructor);

            Assert.Throws<InvalidOperationException>(() => database.Add(parameterToAdd));
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, 0)]
        [TestCase(new int[] { 10, 15 }, new int[] { }, 2)]
        // [TestCase(new int[] { }, new int[] { 10, 15 }, 2)]
        [TestCase(new int[] { }, new int[] { }, 0)]
        public void Remove_ShouldRemoveElementFromDataAndDecreaseCounter
            (int[] parametersForConstructor, int[] parametersToRemove, int expectedCount)
        {
            var database = new Database(parametersForConstructor);
            for (int i = 0; i < parametersToRemove.Length; i++)
            {
                database.Remove(parametersToRemove[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void Remove_ShouldThrow_InvalidOperationException_WhenTryToRemmoveElementsWithoutHaveElementsInData()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove(2));
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, new int[] { 1, 2, 10, 15})]
        [TestCase(new int[] { 10, 15 }, new int[0], new int[] { 10, 15 })]
        [TestCase(new int[0], new int[] { 10, 15 }, new int[] { 10, 15 })]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase
            (new int[0], 
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void 
            Fetch_ShouldReturnCoppyOfGivenDataArrayWhenAddOperation
            (int[] ctorParams, int[] addParams, int[] expectedArray)
        {
            var database = new Database(ctorParams);
            for (int i = 0; i < addParams.Length; i++)
            {
                database.Add(addParams[i]);
            }

            Assert.AreEqual(expectedArray, database.Fetch());
        }

        [TestCase(new int[] { 1, 2 }, new int[] { 10, 15 }, new int[0])]
        [TestCase(new int[] { 10, 15 }, new int[0], new int[] { 10, 15 })]
        [TestCase(new int[0], new int[0], new int[0])]
        [TestCase
            (new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 },
            new int[0],
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void
            Fetch_ShouldReturnCoppyOfGivenDataArrayWhenRemoveOperation
            (int[] ctorParams, int[] removeParams, int[] expectedArray)
        {
            var database = new Database(ctorParams);
            for (int i = 0; i < removeParams.Length; i++)
            {
                database.Remove(removeParams[i]);
            }

            Assert.AreEqual(expectedArray, database.Fetch());
        }
    }
}
