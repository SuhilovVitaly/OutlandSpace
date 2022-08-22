using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Session
{
    public interface IGameSession
    {
        int Turn { get; }
        bool IsPause { get; }
        bool IsDebug { get; set; }
        string ScenarioName { get; }
        List<ICelestialObject> CelestialObjects { get; }
    }
}
