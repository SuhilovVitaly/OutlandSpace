using System;
namespace OutlandSpace.Controller
{
    public class WorkerMetrics: IWorkerMetrics
    {
        public int TickCounter { get; private set; }

        public int TurnCounter { get; private set; }

        public int AtomicTurnCounter { get; private set; }

        public DateTime LastUpdate { get; private set; }

        public int Commands { get; private set; }

        public void IncreaseAtomicTurnCounter()
        {
            AtomicTurnCounter++;
        }

        public void IncreaseCommands()
        {
            Commands++;
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
