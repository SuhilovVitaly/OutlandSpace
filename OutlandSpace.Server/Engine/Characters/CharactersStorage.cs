using System;
using System.Collections.Generic;
using System.Linq;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Characters
{
    [Serializable]
    public class CharactersStorage: ICharactersStorage
    {
        public List<ICharacter> Characters { get; }

        public CharactersMetrics Metrics { get; set; }

        public CharactersStorage(List<ICharacter> characters, CharactersMetrics metrics)
        {
            Characters = characters;
            Metrics = metrics;
        }

        public ICharacter GetCharacter(string characterId)
        {
            return Characters.FirstOrDefault(character => character.Id == characterId);
        }
    }
}