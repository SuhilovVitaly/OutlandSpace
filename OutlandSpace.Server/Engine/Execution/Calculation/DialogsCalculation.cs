using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session.Commands;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class DialogsCalculation
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static ITurnInteraction Execute(IDialogsStorage dialogsStorage, int turn, ImmutableArray<ICommand> commands)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultTurnDialog = GetCurrentDialogSystem(dialogsStorage, turn);

            if(resultTurnDialog is null)
            {
                resultTurnDialog = GetCurrentDialogSystemFromAnswerCommand(dialogsStorage, commands);
            }

            Logger.Debug($"Turn {turn}. [DialogsCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultTurnDialog;
        }

        private static ITurnInteraction GetCurrentDialogSystemFromAnswerCommand(IDialogsStorage dialogsStorage, ImmutableArray<ICommand> commands)
        {
            foreach (var command in commands)
            {
                if(command is CommandDialogAnswer)
                {
                    var dialogCommand = command as CommandDialogAnswer;

                    foreach (var dialog in dialogsStorage.Dialogs)
                    {
                        if (dialog.Id == dialogCommand.ExitId)
                        {
                            return new TurnInteraction(dialog, dialogsStorage.GetDialogChain(dialog.Id));
                        }
                    }
                }
            }

            return null;
        }

        private static ITurnInteraction GetCurrentDialogSystem(IDialogsStorage dialogsStorage, int turn)
        {

            foreach (var dialog in dialogsStorage.Dialogs)
            {
                if(dialog.Turn == turn)
                {
                    return new TurnInteraction(dialog, dialogsStorage.GetDialogChain(dialog.Id));
                }
            }

            return null;
        }
    }
}
