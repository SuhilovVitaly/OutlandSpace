using NUnit.Framework;
using OutlandSpace.Server.Engine.Execution;
using OutlandSpace.Server.Engine.Session;

namespace OutlandSpace.Tests.Server.Engine.Execution
{
    [TestFixture]
    public class TurnCalculateTests
    {
        [Test]
        public void AfterExecuteTurnNumberShouldBeTurnPlusOne()
        {
            var turnExecuteSnapshot = TurnCalculate.Execute(new GameSession());

            Assert.That(turnExecuteSnapshot.Turn == 1);
        }

        [Test]
        public void AfterExecuteTwoTurnsNumberShouldBeTurnPlusTwo()
        {
            var session = new GameSession();

            var firstTurnExecuteSnapshot = TurnCalculate.Execute(session);

            session.UpdateTurn(firstTurnExecuteSnapshot.GetCelestialObjects(), 1);

            Assert.That(firstTurnExecuteSnapshot.Turn == 1);
            Assert.That(session.Turn == 1);

            var secondTurnExecuteSnapshot = TurnCalculate.Execute(session);

            session.UpdateTurn(secondTurnExecuteSnapshot.GetCelestialObjects(), 1);

            Assert.That(secondTurnExecuteSnapshot.Turn == 2);
            Assert.That(session.Turn == 2);
        }

        [Test]
        public void AfterExecuteHundredTurnsNumberShouldBeTurnPlusHundred()
        {
            var session = new GameSession();

            for(int i = 0; i< 1000; i++)
            {
                var executeSnapshot = TurnCalculate.Execute(session);
                session.UpdateTurn(executeSnapshot.GetCelestialObjects(), 1);
            }

            Assert.That(session.Turn == 1000);
        }
    }
}
