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
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static List<ICelestialObject> Execute(List<ICelestialObject> objects, int turn, double ticks = 1)
        {
            var stopwatch = Stopwatch.StartNew();

            Logger.Debug($"Turn {turn}. [RecalculateCelestialObjectsLocations] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return objects;
        }
    }
}
