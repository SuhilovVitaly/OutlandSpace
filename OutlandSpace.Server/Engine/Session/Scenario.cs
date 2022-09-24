using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Session
{
    public class Scenario: IScenario
    {
        public string Id { get; }

        public string Name { get; set; }

        public List<ICelestialObject> CelestialObjects { get; private set; }

        public List<IDialog> Dialogs { get; private set; }

        public List<ICharacter> Characters { get; private set; }

        public string RootFolder { get; }

        public Scenario(string id, string scenarioRootFolder = "Data")
        {
            Id = id;

            RootFolder = scenarioRootFolder;

            Initialization();
        }

        public Scenario(string id, Resources resources)
        {
            Id = id;

            CelestialObjects = resources.CelestialObjects;
            Dialogs = resources.Dialogs;
            Characters = resources.Characters;
        }

        private void Initialization()
        {
            var resources = new Resources(RootFolder, Id);

            CelestialObjects = resources.CelestialObjects;
            Dialogs = resources.Dialogs;
            Characters = resources.Characters;
        }

    }
}
