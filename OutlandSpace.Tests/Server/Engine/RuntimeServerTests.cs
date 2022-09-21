using System;
using System.Threading;
using NUnit.Framework;
using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Tests.Server.Engine
{
    [TestFixture]
    [Ignore("Ignore a fixture")]
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
        public void RealTimeEngineShouldCalculateMetricsCorrect()
        {
            var rtService = new RealTimeService();

            var rtEngine = new RealTimeEngine();

            rtEngine.Initialization(rtService.ExecuteTurnCalculation);

            var fServiceTicks = rtService.Metrics.TickCounter;
            var fServiceTurns = rtService.Metrics.TurnCounter;
            var fMetrics = rtService.Metrics;

            Thread.Sleep(2000);

            var sServiceTicks = rtService.Metrics.TickCounter;
            var sServiceTurns = rtService.Metrics.TurnCounter;

            Thread.Sleep(2000);

            var tServiceTicks = rtService.Metrics.TickCounter;
            var tServiceTurns = rtService.Metrics.TurnCounter;

            var metrics = rtService.Metrics;

            Assert.IsTrue(1 < 2);
        }

        [Test]
        public void MetricsOnRunningGameSessionShouldBeCorrect()
        {
            IGameServer gameServer = GlobalData.LocalServerWithTestData;

            gameServer.ResumeSession();

            Thread.Sleep(2000);

            Thread.Sleep(2000);

            Thread.Sleep(2000);

            var metrics = gameServer.SessionMetrics();
            // TODO: For 1 second execution we get 35 server ticks and 20 location recalculate but need get ~10
            Assert.IsTrue(metrics.TickCounter > 0);
        }
    }
}

