using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

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

        public static IGameTurnSnapshot Initialization(List<ICelestialObject> celestialObjects, DialogsStorage dialogsStorage)
        {
            var stopwatch = Stopwatch.StartNew();            

            var turnDialogs = DialogsCalculation.Execute(dialogsStorage, 0);

            var session = new GameSession(celestialObjects, turnDialogs);

            var objects = celestialObjects;

            var result = new GameTurnSnapshot(turnDialogs, objects, session.Id, 0, session.IsPause, session.IsDebug);

            _logger.Debug($"Turn {result.Turn}. Initialization finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return result;
        }
    }
}
