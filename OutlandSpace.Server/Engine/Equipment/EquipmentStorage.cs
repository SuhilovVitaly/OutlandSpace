using System.Collections.Generic;
using OutlandSpace.Universe.Entities.Equipment;

namespace OutlandSpace.Server.Engine.Equipment
{
    public class EquipmentStorage
    {
        public List<IModule> Modules { get; }

        public EquipmentMetrics Metrics { get; }

        public EquipmentStorage(List<IModule> modules, EquipmentMetrics metrics)
        {
            Modules = modules;
            Metrics = metrics;
        }
    }
}