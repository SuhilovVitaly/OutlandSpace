using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Session
{
    public class Scenario: IScenario
    {
        public string Id { get; private set; }

        public string Name { get; set; }

        public List<ICelestialObject> CelestialObjects { get; private set; }

        public List<IDialog> Dialogs { get; private set; }

        private string ScenarioRootFolder { get; }

        public Scenario(string id, string scenarioRootFolder = "Data")
        {
            Id = id;

            ScenarioRootFolder = scenarioRootFolder;

            Initialization();
        }

        private void Initialization()
        {
            CelestialObjects = LoadCelestialObjects(Id);
            Dialogs = LoadDialogs(Id);
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


            var rootPath = Path.Combine(Environment.CurrentDirectory, ScenarioRootFolder, "Scenarios", scenarioFolderName, "CelestialObjects.json");

            var baseCelestialObjects = JsonConvert.DeserializeObject<List<BaseCelestialObject>>(File.ReadAllText(rootPath));

            resultCollection.AddRange(baseCelestialObjects);

            return resultCollection;
        }

        private List<IDialog> LoadDialogs(string scenarioFolderName)
        {
            var rootPath = Path.Combine(ScenarioRootFolder, "Scenarios", scenarioFolderName);

            return new DialogFactory().Initialize(rootPath).Dialogs;
        }
    }
}
