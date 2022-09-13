using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IGameTurnSnapshot
    {
        int Id { get; set; }

        int Turn { get; }

        bool IsPause { get; set; }

        bool IsDebug { get; set; }

        ITurnDialogs Dialogs { get; set; }

        List<ICelestialObject> GetCelestialObjects();
    }
}
