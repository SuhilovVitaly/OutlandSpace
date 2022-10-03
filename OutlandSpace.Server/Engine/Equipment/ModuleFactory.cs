using System;
using System.Collections.Generic;
using System.IO;
using OutlandSpace.Universe.Entities.Equipment;
using OutlandSpace.Universe.Entities.Equipment.Reactor;

namespace OutlandSpace.Server.Engine.Equipment
{
    public class ModuleFactory
    {
        public EquipmentStorage Initialize(string dialogsRootFolder = "Data", string scenarioId = "")
        {
            var metrics = new EquipmentMetrics();
            var equipment = new List<IModule>();

            equipment.AddRange(Load(dialogsRootFolder + @"\Modules", Category.Reactor));

            return new EquipmentStorage(equipment, metrics);
        }

        private static IEnumerable<IModule> Load(string dialogsRootFolder,  Category moduleType)
        {
            var rootPath = Path.Combine(Environment.CurrentDirectory, dialogsRootFolder + @"\" + moduleType);

            var modules = new List<IModule>();

            switch (moduleType)
            {
                case Category.ControlCenter:
                    break;
                case Category.Weapon:
                    break;
                case Category.Shield:
                    break;
                case Category.Propulsion:
                    break;
                case Category.Reactor:
                    modules.AddRange(Universe.Tools.ResourceLoader<Reactor>.LoadFromFolder(rootPath));
                    return modules;
                case Category.SpaceScanner:
                    break;
                case Category.DeepScanner:
                    break;
                case Category.Cargo:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(moduleType), moduleType, null);
            }

            return modules;
        }
    }
}
