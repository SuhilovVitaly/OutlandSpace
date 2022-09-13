using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class RecalculateCelestialObjectsLocations
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static List<ICelestialObject> Execute(IGameSession session)
        {
            var stopwatch = Stopwatch.StartNew();

            _logger.Debug($"Turn {session.Turn}. [RecalculateCelestialObjectsLocations] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return null;
        }
    }
}
