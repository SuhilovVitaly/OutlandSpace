using NUnit.Framework;
using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Tests.Server.Characters
{
    [TestFixture]
    public class ComplexCharacterStorageTests
    {
        private ICharactersStorage _storage;

        [SetUp]
        public void Init()
        {
            _storage = new CharactersFactory().Initialize("TestsData");
        }

        [Test]
        public void LoadExistCharacterShouldBeCorrect()
        {
            var character = _storage.GetCharacter("character-Duncan-Sushilov-8fd7-af3cc0b1f914");

            Assert.AreEqual(Gender.Male, character.Gender);
            Assert.AreEqual("Glowworm", character.LocationCelestialObjectId);
        }
    }
}