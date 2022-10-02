using System;
namespace OutlandSpace.Universe.Entities.Equipment.Reactor
{
    [Serializable]
    public class Reactor : AbstractModule, IModule, IReactor
    {
        public double ActivationCost { get; set; }
        public double Power { get; set; }
    }
}
