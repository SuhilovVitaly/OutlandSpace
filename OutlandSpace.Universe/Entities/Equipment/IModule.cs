using System;
namespace OutlandSpace.Universe.Entities.Equipment
{
    public interface IModule
    {
        string Id { get; set; }
        string OwnerId { get; set; }
        string Name { get; set; }
        Category Category { get; set; }
        string CompartmentId { get; set; }
    }
}
