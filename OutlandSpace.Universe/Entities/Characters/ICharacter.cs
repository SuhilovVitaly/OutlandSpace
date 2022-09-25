namespace OutlandSpace.Universe.Entities.Characters
{
    public interface ICharacter
    {
        string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public Gender Gender { get; }

        public string LocationCelestialObjectId { get; }

        public string Portrait { get; }
    }
}