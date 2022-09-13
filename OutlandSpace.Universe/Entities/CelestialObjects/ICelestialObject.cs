
using OutlandSpace.Universe.Geometry;

namespace OutlandSpace.Universe.Entities.CelestialObjects
{
    public interface ICelestialObject
    {
        string Id { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        double Velocity { get; set; }
        Point Location { get; set; }
        CelestialObjectTypes Type { get; set; }
    }
}
