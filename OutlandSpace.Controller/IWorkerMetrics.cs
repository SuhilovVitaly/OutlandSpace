using System;
namespace OutlandSpace.Controller
{
    public interface IWorkerMetrics
    {
        int TickCounter { get; }
        int TurnCounter { get; }
        int Commands { get; }
        int AtomicTurnCounter { get; }
        DateTime LastUpdate { get; }

        void IncreaseTick();
        void IncreaseTurn();
        void IncreaseCommands();
        void IncreaseAtomicTurnCounter();
        void UpdateLastExecution();
    }
}
