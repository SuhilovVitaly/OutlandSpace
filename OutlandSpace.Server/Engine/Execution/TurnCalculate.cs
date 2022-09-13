using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static GameSession Execute(IGameSession session, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();

            var turnDialogs = DialogsCalculation.Execute(session, dialogsStorage);
            var objects = RecalculateCelestialObjectsLocations.Execute(session);
            var turn = TurnPropertiesCalculation.Execute(session);

            var sessionRebuilded = new GameSession(objects, turnDialogs, turn);

            _logger.Debug($"Turn {sessionRebuilded.Turn}. Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return sessionRebuilded;
        }

        public static GameSession Initialization(IScenario scenario, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();            

            var turnDialogs = DialogsCalculation.Execute(dialogsStorage, 0);

            var session = new GameSession(scenario.CelestialObjects, turnDialogs);

            _logger.Debug($"Turn {session.Turn}. Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return session;
        }
    }
}
