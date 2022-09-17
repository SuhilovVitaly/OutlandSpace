using System;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Dialog;
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
            var expectedCelestialObjects = 2;
            var expectedDialogs = 2;
            //var guid = Guid.NewGuid().ToString();
            var scenarioId = "7045d54c-412b-429e-b1ed-43e62dcc10e6";


            IScenario scenario = new Scenario(scenarioId, "TestsData");

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedDialogs, scenario.Dialogs.Count);

        }

        [Test]
        public void InitializationShouldLoadCelestialObjectsCorrectForGameData()
        {
            var expectedCelestialObjects = 2;
            var expectedDialogs = 2;

            var scenarioId = "7045d54c-412b-429e-b1ed-43e62dcc10e6";


            IScenario scenario = new Scenario(scenarioId);

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedDialogs, scenario.Dialogs.Count);

        }

        [Test]
        public void InitializationShouldLoadDialogsCorrectForGameData()
        {
            var expectedCelestialObjects = 2;
            var expectedScenarioDialogs = 2;
            var expectedGeneralDialogs = 5;


            var scenarioId = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

            var dialogFactory = new DialogFactory();

            var storage = dialogFactory.Initialize("TestsData");

            IScenario scenario = new Scenario(scenarioId, storage);

            Assert.AreEqual(expectedCelestialObjects, scenario.CelestialObjects.Count);
            Assert.AreEqual(expectedScenarioDialogs + expectedGeneralDialogs, scenario.Dialogs.Count);

        }

        
    }
}
