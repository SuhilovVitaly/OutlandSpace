using System;
using OutlandSpace.Universe.Geometry;

namespace OutlandSpace.Universe.Entities.CelestialObjects
{
    [Serializable]
    public class Asteroid: ICelestialObject
    {
        public Asteroid(string id, double direction, double velocity, Point location, string name = "")
        {
            Id = id;
            Name = name;
            Direction = direction;
            Velocity = velocity;
            Location = location;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Direction { get; set; }
        public double Velocity { get; set; }
        public CelestialObjectTypes Type { get; set; } = CelestialObjectTypes.Asteroid;
        public Point Location { get; set; }
    }
}
