using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Entities.CelestialObjects;

namespace OutlandSpace.Server.Engine.Session
{
    [Serializable]
    public class GameSession: IGameSession
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private protected StatusController Status = new();
        public List<ICelestialObject> CelestialObjects { get; private set; }
        public ITurnDialogs Dialogs { get; private set; }

        public int Id { get; set; }

        public int Turn { get; private set; }

        public GameSession()
        {
            _logger.Info("Start new game session.");
            Status.Pause();
        }

        public GameSession(List<ICelestialObject> objects, ITurnDialogs dialogs) : this()
        {
            CelestialObjects = objects;
            Dialogs = dialogs;
        }

        public List<ICelestialObject> GetCelestialObjects()
        {
            throw new NotImplementedException();
        }

        public void Initialization(string scenarioId)
        {
            IScenario scenario = new Scenario(scenarioId);

            CelestialObjects.AddRange(scenario.CelestialObjects);
        }

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
