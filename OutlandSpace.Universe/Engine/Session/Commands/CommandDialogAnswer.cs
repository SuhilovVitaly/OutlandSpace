using System;

namespace OutlandSpace.Universe.Engine.Session.Commands
{
    public class CommandDialogAnswer: Command
    {
        public string Id { get; }
        public string ExitId { get; }
        public string DialogId { get; }

        public CommandDialogAnswer(string dialogId, string exitId)
        {
            Id = Guid.NewGuid().ToString();
            DialogId = dialogId;
            ExitId = exitId;

            Type = CommandTypes.DialogAnswer;
        }
    }
}
