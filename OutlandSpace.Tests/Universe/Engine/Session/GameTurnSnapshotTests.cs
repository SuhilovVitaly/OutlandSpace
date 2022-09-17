using System.Collections.Generic;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Tests.Universe.Engine.Session
{
    [TestFixture]
    public class GameTurnSnapshotTests
    {
        IGameTurnSnapshot gameTurnSnapshot;

        [SetUp]
        public void SetUp()
        {
            IScenario scenario = new Scenario(GlobalData.MainScenarioId, GlobalData.DialogsStorageWithTestData);

            var session = new GameSession(scenario);

            gameTurnSnapshot = new GameTurnSnapshot(session.Dialogs, session.CelestialObjects, session.Id, session.Turn + 1, session.IsPause, session.IsDebug);
        }

        [Test]
        public void GameTurnSnapshotShouldBeCorrect()
        {
            Assert.IsTrue(gameTurnSnapshot.Id == 0);
            Assert.IsTrue(gameTurnSnapshot.IsDebug == false);
            Assert.IsTrue(gameTurnSnapshot.IsPause == true);
        }
    }
}
