using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OutlandSpace.Universe.Entities.Characters;
using OutlandSpace.Universe.Tools;
using RandomNameGeneratorLibrary;

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

        public ICharacter GenerateRandomCrewMember(string celestialObjectId = "")
        {
            var gender = GetRandomGender();

            var name = GetFirstAndLastName(GetRandomGender()).Split(' ');

            var character = new CrewMember(Guid.NewGuid().ToString(), name[0], name[1], gender, celestialObjectId, "default");

            return character;
        }

        public static string GetFirstAndLastName(Gender gender) => gender switch
        {
            Gender.Male => new PersonNameGenerator().GenerateRandomMaleFirstAndLastName(),
            Gender.Female => new PersonNameGenerator().GenerateRandomFemaleFirstAndLastName(),
            _ => throw new InvalidEnumArgumentException()
        };

        public static Gender GetRandomGender() => RandomGenerator.GetInteger(1, 3) switch
        {
            1 => Gender.Male,
            2 => Gender.Female,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}