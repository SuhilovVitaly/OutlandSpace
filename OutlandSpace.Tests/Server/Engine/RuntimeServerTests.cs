using System;
using System.Threading;
using NUnit.Framework;
using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Tests.Server.Engine
{
    [TestFixture]
    public class RuntimeServerTests
    {
        private IGameServer server;

        [SetUp]
        public void Init()
        {
            server = new LocalServer("TestsData");
            server.Initialization(GlobalData.MainScenarioId);
        }

        [Test]
        public void MetricsOnRunningGameSessionShouldBeCorrect()
        {
            IGameServer gameServer = GlobalData.LocalServerWithTestData;

            gameServer.ResumeSession();

            Thread.Sleep(1000);

            var metrics = gameServer.SessionMetrics();
            // TODO: For 1 second execution we get 35 server ticks and 20 location recalculate but need get ~10
            Assert.IsTrue(metrics.TickCounter > 0);
        }
    }
}

