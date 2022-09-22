using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using log4net;

using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution.Calculation
{
    public static class RecalculateCelestialObjectsLocations
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public static List<ICelestialObject> Execute(ImmutableList<ICelestialObject> objects, int turn, double ticks = 1)
        {
            var stopwatch = Stopwatch.StartNew();

            var resultCollection = new List<ICelestialObject>();

            resultCollection.AddRange(objects);

            Logger.Debug($"Turn {turn}. [RecalculateCelestialObjectsLocations] finished {stopwatch.Elapsed.TotalMilliseconds} ms.");

            return resultCollection;
        }
    }
}
