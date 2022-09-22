using System.Collections.Immutable;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IGameTurnSnapshot
    {
        string Id { get; set; }

        int Turn { get; }

        bool IsPause { get; set; }

        bool IsDebug { get; set; }

        ITurnDialogs Dialogs { get; set; }

        ImmutableList<ICelestialObject> GetCelestialObjects();
    }
}
