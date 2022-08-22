using NUnit.Framework;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests.Universe.Engine.Session
{
    [TestFixture]
    public class GameTurnSnapshotTests
    {
        IGameTurnSnapshot gameTurnSnapshot;

        [SetUp]
        public void SetUp()
        {
            gameTurnSnapshot = new GameTurnSnapshot();
        }

        [Test]
        public void GameTurnSnapshotBaseTest()
        {
            Assert.IsTrue(gameTurnSnapshot.Id == 0);
            Assert.IsTrue(gameTurnSnapshot.IsDebug == false);
            Assert.IsTrue(gameTurnSnapshot.IsPause == true);
        }
    }
}
