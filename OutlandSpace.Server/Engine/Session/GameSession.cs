using log4net;
using OutlandSpace.Server.Engine.Execution;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Engine.Session.Commands;
using OutlandSpace.Universe.Entities.CelestialObjects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace OutlandSpace.Server.Engine.Session
{
    [Serializable]
    [DebuggerDisplay("Turn: {Turn}")]
    public class GameSession: IGameSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private protected StatusController Status = new();
        public IDialogsStorage Storage { get; private set; }
        public List<ICelestialObject> CelestialObjects { get; private set; }
        public IExecuteMetrics Metrics { get; } = new ExecuteMetrics();
        public ITurnInteraction Interaction { get; private set; }

        public IResourcesStorage ResourcesStorage { get; }

        private readonly ReaderWriterLockSlim commandsLock = new();
        private protected ImmutableArray<ICommand> commands;

        public int Id { get; set; } // TODO: Refactor it to string Id with scenario
        private string _lastSnapshotId;

        public int Turn { get; private set; }

        private const double GranularityAtomic = 0.1;
        private const double GranularityTurn = 1.0;

        public IGameTurnSnapshot ToGameTurnSnapshot()
        {
            return new GameTurnSnapshot(
                Interaction,
                CelestialObjects.ToImmutableList(),
                _lastSnapshotId,
                Turn,
                IsPause,
                IsDebug);
        }

        public GameSession(IScenario scenario, int turn = 0)
        {
            ResourcesStorage = new ResourcesStorage(new Resources(scenario.CelestialObjects, scenario.Dialogs, scenario.Characters));

            Turn = turn;

            Logger.Info("Start new game session.");

            CelestialObjects = scenario.CelestialObjects;
            Interaction = DialogsCalculation.Execute(ResourcesStorage.Dialogs, Turn, new ImmutableArray<ICommand>());
            Storage = ResourcesStorage.Dialogs;

            Status.Pause();
        }

        public IGameTurnSnapshot RealTimeTurnExecute()
        {
            var millisecondAfterLastTurnExecution = (DateTime.UtcNow - Metrics.LastUpdate).TotalMilliseconds;
            if (millisecondAfterLastTurnExecution < 1000)
            {
                // Recalculate celestial objects positions 10 times per second
                CelestialObjects = LocationsExecute(GranularityAtomic);
                return ToGameTurnSnapshot();
            }

            // Recalculate all turn calculation 1 times per second

            return TurnExecute(GranularityAtomic, Stopwatch.StartNew());
        }

        public IGameTurnSnapshot TurnExecute()
        {
            return TurnExecute(GranularityTurn, Stopwatch.StartNew());
        }

        private IGameTurnSnapshot TurnExecute(double granularity, Stopwatch stopwatch)
        {
            _lastSnapshotId = Guid.NewGuid().ToString();

            CelestialObjects = LocationsExecute(granularity);

            Interaction = DialogsExecute(commands);

            EndTurnAndMetricsUpdate(stopwatch.Elapsed.TotalMilliseconds);

            return ToGameTurnSnapshot();
        }

        private List<ICelestialObject> LocationsExecute(double granularity)
        {
            var celestialObjects = TurnCalculate.RecalculateLocations(Turn, CelestialObjects.ToImmutableList(), granularity);
            Metrics.IncreaseLocationCalculate();

            return celestialObjects;
        }

        private ITurnInteraction DialogsExecute(ImmutableArray<ICommand> currentTurnCommands)
        {
            var dialogs = TurnCalculate.GetCurrentTurnDialogs(Turn, Storage, currentTurnCommands);

            return dialogs;
        }

        private void EndTurnAndMetricsUpdate(double executionTimeInMilliseconds)
        {
            Turn++;

            Metrics.IncreaseTurn();
            Metrics.UpdateLastExecution(executionTimeInMilliseconds);
        }

        public List<ICelestialObject> GetCelestialObjects()
        {
            return CelestialObjects;
        }


        #region IStatus implementation

        public void Resume() => Status.Resume();
        public void Pause() => Status.Pause();

        public void PullTurnCommands(ImmutableArray<ICommand> currentTurnCommands)
        {
            commandsLock.EnterWriteLock();
            commands = currentTurnCommands;
            commandsLock.ExitWriteLock();
        }

        public bool IsPause => Status.IsPause;

        public bool IsDebug { get; set; } = false;

        public string ScenarioName => throw new NotImplementedException();

        #endregion

    }
}
