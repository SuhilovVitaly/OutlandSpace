using System;
using System.Collections.Generic;
using System.Diagnostics;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public class GameTurnSnapshot : IGameTurnSnapshot
    {
        public GameTurnSnapshot(ITurnDialogs dialogs, List<ICelestialObject> objects, int id, int turn, bool isPause, bool isDebug)
        {
            Id = id;
            Turn = turn;
            IsPause = isPause;
            IsDebug = isDebug;
            celestialObjects = objects;
            Dialogs = dialogs;
        }

        public int Id { get; set; }
        public int Turn { get; set; }
        public bool IsPause { get; set; }
        public bool IsDebug { get; set; }

        public ITurnDialogs Dialogs { get; set; }

        private List<ICelestialObject> celestialObjects;

        public List<ICelestialObject> GetCelestialObjects()
        {
            return celestialObjects;
        }
    }
}
