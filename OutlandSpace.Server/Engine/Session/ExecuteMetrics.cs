using System;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server.Engine.Session
{
    public class ExecuteMetrics: IExecuteMetrics
    {
        public int TickCounter { get; set; }
        public int TurnCounter { get; set; }
        public int LocationCalculateCounter { get; set; }
        public DateTime LastUpdate { get; set; }

        public double LastExecutionTimeMs { get; set; }

        public double AveregeExecutionTimeMs { get; set; }

        public void IncreaseLocationCalculate()
        {
            LocationCalculateCounter++;
        }

        public void IncreaseTurn()
        {
            TurnCounter++;
        }

        public void IncreaseTick()
        {
            TickCounter++;
        }

        public void UpdateLastExecution(double executionTimeInMilliseconds)
        {
            LastExecutionTimeMs = executionTimeInMilliseconds;
            AveregeExecutionTimeMs = (AveregeExecutionTimeMs + executionTimeInMilliseconds) / 2;

            LastUpdate = DateTime.UtcNow;
        }
    }
}