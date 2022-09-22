using NUnit.Framework;
using OutlandSpace.Server.Engine.Execution;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests.Server.Engine.Execution
{
    [TestFixture]
    public class TurnCalculateTests
    {
        [Test]
        public void AfterExecuteTwoTurnsNumberShouldBeTurnPlusTwo()
        {
            var session = GlobalData.GameSessionWithMainScenarioId;

            var firstTurnExecuteSnapshot = session.TurnExecute();

            Assert.That(firstTurnExecuteSnapshot.Turn == 1);
            Assert.That(session.Turn == 1);

            var secondTurnExecuteSnapshot = session.TurnExecute();

            Assert.That(secondTurnExecuteSnapshot.Turn == 2);
            Assert.That(session.Turn == 2);
        }

        [Test]
        public void AfterExecuteHundredTurnsNumberShouldBeTurnPlusHundred()
        {
            var session = GlobalData.GameSessionWithMainScenarioId;

            for (int i = 0; i< 1000; i++)
            {
                session.TurnExecute();
            }

            Assert.That(session.Turn == 1000);
        }
    }
}
