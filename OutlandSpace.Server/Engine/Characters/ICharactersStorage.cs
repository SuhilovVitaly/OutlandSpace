using System.Collections.Generic;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Server.Engine.Characters
{
    public interface ICharactersStorage
    {
        List<ICharacter> Characters { get; }
        CharactersMetrics Metrics { get; set; }
        ICharacter GetCharacter(string characterId);
        ICharacter GenerateRandomCrewMember(string celestialObjectId = "");
    }
}