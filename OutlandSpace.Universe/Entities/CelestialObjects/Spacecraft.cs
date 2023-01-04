using System;
using System.Collections.Generic;
using System.Text;
using OutlandSpace.Universe.Entities.Equipment.Compartments;

namespace OutlandSpace.Universe.Entities.CelestialObjects
{
    public class Spacecraft: BaseCelestialObject , ICelestialObject
    {
        public List<ICompartment> Compartments { get; set; }
    }
}
