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

            var characterSecond = _storage.GetCharacter("character-Vita-Sushilov-8fd7-af3cc0b1f914");

            Assert.AreEqual(Gender.Female, characterSecond.Gender);
            Assert.AreEqual("Glowworm", characterSecond.LocationCelestialObjectId);
            Assert.AreEqual("Vita-Sushilov", characterSecond.Portrait);
        }

        [Test]
        public void GenerateNewCharacterShouldBeCorrect()
        {
            var character = _storage.GenerateRandomCrewMember("CelestialObjectId");

            Assert.IsNotEmpty(character.FirstName);
            Assert.IsNotEmpty(character.LastName);
            Assert.IsNotEmpty(character.Id);
            Assert.AreEqual("CelestialObjectId", character.LocationCelestialObjectId);
        }
    }
}