using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IGameSessionData
    {
        int Id { get; set; }

        int Turn { get; }

        bool IsPause { get; set; }

        bool IsDebug { get; set; }

        List<ICelestialObject> GetCelestialObjects();
    }
}
