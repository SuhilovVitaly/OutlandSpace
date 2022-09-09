using System;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class DialogsCalculation
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ITurnDialogs Execute(IGameSession session, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultTurnDialog = GetCurrentDialogSystem(session, dialogsStorage);

            _logger.Debug($"Turn {session.Turn}. [DialogsCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultTurnDialog;
        }

        private static ITurnDialogs GetCurrentDialogSystem(IGameSession session, DialogsStorage dialogsStorage)
        {
            var nextTurn = session.Turn + 1;

            foreach (var dialog in dialogsStorage.Dialogs)
            {
                if(dialog.Turn == nextTurn)
                {
                    return new TurnDialogs(dialog, dialogsStorage.GetDialogChain(dialog.Id));
                }
            }

            return null;
        }
    }
}
