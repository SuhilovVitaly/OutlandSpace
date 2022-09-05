using System;
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
            Assert.Throws<NotImplementedException>(() => server.Initialization());
        }

        [Test]
        public void AfterCreateLocalServerDialogShouldBeCorrectCount()
        {
            Assert.AreEqual(GlobalData.DialogsCountInTests, (server as LocalServer).HealthSystemDialogsCount());
        }

        [Test]
        public void AfterCreateLocalServerDialogFromGameShouldBeCorrectCount()
        {
            IGameServer server = new LocalServer();

            var dialogs = (server as LocalServer).HealthSystemDialogsCount();

            Assert.AreEqual(GlobalData.DialogsCount, dialogs);
        }

        [Test]
        public void TurnSingleExecutionShouldBeCorrectCount()
        {
            IGameServer server = new LocalServer();
            var turnResults = server.TurnExecute();

            Assert.AreEqual(null, turnResults);
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
    }
}
