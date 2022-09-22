using System;
namespace OutlandSpace.Universe.Engine
{
    public interface IServerMetrics
    {
        int TickCounter { get; }
        int TurnCounter { get; }
        int AtomicTurnCounter { get; }
        DateTime LastUpdate { get; }

        void IncreaseTick();
        void IncreaseTurn();
        void IncreaseAtomicTurnCounter();
        void UpdateLastExecution();
        
    }
}
