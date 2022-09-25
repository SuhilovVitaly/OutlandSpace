using System.Collections.Immutable;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Universe.Engine.Session
{
    public class GameTurnSnapshot : IGameTurnSnapshot
    {
        public GameTurnSnapshot(ITurnInteraction interaction, ImmutableList<ICelestialObject> objects, string id, int turn, bool isPause, bool isDebug)
        {
            Id = id;
            Turn = turn;
            IsPause = isPause;
            IsDebug = isDebug;
            celestialObjects = objects;
            Interaction = interaction;
        }

        public string Id { get; set; }
        public int Turn { get; set; }
        public bool IsPause { get; set; }
        public bool IsDebug { get; set; }

        public ITurnInteraction Interaction { get; set; }

        private ImmutableList<ICelestialObject> celestialObjects;

        public ImmutableList<ICelestialObject> GetCelestialObjects()
        {
            return celestialObjects;
        }
    }
}
