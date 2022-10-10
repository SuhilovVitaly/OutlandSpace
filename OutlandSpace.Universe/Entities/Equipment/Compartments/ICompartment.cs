namespace OutlandSpace.Universe.Entities.Equipment.Compartments
{
    public interface ICompartment
    {
        string Id { get; set; }

        string CelestialObjectId { get; set; }

        int X { get; set; }
        int Y { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}