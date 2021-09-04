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
    public class GameTests
    {
        [TestMethod]
        public void TestGame()
        {
            Game game = new Game();
            Assert.AreSame(game.Animals, SetUpGame.AnimalPairs);
        }
        [TestMethod]
        public void TestCompareAnimals()
        {
            SetUpGame.Random = new MockRandomWithValueList(new List<int>() { 0, 1, 2, 3 });

            Game game = new Game();

            int index = 0;
            game.CompareAnimals(index);
            Assert.IsTrue(game.Animals[index].IsVisible);
            Assert.AreSame(game.Animals[index], game.AnimalClicked);

            index = 1;
            game.CompareAnimals(index);
            Assert.IsFalse(game.Animals[index].IsVisible);
            Assert.AreSame(null, game.AnimalClicked);
            Assert.IsFalse(game.Animals[0].IsVisible);

            index = 2;
            game.CompareAnimals(index);
            Assert.IsTrue(game.Animals[index].IsVisible);
            Assert.AreEqual(game.Animals[index], game.AnimalClicked);
            Assert.IsFalse(game.Animals[1].IsVisible);

            index = 5;
            game.CompareAnimals(index);
            Assert.IsTrue(game.Animals[index].IsVisible);
            Assert.AreEqual(null, game.AnimalClicked);
            Assert.IsTrue(game.Animals[2].IsVisible);
        }
        [TestMethod]
        public void TestGameIsOver()
        {
            Game game = new Game();
            SetUpGame.Random = new MockRandom();
            SetUpGame.CreateAnimalPairs(4);

            SetUpGame.Random = new MockRandomWithValueList(new List<int> { 0, 1, 2, 3 });
            SetUpGame.ShuffleAnimals();

            List<int> index = new List<int>() { 0, 4, 1, 8, 2, 5, 3, 12, 6, 9, 7, 14, 10, 13, 15, 11 };
            foreach(int i in index)
                game.CompareAnimals(i);

            Assert.IsTrue(game.IsGameOver());
            Assert.IsTrue(game.GameOver);
        }
        [TestMethod]
        public void TestNextLevel()
        {
            Game game = new Game();
            game.NextLevel();
            Assert.AreEqual(2, game.Level);
            Assert.AreEqual(5, game.RowNumber);
            Assert.AreEqual(25, game.Animals.Count);

            game.GameOver = true;
            game.NextLevel();
            Assert.AreEqual(3, game.Level);
            Assert.AreEqual(6, game.RowNumber);
            Assert.AreEqual(36, game.Animals.Count);
            Assert.IsFalse(game.GameOver);
        }
    }
}
