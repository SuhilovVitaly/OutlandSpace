using System;

namespace OutlandSpace.Universe.Entities.Characters
{
    [Serializable]
    public class CrewMember : ICharacter
    {
        public string Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Gender Gender { get; private set; }

        public string LocationCelestialObjectId { get; private set; }

        public CrewMember(string id, string firstName, string lastName, Gender gender, string locationCelestialObjectId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;

            LocationCelestialObjectId = locationCelestialObjectId;
        }
    }
}