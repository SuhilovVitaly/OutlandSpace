using System;
using System.Collections.Generic;
using System.IO;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Characters
{
    public class CharactersFactory
    {
        public ICharactersStorage Initialize(string dialogsRootFolder = "Data", string scenarioId = "")
        {
            var metrics = new CharactersMetrics();

            var characters = new List<ICharacter>();

            var rootPath = Path.Combine(Environment.CurrentDirectory, dialogsRootFolder, "Characters");

            if (!Directory.Exists(rootPath))
            {
                metrics.IncreaseLoadedFromBaseGame(0);
            }
            else
            {
                var charactersFromRoot = Universe.Tools.ResourceLoader<CrewMember>.LoadFromFolder(
                Path.Combine(Environment.CurrentDirectory, dialogsRootFolder, "Characters")
                );

                characters.AddRange(charactersFromRoot);

                metrics.IncreaseLoadedFromBaseGame(charactersFromRoot.Count);
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
                    var charactersFromScenario = Universe.Tools.ResourceLoader<CrewMember>.LoadFromFolder(
                        Path.Combine(Environment.CurrentDirectory, rootScenarioPath)
                    );

                    characters.AddRange(charactersFromScenario);

                    metrics.IncreaseLoadedFromScenario(charactersFromScenario.Count);
                }
            }

            return new CharactersStorage(characters, metrics);
        }
    }
}