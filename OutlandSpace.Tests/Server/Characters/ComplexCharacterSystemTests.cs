using NUnit.Framework;
using OutlandSpace.Server.Engine.Characters;

namespace OutlandSpace.Tests.Server.Characters
{
    [TestFixture]
    public class ComplexCharacterSystemTests
    {
        [Test]
        public void CharacterFactoryInitializeCountBaseCharactersShouldBeCorrect()
        {
            var charactersFactory = new CharactersFactory();

            var storage = charactersFactory.Initialize("TestsData");

            Assert.AreEqual(storage.Characters.Count, 2);
            Assert.AreEqual(storage.Characters[0].Id, "character-Vita-Sushilov-8fd7-af3cc0b1f914");
            Assert.AreEqual(storage.Metrics.LoadedFromBaseGame, 2);
            Assert.AreEqual(storage.Metrics.LoadedFromScenario, 0);
        }

        [Test]
        public void CharacterFactoryInitializeCountNotExistScenarioCharactersShouldBeCorrect()
        {
            var charactersFactory = new CharactersFactory();

            var storage = charactersFactory.Initialize("NotExist", "NotExist");

            Assert.AreEqual(storage.Characters.Count, 0);
            Assert.AreEqual(storage.Metrics.LoadedFromBaseGame, 0);
            Assert.AreEqual(storage.Metrics.LoadedFromScenario, 0);
        }

        [Test]
        public void CharacterFactoryInitializeCountNotExistGameFolderAndExistScenarioCharactersShouldBeCorrect()
        {
            var charactersFactory = new CharactersFactory();

            var storage = charactersFactory.Initialize("NotExist", GlobalData.MainScenarioId);

            Assert.AreEqual(storage.Characters.Count, 0);
            Assert.AreEqual(storage.Metrics.LoadedFromBaseGame, 0);
            Assert.AreEqual(storage.Metrics.LoadedFromScenario, 0);
        }

        [Test]
        public void CharacterFactoryInitializeCountAllCharactersShouldBeCorrect()
        {
            var charactersFactory = new CharactersFactory();

            var storage = charactersFactory.Initialize("TestsData", GlobalData.MainScenarioId);

            Assert.AreEqual(storage.Characters[0].Id, "character-Vita-Sushilov-8fd7-af3cc0b1f914");
            Assert.AreEqual(storage.Characters[1].Id, "character-Duncan-Sushilov-8fd7-af3cc0b1f914");
            Assert.AreEqual(storage.Characters[2].Id, "character-Dana-Sushilov-8fd7-af3cc0b1f914");
            Assert.AreEqual(storage.Characters.Count, 3);
            Assert.AreEqual(storage.Metrics.LoadedFromBaseGame, 2);
            Assert.AreEqual(storage.Metrics.LoadedFromScenario, 1);
        }
    }
}