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
        public string Id { get; private set; }

        public string Name { get; set; }

        public List<ICelestialObject> CelestialObjects { get; private set; }

        public List<IDialog> Dialogs { get; private set; }

        public List<ICharacter> Characters { get; private set; }

        public string RootFolder { get; private set; }

        public Scenario(string id, string scenarioRootFolder = "Data")
        {
            Id = id;

            RootFolder = scenarioRootFolder;

            Initialization();
        }

        public Scenario(string id, DialogsStorage dialogsStorage, string scenarioRootFolder = "Data")
        {
            Id = id;

            RootFolder = scenarioRootFolder;

            Initialization();

            Dialogs.AddRange(dialogsStorage.Dialogs);
        }

        private void Initialization()
        {
            CelestialObjects = LoadCelestialObjects(Id);
            Dialogs = LoadDialogs(Id);
            Characters = LoadCharacters(Id, RootFolder);
        }

        private List<ICelestialObject> LoadCelestialObjects(string scenarioFolderName)
        {
            var resultCollection = new List<ICelestialObject>();
            /*
            {
                new Asteroid(Guid.NewGuid().ToString(), 90.0, 10.0, new Universe.Geometry.Point(200.0f, 100.0f), "BD-800-349-AO"),
                new Asteroid(Guid.NewGuid().ToString(), 180.0, 5.0, new Universe.Geometry.Point(300.0f, 150.0f), "BD-800-349-A1")
            };

            var jsonManual = JsonConvert.SerializeObject(resultCollection);
            */

            var rootPath = Path.Combine(Environment.CurrentDirectory, RootFolder, "Scenarios", scenarioFolderName, "CelestialObjects.json");

            var baseCelestialObjects = JsonConvert.DeserializeObject<List<BaseCelestialObject>>(File.ReadAllText(rootPath));

            resultCollection.AddRange(baseCelestialObjects);

            return resultCollection;
        }

        private List<IDialog> LoadDialogs(string scenarioFolderName)
        {
            var rootPath = Path.Combine(RootFolder, "Scenarios", scenarioFolderName);

            return new DialogFactory().Initialize(rootPath).Dialogs;
        }

        private List<ICharacter> LoadCharacters(string scenarioFolderName, string rootGameFolder)
        {
            var charactersFactory = new CharactersFactory().Initialize(rootGameFolder, scenarioFolderName);

            return charactersFactory.Characters;
        }
    }
}
