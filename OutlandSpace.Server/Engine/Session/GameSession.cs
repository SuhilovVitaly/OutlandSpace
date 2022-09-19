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
        private protected DialogsStorage Storage;
        public List<ICelestialObject> CelestialObjects { get; private set; }
       

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

        private void Initialization(List<ICelestialObject> objects, ITurnDialogs dialogs, DialogsStorage storage)
        {
            Logger.Info("Start new game session.");

            CelestialObjects = objects;
            Dialogs = dialogs;
            Storage = storage;

            Status.Pause();
        }

        public IGameTurnSnapshot TurnExecute()
        {
            Dialogs = TurnCalculate.GetCurrentTurnDialogs(Turn, Storage);
            CelestialObjects = TurnCalculate.RecalculateLocations(Turn, CelestialObjects.DeepClone());

            Turn++;

            return new GameTurnSnapshot(Dialogs.DeepClone(), CelestialObjects.DeepClone(), Id, Turn, IsPause, IsDebug);
        }

        public List<ICelestialObject> GetCelestialObjects()
        {
            return CelestialObjects;
        }

        // TODO: Remove it
        public void UpdateTurn(List<ICelestialObject> objects, int turns)
        {
            CelestialObjects = objects;
            Turn += turns;
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
