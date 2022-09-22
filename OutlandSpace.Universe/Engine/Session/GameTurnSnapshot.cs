using System.Collections.Immutable;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public class GameTurnSnapshot : IGameTurnSnapshot
    {
        public GameTurnSnapshot(ITurnDialogs dialogs, ImmutableList<ICelestialObject> objects, string id, int turn, bool isPause, bool isDebug)
        {
            Id = id;
            Turn = turn;
            IsPause = isPause;
            IsDebug = isDebug;
            celestialObjects = objects;
            Dialogs = dialogs;
        }

        public string Id { get; set; }
        public int Turn { get; set; }
        public bool IsPause { get; set; }
        public bool IsDebug { get; set; }

        public ITurnDialogs Dialogs { get; set; }

        private ImmutableList<ICelestialObject> celestialObjects;

        public ImmutableList<ICelestialObject> GetCelestialObjects()
        {
            return celestialObjects;
        }
    }
}
