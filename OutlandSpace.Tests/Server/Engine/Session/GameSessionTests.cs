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
    }
}
