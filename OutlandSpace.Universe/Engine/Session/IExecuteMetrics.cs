using System;

namespace OutlandSpace.Universe.Engine.Session
{
    public interface IExecuteMetrics
    {
        int TickCounter { get; }

        int TurnCounter { get; }

        int LocationCalculateCounter { get; }

        double LastExecutionTimeMs { get; }

        double AveregeExecutionTimeMs { get; }

        DateTime LastUpdate { get; set; }

        void IncreaseLocationCalculate();

        void IncreaseTurn();

        void IncreaseTick();

        void UpdateLastExecution(double executionTimeInMilliseconds);
    }
}
