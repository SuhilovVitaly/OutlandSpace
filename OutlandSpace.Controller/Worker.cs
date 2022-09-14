using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Session;
using System;
using System.Diagnostics;

namespace OutlandSpace.Controller
{
    public class Worker : IGameEvents
    {
        private readonly IGameServer _gameServer;
        private IGameTurnSnapshot _turnSnapshot;

        public event Action<IGameTurnSnapshot> OnStartGame;
        public event Action<IGameTurnSnapshot> OnEndTurn;
        public event Action<IGameTurnSnapshot> OnRefreshLocations;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeActiveObject;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeSelectedObject;
        public event Action<IGameTurnSnapshot, int> OnEndTurnStep;

        public struct Status
        {
            public bool IsRunning { get; set; } 
        }

        public Status WorkerStatus { get; private set; }

        public Worker()
        {
            _gameServer = new LocalServer();

            WorkerStatus = new Status();
        }

        public IGameTurnSnapshot GetSnapshot()
        {
            return _turnSnapshot;
        }

        public bool IsRunning()
        {
            return _turnSnapshot != null;
        }

        public void SessionResume()
        {
            //Logger.Info($"Game resumed. Turn is {_session.Turn}");

            //_gameServer.ResumeSession(_session.Id);
        }

        public void SessionPause()
        {
            //Logger.Info($"Game paused. Turn is {_session.Turn}");
        }

        public void StartNewGameSession(string scenarioId, int ticks = 25)
        {
            _turnSnapshot = _gameServer.Initialization(scenarioId);

            //OnStartGame?.Invoke(_session);

            if (ticks <= 0) return;

            Universe.Tools.Scheduler.Instance.ScheduleTask(1, ticks, GetDataFromServer);
            Universe.Tools.Scheduler.Instance.ScheduleTask(1, ticks, RefreshLocations);
        }

        private void RefreshLocations()
        {

        }

        private bool _inProgress;

        public void GetDataFromServer()
        {
            if (_inProgress) return;

            _inProgress = true;

            if (_turnSnapshot == null) throw new NullReferenceException();

            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.GetSnapshot();

            timeMetricGetGameSession.Stop();

            _inProgress = false;
        }
    }
}
