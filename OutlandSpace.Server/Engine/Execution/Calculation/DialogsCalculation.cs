using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class DialogsCalculation
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static ITurnDialogs Execute(IGameSession session, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultTurnDialog = GetCurrentDialogSystem(dialogsStorage, session.Turn + 1);

            _logger.Debug($"Turn {session.Turn}. [DialogsCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultTurnDialog;
        }

        public static ITurnDialogs Execute(DialogsStorage dialogsStorage, int turn)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultTurnDialog = GetCurrentDialogSystem(dialogsStorage, turn);

            _logger.Debug($"Turn {turn}. [DialogsCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultTurnDialog;
        }

        private static ITurnDialogs GetCurrentDialogSystem(DialogsStorage dialogsStorage, int turn)
        {

            foreach (var dialog in dialogsStorage.Dialogs)
            {
                if(dialog.Turn == turn)
                {
                    return new TurnDialogs(dialog, dialogsStorage.GetDialogChain(dialog.Id));
                }
            }

            return null;
        }
    }
}
