using System;
using NUnit.Framework;
using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Tests.Server
{
    public class BaseServerTests
    {
        [Test]
        public void LocalServerEngineBaseTest()
        {
            IGameServer server = new LocalServer();

            Assert.Throws<NotImplementedException>(() => server.Initialization());
        }
    }
}
