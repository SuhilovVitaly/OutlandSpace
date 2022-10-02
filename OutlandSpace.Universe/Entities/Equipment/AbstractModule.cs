using System;
namespace OutlandSpace.Universe.Entities.Equipment
{
    [Serializable]
    public abstract class AbstractModule
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string CompartmentId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public double ReloadTime { get; set; }
        public double Reloading { get; set; }
    }
}
