using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static IGameTurnSnapshot Execute(IGameSession session, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();

            var turnDialogs = DialogsCalculation.Execute(session, dialogsStorage);
            var objects = RecalculateCelestialObjectsLocations.Execute(session);
            var turn = TurnPropertiesCalculation.Execute(session);

            var result = new GameTurnSnapshot(turnDialogs, objects, session.Id, turn, session.IsPause, session.IsDebug);

            _logger.Debug($"Turn {result.Turn}. Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return result;
        }
    }
}
