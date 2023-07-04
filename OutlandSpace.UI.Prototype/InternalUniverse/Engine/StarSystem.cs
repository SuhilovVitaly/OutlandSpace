using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.UI.Prototype.InternalUniverse.Engine
{
    public class StarSystem: IStarSystem
    {
        private List<ICelestialObject> _celestialObjects = new List<ICelestialObject>();

        public string Id { get; set; }
        public string Name { get; set; }

        public List<ICelestialObject> GetCelestialObjects()
        {
            return _celestialObjects;
        }

        public void SetCelestialObjects(List<ICelestialObject> celestialObjects)
        {
            _celestialObjects = celestialObjects;
        }
    }
}