using System;
using System.Collections.Generic;
using System.Diagnostics;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
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

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
