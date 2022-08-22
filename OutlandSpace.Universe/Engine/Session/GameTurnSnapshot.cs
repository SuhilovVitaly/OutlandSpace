using System;
using System.Collections.Generic;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public class GameTurnSnapshot : IGameTurnSnapshot
    {
        public GameTurnSnapshot()
        {
        }

        public int Id { get; set; }
        public bool IsPause { get; set; } = true;
        public bool IsDebug { get; set; } = false;

        public int Turn => throw new NotImplementedException();

        public List<ICelestialObject> GetCelestialObjects()
        {
            throw new NotImplementedException();
        }
    }
}
