using System.Collections.Generic;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Geometry;

namespace OutlandSpace.Tests.Server.Engine.Session
{
    [TestFixture]
    public class GameSessionTests
    {
        IGameSession gameSession;

        [SetUp]
        public void SetUp()
        {
            IScenario scenario = new Scenario(GlobalData.MainScenarioId, GlobalData.TestsDataFolder);

            gameSession = new GameSession(scenario);

        }

        [Test]
        public void TurnExecutionShouldBeCorrectForBaseSession()
        {
            var result = gameSession.TurnExecute();

            Assert.AreEqual(1, result.Interaction.Dialogs.Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", result.Interaction.RootDialog.Id);
            Assert.AreEqual(2, result.GetCelestialObjects().Count);
            Assert.AreEqual(1, result.Turn);
            Assert.AreEqual(true, result.IsPause);

        }

        [Test]
        public void GameSessionBaseTest()
        {

            Assert.IsTrue(gameSession.Turn == 0);
            Assert.IsTrue(gameSession.IsDebug == false);
            Assert.IsTrue(gameSession.IsPause);

            Assert.AreEqual(gameSession.CelestialObjects.Count, 2);
        }

        [Test]
        public void InitializationShouldCreateCorrectTurnSnapshotCorrectForTestData()
        {
            var expectedCelestialObjects = 2;

            var snapshot = GlobalData.LocalServerWithTestData.Initialization(GlobalData.MainScenarioId);

            Assert.AreEqual(expectedCelestialObjects, snapshot.GetCelestialObjects().Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", snapshot.Interaction.RootDialog.Id);

            Assert.AreEqual(gameSession.CelestialObjects.Count, 2);
        }

        [Test]
        public void ConvertToTurnSnapshotShouldBeCorrect()
        {
            var celestialObjects = new List<ICelestialObject>
            {
                new Asteroid("100", 90.0, 10.0, new Point(100.0f, 100.0f), "Asteroid I"),
                new Asteroid("101", 90.0, 10.0, new Point(100.0f, 100.0f), "Asteroid II")
            };

            var dialogs = new List<IDialog>
            {
                new CommonDialog("200", 1, "window_close", new List<DialogExit>{new DialogExit("a2", "Exit 202", "202")}),
                new CommonDialog("202", 1, "window_close", new List<DialogExit>{new DialogExit("a3", "Exit 203", "203")}),
                new CommonDialog("203", 1, "window_close", new List<DialogExit>())
            };

            var session = new GameSession(new Scenario("MockScenarioId", new Resources(celestialObjects, dialogs, null)), 1);

            var result = session.ToGameTurnSnapshot();

            Assert.AreEqual(2, result.Interaction.Dialogs.Count);
            Assert.AreEqual(2, result.GetCelestialObjects().Count);
            Assert.AreEqual(1, result.Turn);
        }
    }
}
