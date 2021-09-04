using AnimalMatchingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimalMachingGameTests
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void TestAnimal()
        {
            Assert.AreEqual("🐫", new Animal("🐫").AnimalEmoji);
            Assert.AreEqual("🐔", new Animal("🐔").AnimalEmoji);
            Assert.AreNotEqual("🐔", new Animal("🐕‍").AnimalEmoji);
            var animal = new Animal("🐕‍");
            Assert.AreEqual(false, animal.IsVisible);
        }
    }
}
