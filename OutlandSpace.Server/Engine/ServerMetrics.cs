using System;
using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Server.Engine
{
    public class ServerMetrics: IServerMetrics
    {
        public ServerMetrics()
        {
        }

        public int TickCounter { get; private set; }

        public int TurnCounter { get; private set; }

        public int AtomicTurnCounter { get; private set; }

        public DateTime LastUpdate { get; private set; }

        public void IncreaseAtomicTurnCounter()
        {
            AtomicTurnCounter++;
        }

        public void IncreaseTick()
        {
            TickCounter++;
        }

        public void IncreaseTurn()
        {
            TurnCounter++;
        }

        public void UpdateLastExecution()
        {
            LastUpdate = DateTime.UtcNow;
        }
    }
}
