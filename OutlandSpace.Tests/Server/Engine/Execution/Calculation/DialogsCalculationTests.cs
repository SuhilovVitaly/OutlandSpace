using System.Collections.Concurrent;
using System.Collections.Immutable;
using NUnit.Framework;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Engine.Session.Commands;

namespace OutlandSpace.Tests.Server.Engine.Execution.Calculation
{
    [TestFixture]
    public class DialogsCalculationTests
    {
        IGameSession gameSession;

        [SetUp]
        public void SetUp()
        {
            gameSession = GlobalData.GameSessionWithMainScenarioId; 
        }

        [Test]
        public void BaseDialogsCalculationShouldBeCorrect()
        {
            var commands = new ConcurrentBag<ICommand>().ToImmutableArray();            

            var dialog = DialogsCalculation.Execute(gameSession.Storage, 12, commands);

            Assert.AreEqual(3, dialog.Dialogs.Count);
            Assert.AreEqual("a90adc8a-eca5-4c84-b4a1-682098bb4829", dialog.RootDialog.Id);
            Assert.AreEqual(2, dialog.RootDialog.Exits.Count);

            var dialog12 = DialogsCalculation.Execute(gameSession.Storage, 10, commands);

            Assert.IsNull(dialog12);
        }
    }
}
