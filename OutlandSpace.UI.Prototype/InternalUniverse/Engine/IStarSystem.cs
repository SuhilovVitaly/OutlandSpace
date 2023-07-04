using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.UI.Prototype.InternalUniverse.Engine
{
    public interface IStarSystem
    {
        string Id { get; set; }
        string Name { get; set; }

        List<ICelestialObject> GetCelestialObjects();

        void SetCelestialObjects(List<ICelestialObject> celestialObjects);
    }
}