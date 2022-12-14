using NUnit.Framework;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests.Server.Engine.Session
{
    [TestFixture]
    public class ScenarioTests
    {
        [Test]
        public void InitializationShouldLoadCelestialObjectsCorrectForTestData()
        {
            const int expectedCelestialObjects = 2;
            const int expectedGameDialogs = 5;
            const int expectedScenarioDialogs = 2;

            IScenario scenario = new Scenario(GlobalData.MainScenarioId, GlobalData.TestsDataFolder);

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedGameDialogs + expectedScenarioDialogs, scenario.Dialogs.Count);
        }

        [Test]
        public void InitializationShouldLoadCelestialObjectsCorrectForGameData()
        {
            const int expectedCelestialObjects = 2;
            const int expectedDialogs = 7;

            IScenario scenario = new Scenario(GlobalData.MainScenarioId);

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedDialogs, scenario.Dialogs.Count);
        }

        [Test]
        public void InitializationShouldLoadDialogsCorrectForGameData()
        {
            const int expectedCelestialObjects = 2;
            const int expectedScenarioDialogs = 2;
            const int expectedGeneralDialogs = 5;

            const string scenarioId = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

            IScenario scenario = new Scenario(scenarioId, GlobalData.TestsDataFolder);

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedScenarioDialogs + expectedGeneralDialogs, scenario.Dialogs.Count);
        }
    }
}
