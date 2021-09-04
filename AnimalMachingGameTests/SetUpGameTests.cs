using AnimalMatchingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMachingGameTests
{
    [TestClass]
    public class SetUpGameTests
    {
        [TestMethod]
        public void TestCreateAnimalPairs()
        {
            SetUpGame.Random = new MockRandom(); 
            SetUpGame.CreateAnimalPairs(4);
            
            Assert.AreEqual(16, SetUpGame.AnimalPairs.Count());
          
            Assert.AreEqual(false, SetUpGame.AnimalPairs[15].IsVisible);
            Assert.AreEqual(false, SetUpGame.AnimalPairs[0].IsVisible);

            Assert.AreEqual(SetUpGame.AnimalEmoji[0], SetUpGame.AnimalPairs[0].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[0], SetUpGame.AnimalPairs[1].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[1], SetUpGame.AnimalPairs[2].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[1], SetUpGame.AnimalPairs[3].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[2], SetUpGame.AnimalPairs[4].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[2], SetUpGame.AnimalPairs[5].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[3], SetUpGame.AnimalPairs[6].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[3], SetUpGame.AnimalPairs[7].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[4], SetUpGame.AnimalPairs[8].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[4], SetUpGame.AnimalPairs[9].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[5], SetUpGame.AnimalPairs[10].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[5], SetUpGame.AnimalPairs[11].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[6], SetUpGame.AnimalPairs[12].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[6], SetUpGame.AnimalPairs[13].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[7], SetUpGame.AnimalPairs[14].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[7], SetUpGame.AnimalPairs[15].AnimalEmoji);

            SetUpGame.Random = new MockRandomWithValueList(new List<int> { 0, 1, 2, 3 });
           
            SetUpGame.ShuffleAnimals();
            Assert.AreEqual(SetUpGame.AnimalEmoji[0], SetUpGame.AnimalPairs[0].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[1], SetUpGame.AnimalPairs[1].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[2], SetUpGame.AnimalPairs[2].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[3], SetUpGame.AnimalPairs[3].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[0], SetUpGame.AnimalPairs[4].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[2], SetUpGame.AnimalPairs[5].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[4], SetUpGame.AnimalPairs[6].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[5], SetUpGame.AnimalPairs[7].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[1], SetUpGame.AnimalPairs[8].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[4], SetUpGame.AnimalPairs[9].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[6], SetUpGame.AnimalPairs[10].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[7], SetUpGame.AnimalPairs[11].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[3], SetUpGame.AnimalPairs[12].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[6], SetUpGame.AnimalPairs[13].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[5], SetUpGame.AnimalPairs[14].AnimalEmoji);
            Assert.AreEqual(SetUpGame.AnimalEmoji[7], SetUpGame.AnimalPairs[15].AnimalEmoji);
        }
    }
}
