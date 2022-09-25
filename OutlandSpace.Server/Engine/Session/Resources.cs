using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OutlandSpace.Server.Engine.Characters;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Session
{
    public class Resources
    {
        public List<ICelestialObject> CelestialObjects { get; }

        public List<IDialog> Dialogs { get; }

        public List<ICharacter> Characters { get; }

        public Resources(List<ICelestialObject> celestialObjects, List<IDialog> dialogs, List<ICharacter> characters)
        {
            CelestialObjects = celestialObjects;
            Dialogs = dialogs;
            Characters = characters;
        }

        public Resources(string gameFolder, string scenarioFolder)
        {
            CelestialObjects = LoadCelestialObjects(scenarioFolder, gameFolder);
            Dialogs = LoadDialogs(scenarioFolder, gameFolder);
            Characters = LoadCharacters(scenarioFolder, gameFolder);
        }

        private static List<ICelestialObject> LoadCelestialObjects(string scenarioFolderName, string gameFolder)
        {
            var resultCollection = new List<ICelestialObject>();

            var rootPath = Path.Combine(Environment.CurrentDirectory, gameFolder, "Scenarios", scenarioFolderName, "CelestialObjects.json");

            var baseCelestialObjects = JsonConvert.DeserializeObject<List<BaseCelestialObject>>(File.ReadAllText(rootPath));

            if (baseCelestialObjects != null) resultCollection.AddRange(baseCelestialObjects);

            return resultCollection;
        }

        private static List<IDialog> LoadDialogs(string scenarioFolderName, string rootGameFolder)
        {
            var dialogs = new List<IDialog>();

            var gameDialogs = new DialogFactory().Initialize(rootGameFolder).Dialogs;

            var scenarioDialogs = new DialogFactory().Initialize(Path.Combine(Environment.CurrentDirectory, rootGameFolder, "Scenarios", scenarioFolderName)).Dialogs;

            dialogs.AddRange(gameDialogs);
            dialogs.AddRange(scenarioDialogs);

            return dialogs;
        }

        private static List<ICharacter> LoadCharacters(string scenarioFolderName, string rootGameFolder)
        {
            var charactersFactory = new CharactersFactory().Initialize(rootGameFolder, scenarioFolderName);

            return charactersFactory.Characters;
        }
    }
}