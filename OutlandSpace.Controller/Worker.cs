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
        private IGameTurnSnapshot _session;

        public event Action<IGameTurnSnapshot> OnStartGame;
        public event Action<IGameTurnSnapshot> OnEndTurn;
        public event Action<IGameTurnSnapshot> OnRefreshLocations;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeActiveObject;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeSelectedObject;
        public event Action<IGameTurnSnapshot, int> OnEndTurnStep;

        public Worker()
        {
            _gameServer = new LocalServer();
        }

        public bool IsRunning()
        {
            return _session != null;
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

        public void StartNewGameSession(int ticks = 25)
        {
            //IGameSessionData session = new SessionDataDto
            //{
            //    Id = 100,
            //    IsDebug = true,
            //    IsPause = true,
            //    Turn = 0,
            //    CelestialObjects = new System.Collections.Generic.List<Universe.CelestialObjects.ICelestialObject>()
            //};

            //_session = _gameServer.SessionInitialization(session);

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

            if (_session == null) throw new NullReferenceException();

            var timeMetricGetGameSession = Stopwatch.StartNew();

            //var gameSession = _gameServer.RefreshGameSession(_session.Id);

            timeMetricGetGameSession.Stop();

            _inProgress = false;
        }
    }
}
