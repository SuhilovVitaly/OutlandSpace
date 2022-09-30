using OutlandSpace.Server;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Engine.Session.Commands;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using log4net;

namespace OutlandSpace.Controller
{
    public class Worker : IGameEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public IWorkerMetrics Metrics { get; }
        private readonly IGameServer _gameServer;
        private IGameTurnSnapshot _turnSnapshot;
        private readonly ReaderWriterLockSlim _dictionaryLock = new();

        public event Action<IGameTurnSnapshot> OnStartGame;
        public event Action<IGameTurnSnapshot> OnEndTurn;
        public event Action<IGameTurnSnapshot> OnReceivedDialog;
        public event Action<IGameTurnSnapshot> OnRefreshLocations;

        private bool _isRunning;

        public Worker()
        {
            _gameServer = new LocalServer();

            Metrics = new WorkerMetrics();
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
            _gameServer.ResumeSession();
        }

        public void SessionPause()
        {
            _gameServer.PauseSession();
        }

        public void StartNewGameSession(string scenarioId, int ticks = 25)
        {
            _turnSnapshot = _gameServer.Initialization(scenarioId);

            var snapshot = _gameServer.GetSnapshot();

            OnStartGame?.Invoke(snapshot);

            if (ticks <= 0) return;

            Universe.Tools.Scheduler.Instance.ScheduleTask(1, ticks, GetDataFromServer);
            Universe.Tools.Scheduler.Instance.ScheduleTask(1, ticks, RefreshLocations);
        }

        private void RefreshLocations()
        {

        }

        public void GetDataFromServer()
        {
            _dictionaryLock.EnterWriteLock();

            Metrics.IncreaseTick();

            if (_turnSnapshot == null) throw new NullReferenceException();

            var timeMetricGetGameSession = Stopwatch.StartNew();

            var snapshot = _gameServer.GetSnapshot();

            if(snapshot.Id != _turnSnapshot.Id)
            {
                OnTurnCompleted(snapshot);

                if (snapshot.Interaction is not null)
                {
                    OnDialogReceived(snapshot);
                }
            }

            timeMetricGetGameSession.Stop();

            _dictionaryLock.ExitWriteLock();
        }

        protected virtual void OnDialogReceived(IGameTurnSnapshot snapshot)
        {
            Metrics.IncreaseDialogsReceived();

            Logger.Debug($"[Dialog Received] Turn Id: {snapshot.Turn} Dialog Id: {snapshot.Interaction.RootDialog.Id}");

            OnReceivedDialog?.Invoke(snapshot);
        }

        protected virtual void OnTurnCompleted(IGameTurnSnapshot snapshot) 
        {
            Metrics.IncreaseTurn();

            // Update current turn snapshot
            _turnSnapshot = snapshot;

            Logger.Debug($"[Turn Completed] Turn Id: {snapshot.Turn}");

            OnEndTurn?.Invoke(snapshot);
        }

        public void PushCommand(ICommand command)
        {
            _gameServer.Command(command);
            Metrics.IncreaseCommands();
        }

        public void ExecuteCommand()
        {
            var snapshotBefore = _gameServer.GetSnapshot();
            _gameServer.TurnExecute();
            var snapshotAfter = _gameServer.GetSnapshot();
        }
    }
}
