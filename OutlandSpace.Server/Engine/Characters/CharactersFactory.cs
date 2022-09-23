using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Characters
{
    public class CharactersFactory
    {
        public ICharactersStorage Initialize(string dialogsRootFolder = "Data", string scenarioId = "")
        {
            var metrics = new CharactersMetrics();

            var characters = new List<ICharacter>();

            var rootPath = Path.Combine(Environment.CurrentDirectory, dialogsRootFolder + @"/Characters");

            if (!Directory.Exists(rootPath))
            {
                metrics.IncreaseLoadedFromBaseGame(0);
            }
            else
            {
                foreach (var fileContent in Universe.Tools.FilesFactory.GetFilesContentFromDirectory(dialogsRootFolder + @"/Characters"))
                {
                    var jsonCharacters = JsonConvert.DeserializeObject<List<CrewMember>>(value: fileContent);
                    characters.AddRange(jsonCharacters);
                    metrics.IncreaseLoadedFromBaseGame(jsonCharacters.Count);
                }
            }

            

            if (!string.IsNullOrEmpty(scenarioId))
            {
                // Load characters from scenario folder
                var rootScenarioPath = Path.Combine(dialogsRootFolder, "Scenarios", scenarioId, "Characters");

                if (!Directory.Exists(rootScenarioPath))
                {
                    metrics.IncreaseLoadedFromScenario(0);
                }
                else
                {
                    foreach (var fileContent in Universe.Tools.FilesFactory.GetFilesContentFromDirectory(rootScenarioPath))
                    {
                        var jsonCharacters = JsonConvert.DeserializeObject<List<CrewMember>>(value: fileContent);
                        characters.AddRange(jsonCharacters);
                        metrics.IncreaseLoadedFromScenario(jsonCharacters.Count);
                    }
                }
            }

            return new CharactersStorage(characters, metrics);
        }
    }
}