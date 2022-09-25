using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class DialogsCalculation
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static ITurnInteraction Execute(IDialogsStorage dialogsStorage, int turn)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultTurnDialog = GetCurrentDialogSystem(dialogsStorage, turn);

            Logger.Debug($"Turn {turn}. [DialogsCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultTurnDialog;
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
