using System.Collections.Generic;
using OutlandSpace.UI.Prototype.InternalUniverse.Entities.CelestialObjects;

namespace OutlandSpace.UI.Prototype.InternalUniverse.Engine
{
    public interface IStarSystemFactory
    {
        IStarSystem Generate(int generationKey);

        List<Station> GetStations();
    }
}