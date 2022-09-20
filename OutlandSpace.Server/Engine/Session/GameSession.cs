using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution;
using OutlandSpace.Server.Engine.Execution.Calculation;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;
using OutlandSpace.Universe.Tools;

namespace OutlandSpace.Server.Engine.Session
{
    [Serializable]
    public class GameSession: IGameSession
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
        private protected StatusController Status = new();
        public IDialogsStorage Storage { get; private set; }
        public List<ICelestialObject> CelestialObjects { get; private set; }
        public IExecuteMetrics Metrics { get; } = new ExecuteMetrics();
        

        public ITurnDialogs Dialogs { get; private set; }

        public int Id { get; set; }

        public int Turn { get; private set; }

        public IGameTurnSnapshot ToGameTurnSnapshot()
        {
            return new GameTurnSnapshot(
                Dialogs,
                CelestialObjects,
                Id,
                Turn,
                IsPause,
                IsDebug);
        }

        public GameSession(List<ICelestialObject> objects, ITurnDialogs dialogs, int turn = 0) 
        {
            Turn = turn;

            Initialization(objects, dialogs, null);
        }

        public GameSession(IScenario scenario) : this(scenario.CelestialObjects, null)
        {
            var storage = new DialogsStorage(scenario.Dialogs);

            var turnDialogs = DialogsCalculation.Execute(storage, 0);

            Initialization(scenario.CelestialObjects, turnDialogs, storage);
        }

        private void Initialization(List<ICelestialObject> objects, ITurnDialogs dialogs, IDialogsStorage storage)
        {

            Logger.Info("Start new game session.");

            CelestialObjects = objects;
            Dialogs = dialogs;
            Storage = storage;

            Status.Pause();
        }

        public IGameTurnSnapshot RealTimeTurnExecute()
        {
            var millisecondAfterLastTurnExecution = (DateTime.UtcNow - Metrics.LastUpdate).TotalMilliseconds;
            if (millisecondAfterLastTurnExecution < 1000)
            {
                // Recalculate celestial objects positions 10 times per second
                CelestialObjects = LocationsExecute();
                return ToGameTurnSnapshot();
            }

            // Recalculate all turn calculation 1 times per second

            Dialogs = DialogsExecute();

            EndTurnAndMetricsUpdate();

            return ToGameTurnSnapshot();
        }

        public IGameTurnSnapshot TurnExecute()
        {
            CelestialObjects = LocationsExecute();

            Dialogs = DialogsExecute();

            EndTurnAndMetricsUpdate();

            return ToGameTurnSnapshot();
        }

        private List<ICelestialObject> LocationsExecute()
        {
            var celestialObjects = TurnCalculate.RecalculateLocations(Turn, CelestialObjects.DeepClone(), 0.1);
            Metrics.IncreaseLocationCalculate();

            return celestialObjects;
        }

        private ITurnDialogs DialogsExecute()
        {
            var dialogs = TurnCalculate.GetCurrentTurnDialogs(Turn, Storage);

            return dialogs;
        }

        private void EndTurnAndMetricsUpdate()
        {
            Turn++;

            Metrics.IncreaseTurn();
            Metrics.UpdateLastExecution();
        }

        public List<ICelestialObject> GetCelestialObjects()
        {
            return CelestialObjects;
        }


        #region IStatus implementation

        public void Resume() => Status.Resume();
        public void Pause() => Status.Pause();        

        public bool IsPause => Status.IsPause;

        public bool IsDebug { get; set; } = false;

        public string ScenarioName => throw new NotImplementedException();

        #endregion

    }
}
