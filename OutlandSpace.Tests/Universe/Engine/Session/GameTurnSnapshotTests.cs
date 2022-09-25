using System;
using System.Collections.Immutable;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests.Universe.Engine.Session
{
    [TestFixture]
    public class GameTurnSnapshotTests
    {
        IGameTurnSnapshot _gameTurnSnapshot;

        [SetUp]
        public void SetUp()
        {
            IScenario scenario = new Scenario(GlobalData.MainScenarioId, "TestsData");

            var session = new GameSession(scenario);

            _gameTurnSnapshot = new GameTurnSnapshot(session.Interaction, session.CelestialObjects.ToImmutableList(), Guid.NewGuid().ToString(), session.Turn + 1, session.IsPause, session.IsDebug);
        }

        [Test]
        public void GameTurnSnapshotShouldBeCorrect()
        {
            Assert.IsTrue(_gameTurnSnapshot.Id != string.Empty);
            Assert.IsTrue(_gameTurnSnapshot.IsDebug == false);
            Assert.IsTrue(_gameTurnSnapshot.IsPause == true);
        }
    }
}
