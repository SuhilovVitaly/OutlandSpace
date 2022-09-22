using System;
using OutlandSpace.Server.Engine;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Tools;

namespace OutlandSpace.Server
{
    public class RealTimeEngine
    {
        public IServerMetrics Metrics { get; private set; }

        public RealTimeEngine()
        {
            Metrics = new ServerMetrics();
        }

        public void Initialization(Action executeTurnCalculation)
        {
            Scheduler.Instance.ScheduleTask(50, 100, executeTurnCalculation, null);
        }

        public void ExecuteTurnCalculation()
        {
            Metrics.IncreaseTick();
        }
    }

    public class RealTimeService
    {
        public IServerMetrics Metrics { get; private set; }

        public RealTimeService()
        {
            Metrics = new ServerMetrics();
        }

        public void ExecuteTurnCalculation()
        {
            Metrics.IncreaseTick();

            var millisecondAfterLastTurnExecution = (DateTime.UtcNow - Metrics.LastUpdate).TotalMilliseconds;
            if (millisecondAfterLastTurnExecution < 1000)
            {
                Metrics.IncreaseAtomicTurnCounter();
                return;
            }

            Metrics.IncreaseAtomicTurnCounter();

            Metrics.IncreaseTurn();

            Metrics.UpdateLastExecution();
        }
    }
}
