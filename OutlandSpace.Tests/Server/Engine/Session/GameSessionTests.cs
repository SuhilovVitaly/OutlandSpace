using System.Collections.Generic;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Tests.Server.Engine.Session
{
    [TestFixture]
    public class GameSessionTests
    {
        IGameSession gameSession;
        IGameSession gameSessionWithCelestialObjects;

        [SetUp]
        public void SetUp()
        {
            gameSession = new GameSession();
            gameSessionWithCelestialObjects = new GameSession(new List<ICelestialObject>(), null);
        }

        [Test]
        public void GameSessionBaseTest()
        {

            Assert.IsTrue(gameSession.Turn == 0);
            Assert.IsTrue(gameSession.IsDebug == false);
            Assert.IsTrue(gameSession.IsPause == true);

            Assert.AreEqual(gameSessionWithCelestialObjects.CelestialObjects.Count, 0);
        }

        [Test]
        public void InitializationShouldCreateCorrectTurnSnapshotCorrectForTestData()
        {
            var expectedCelestialObjects = 2;

            var snapshot = GlobalData.LocalServerWithTestData.Initialization(GlobalData.MainScenarioId);

            Assert.AreEqual(expectedCelestialObjects, snapshot.GetCelestialObjects().Count);
            Assert.AreEqual("x90adc8a-eca5-4c84-b4a1-682098bb4829", snapshot.Dialogs.RootDialog.Id);

        }
    }
}
