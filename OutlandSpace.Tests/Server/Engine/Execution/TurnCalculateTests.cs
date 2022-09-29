using NUnit.Framework;
using OutlandSpace.Server;


namespace OutlandSpace.Tests.Server.Engine.Execution
{
    [TestFixture]
    public class TurnCalculateTests
    {
        [Test]
        public void AfterExecuteTwoTurnsNumberShouldBeTurnPlusTwo()
        {
            var localServer = new LocalServer("TestsData");

            localServer.Initialization(GlobalData.MainScenarioId);

            localServer.TurnExecute();

            var firstTurnExecuteSnapshot = localServer.GetSnapshot();

            Assert.That(firstTurnExecuteSnapshot.Turn == 1);

            localServer.TurnExecute();

            var secondTurnExecuteSnapshot = localServer.GetSnapshot();

            Assert.That(secondTurnExecuteSnapshot.Turn == 2);
        }

        [Test]
        public void AfterExecuteHundredTurnsNumberShouldBeTurnPlusHundred()
        {
            var localServer = new LocalServer("TestsData");

            localServer.Initialization(GlobalData.MainScenarioId);


            for (int i = 0; i< 1000; i++)
            {
                localServer.TurnExecute();
            }

            var snapshot = localServer.GetSnapshot();

            Assert.That(snapshot.Turn == 1000);
        }
    }
}
