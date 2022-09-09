using System;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public class TurnPropertiesCalculation
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static int Execute(IGameSession session)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.Debug($"Turn {session.Turn}. [TurnPropertiesCalculation] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return session.Turn + 1;
        }
    }
}
