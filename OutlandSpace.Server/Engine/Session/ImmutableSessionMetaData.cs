using System;
using System.Collections.Generic;
using System.Text;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Session
{
    public class ImmutableSessionMetaData
    {
        public IReadOnlyList<ICelestialObject> CelestialObjects { get; }

        public ImmutableSessionMetaData(IReadOnlyList<ICelestialObject> celestialObjects)
        {
            CelestialObjects = celestialObjects;
        }
    }

}
