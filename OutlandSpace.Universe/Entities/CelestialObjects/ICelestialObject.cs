
namespace OutlandSpace.Universe.Entities.CelestialObjects
{
    public interface ICelestialObject
    {
        int Id { get; set; }
        string Name { get; set; }
        double Direction { get; set; }
        double Valocity { get; set; }

        CelestialObjectTypes Type { get; set; }
    }
}
