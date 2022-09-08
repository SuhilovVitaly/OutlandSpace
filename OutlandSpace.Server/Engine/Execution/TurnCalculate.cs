using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Execution
{
    public class TurnCalculate
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static IGameTurnSnapshot Execute(IGameSession session)
        {
            var stopwatch = Stopwatch.StartNew();

            var result = new GameTurnSnapshot(null, session.Id, session.Turn + 1, session.IsPause, session.IsDebug);

            _logger.Debug($"Turn {result.Turn}. Calculation finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return result;
        }
    }
}
