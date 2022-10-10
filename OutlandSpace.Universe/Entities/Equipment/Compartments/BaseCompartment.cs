using System;
using System.Collections.Generic;
using System.Text;

namespace OutlandSpace.Universe.Entities.Equipment.Compartments
{
    public class BaseCompartment: ICompartment
    {
        public string Id { get; set; }

        public string CelestialObjectId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public BaseCompartment(string id, string celestialObjectId)
        {
            Initialization(id, celestialObjectId);
        }

        public BaseCompartment(string celestialObjectId)
        {
            Initialization(Guid.NewGuid().ToString(), celestialObjectId);
        }

        private void Initialization(string id, string celestialObjectId)
        {
            Id = id;
            CelestialObjectId = celestialObjectId;
        }
    }
}
