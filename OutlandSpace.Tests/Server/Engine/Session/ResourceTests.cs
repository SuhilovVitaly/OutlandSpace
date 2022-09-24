using NUnit.Framework;
using OutlandSpace.Server.Engine.Session;

namespace OutlandSpace.Tests.Server.Engine.Session
{
    [TestFixture]
    public class ResourceTests
    {
        [Test]
        public void ResourcesShouldBeLoadedCorrect()
        {
            var resources = new Resources(GlobalData.TestsDataFolder, GlobalData.MainScenarioId);

            Assert.AreEqual(7, resources.Dialogs.Count);
            Assert.AreEqual(2, resources.CelestialObjects.Count);
            Assert.AreEqual(3, resources.Characters.Count);
        }
    }
}