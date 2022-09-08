using System.Collections.Generic;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Execution
{
    public class GameTurnSnapshot: IGameTurnSnapshot
    {
        public GameTurnSnapshot(List<ICelestialObject> objects, int id, int turn, bool isPause, bool isDebug)
        {
            Id = id;
            Turn = turn;
            IsPause = isPause;
            IsDebug = isDebug;
            celestialObjects = objects;
        }

        public int Id {get; set;}
        public int Turn {get; set;}
        public bool IsPause {get; set;}
        public bool IsDebug {get; set;}

        // TODO: Fill it
        public ITurnDialogs Dialogs { get; set; }

        private List<ICelestialObject> celestialObjects;

        public List<ICelestialObject> GetCelestialObjects()
        {
            return celestialObjects;
        }
    }
}
