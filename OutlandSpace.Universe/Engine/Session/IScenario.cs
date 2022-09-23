using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Entities.Characters;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IScenario
    {
        string Id { get; }

        string Name { get; }

        List<ICelestialObject> CelestialObjects { get; }

        List<IDialog> Dialogs { get; }

        List<ICharacter> Characters { get; }

        string RootFolder { get; }
    }
}
