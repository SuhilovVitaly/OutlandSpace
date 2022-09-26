using System.Threading;
using NUnit.Framework;
using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Tests.Server
{
    [TestFixture]
    public class LocalServerTests
    {
        private IGameServer server;

        [SetUp]
        public void Init()
        {
            server = GlobalData.LocalServerWithTestData;
        }

        [Test]
        public void LocalServerEngineBaseTest()
        {
            var server = GlobalData.LocalServerWithTestData;

            var turnSnapshot = server.Initialization("7045d54c-412b-429e-b1ed-43e62dcc10e6");
            var celestialObjects = turnSnapshot.GetCelestialObjects();

            Assert.AreEqual(0, turnSnapshot.Turn);
            Assert.AreEqual(2, turnSnapshot.GetCelestialObjects().Count);
            Assert.AreEqual("c1d39cfc-7876-4cba-9a7a-b385ac0217b9", celestialObjects[0].Id);
            Assert.AreEqual("89dbc992-c09d-4acb-95e5-ab77c2969d27", celestialObjects[1].Id);
        }

        [Test]
        public void AfterCreateLocalServerDialogShouldBeCorrectCount()
        {
            var serverInternal = new LocalServer("TestsData");
            serverInternal.Initialization(GlobalData.MainScenarioId);

            Assert.AreEqual(GlobalData.DialogsCountInTests, (serverInternal as LocalServer).HealthSystemDialogsCount());
        }

        [Test]
        public void TurnSingleExecutionShouldBeCorrectCount()
        {
            IGameServer server = GlobalData.LocalServerWithTestData;
            var turnResults = server.TurnExecute();

            Assert.AreEqual(1, turnResults.Turn);
        }

        [Test]
        public void ResponseToIncorrectDialogShouldBeNull()
        {
            Assert.IsNull(server.DialogResponse("NotCorrectID"));
        }

        [Test]
        public void ResponseToCorrectDialogShouldBeDialog()
        {
            var resumeDialog = server.DialogResponse("a90adc8a-eca5-4c84-b4a1-682098bb4829");

            Assert.IsNotNull(resumeDialog);
        }

        [Test]
        public void ConnectionBetweenDialoguesShouldBeDialog()
        {
            var resumeDialog = server.DialogResponse("a90adc8a-eca5-4c84-b4a1-682098bb4829");

            var exitDialog = server.DialogResponse(resumeDialog.Exits[0].NextDialogId);

            Assert.AreEqual("0d35df2c-2018-4a90-8fd7-af3cc0b1f914", exitDialog.Id);
        }

        

        [Test]
        public void PausedGameSessionOnServerShouldBeComputeTicks()
        {
            IGameServer server = GlobalData.LocalServerWithTestData;

            server.Initialization(GlobalData.MainScenarioId);

            Thread.Sleep(1000);

            var serverTickFirstCheck = server.Metrics.TickCounter;

            Assert.IsTrue(serverTickFirstCheck > 0);

            Thread.Sleep(1000);

            var serverTickSecondCheck = server.Metrics.TickCounter;

            Assert.IsTrue(serverTickSecondCheck > serverTickFirstCheck);
        }


        [Test]
        public void ResumedGameSessionOnServerShouldBeComputeTicks()
        {
            var localServer = new LocalServer("TestsData");

            localServer.Initialization(GlobalData.MainScenarioId);

            Thread.Sleep(1000);

            localServer.ResumeSession();

            Thread.Sleep(5000);

            var sessionMetrics = localServer.SessionMetrics();

            Assert.IsTrue(sessionMetrics.TurnCounter == 5);
        }
    }
}
