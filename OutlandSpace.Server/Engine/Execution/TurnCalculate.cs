using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static GameSession Execute(IGameSession session, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();

            var turnDialogs = DialogsCalculation.Execute(session, dialogsStorage);
            var objects = RecalculateCelestialObjectsLocations.Execute(session);
            var turn = TurnPropertiesCalculation.Execute(session);

            var sessionRebuild = new GameSession(objects, turnDialogs, turn);

            Logger.Debug($"Turn {sessionRebuild.Turn}. Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return sessionRebuild;
        }

        public static ITurnDialogs GetCurrentTurnDialogs(int turn, DialogsStorage storage)
        {
            return DialogsCalculation.Execute(storage, turn);
        }

        public static List<ICelestialObject> RecalculateLocations(int turn, List<ICelestialObject> objects)
        {
            return RecalculateCelestialObjectsLocations.Execute(objects, turn);
        }
    }
}
