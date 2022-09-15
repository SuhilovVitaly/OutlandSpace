using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Session;
using System;
using System.Diagnostics;
using System.Threading;

namespace OutlandSpace.Controller
{
    public class Worker : IGameEvents
    {
        private readonly IGameServer _gameServer;
        private IGameTurnSnapshot _turnSnapshot;
        private long _refreshCounter;
        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();

        public event Action<IGameTurnSnapshot> OnStartGame;
        public event Action<IGameTurnSnapshot> OnEndTurn;
        public event Action<IGameTurnSnapshot> OnRefreshLocations;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeActiveObject;
        public event Action<IGameTurnSnapshot, int> OnChangeChangeSelectedObject;
        public event Action<IGameTurnSnapshot, int> OnEndTurnStep;

        public bool _isRunning { get; private set; }

        public Worker()
        {
            _gameServer = new LocalServer();
        }

        public IGameTurnSnapshot GetSnapshot()
        {
            return _turnSnapshot;
        }

        public bool IsRunning()
        {
            return _isRunning;
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


        public void GetDataFromServer()
        {
            dictionaryLock.EnterWriteLock();

            _refreshCounter++;

            if (_turnSnapshot == null) throw new NullReferenceException();

            var timeMetricGetGameSession = Stopwatch.StartNew();

            var gameSession = _gameServer.GetSnapshot();

            timeMetricGetGameSession.Stop();

            dictionaryLock.ExitWriteLock();
        }

        public long GetRefreshCounter()
        {
            return _refreshCounter;
        }
    }
}
