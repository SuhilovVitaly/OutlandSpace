using NUnit.Framework;
using OutlandSpace.Universe.Engine.Session.Commands;

namespace OutlandSpace.Tests.Universe.Engine.Session.Commands
{
    [TestFixture]
    public class BaseCommandsTests
    {
        private const string defaultDialogId = "dialogId";
        private const string defaultExitId = "exitId";

        [Test]
        public void DialogAnswearCommandShouldBeCorrect()
        {
            ICommand dialogAnswerCommand = new CommandDialogAnswer(defaultDialogId, defaultExitId);

            Assert.IsTrue(dialogAnswerCommand.Type == CommandTypes.DialogAnswer);
        }

        [Test]
        public void CastICommandToDialogAnswearCommandShouldBeCorrect()
        {
            ICommand iCommand = new CommandDialogAnswer(defaultDialogId, defaultExitId);

            var dialogAnswerCommand = iCommand as CommandDialogAnswer;

            Assert.NotNull(dialogAnswerCommand);
            Assert.IsTrue(dialogAnswerCommand.Type == CommandTypes.DialogAnswer);
            Assert.IsNotEmpty(dialogAnswerCommand.Id);
            Assert.IsTrue(dialogAnswerCommand.DialogId == defaultDialogId);
            Assert.IsTrue(dialogAnswerCommand.ExitId == defaultExitId);
        }
    }
}
