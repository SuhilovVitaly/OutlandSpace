using System;
using NUnit.Framework;
using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Tests.Server
{
    [TestFixture]
    public class BaseServerTests
    {
        [Test]
        public void LocalServerEngineBaseTest()
        {
            IGameServer server = new LocalServer("TestsData");

            Assert.Throws<NotImplementedException>(() => server.Initialization());
        }

        [Test]
        public void AfterCreateLocalServerDialogShouldBeCorrectCount()
        {
            IGameServer server = new LocalServer("TestsData");

            Assert.AreEqual(1, (server as LocalServer).HealthSystemDialogsCount());
        }
    }
}
