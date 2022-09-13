using System;
using OutlandSpace.Universe.Geometry;

namespace OutlandSpace.Universe.Entities.CelestialObjects
{
    [Serializable]
    public class BaseCelestialObject : ICelestialObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public double Velocity { get; set; }
        public CelestialObjectTypes Type { get; set; }
        public Point Location { get; set; }
    }
}
