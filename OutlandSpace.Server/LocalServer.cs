using log4net;
using OutlandSpace.Server.Engine;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Tools;
using System;
using System.Reflection;
using System.Threading;

namespace OutlandSpace.Server
{
    public class LocalServer : IGameServer
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private const int TurnMilliseconds = 100;

        private protected GameSession session;
        private protected Api api;
        private protected Health health;

        private readonly ReaderWriterLockSlim dictionaryLock = new();

        public IServerMetrics Metrics { get; private set; } 

        public LocalServer(string dataFolder = "Data")
        {
            api = new Api();
            health = new Health();
        }

        public IGameTurnSnapshot Initialization(string scenarioId, string source = "TestsData")
        {
            dictionaryLock.EnterWriteLock();

            Metrics = new ServerMetrics();

            IScenario scenario = new Scenario(scenarioId, source);

            session = new GameSession(scenario);

            dictionaryLock.ExitWriteLock();

            var turnSnapshot = session.ToGameTurnSnapshot();

            Scheduler.Instance.ScheduleTask(50, TurnMilliseconds, ExecuteTurnCalculation);

            return turnSnapshot;
        }

        public void ResumeSession()
        {
            session.Resume();
            Logger.Info($"[ResumeSession] Succeeded.");
        }

        public void PauseSession()
        {
            session.Pause();
            Logger.Info($"[PauseSession] Succeeded.");
        }

        public IExecuteMetrics SessionMetrics()
        {
            return session.Metrics;
        }

        private bool _executionInProgress;
        

        private void ExecuteTurnCalculation()
        {
            Metrics.IncreaseTick();

            session.Metrics.IncreaseTick();

            if (session.IsPause || _executionInProgress) return;

            _executionInProgress = true;            

            try
            {
                TurnExecute(session);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                _executionInProgress = false;
            }

            _executionInProgress = false;
        }

        public IGameTurnSnapshot TurnExecute(IGameSession sessionForExecute)
        {
            Metrics.IncreaseTurn();

            return sessionForExecute.RealTimeTurnExecute();
        }

        public IGameTurnSnapshot TurnExecute(int count = 1)
        {
            for(var i = 0; i < count; i++)
            {
                session.TurnExecute();
            }

            return session.ToGameTurnSnapshot();
        }

        public IDialog GetDialog(string id) => api.GetDialog(id, session.ResourcesStorage.Dialogs);

        public int HealthSystemDialogsCount() => health.DialogsCount(session.ResourcesStorage.Dialogs);

        public IDialog DialogResponse(string dialogId)
        {
            var resumeDialog = api.GetDialog(dialogId, session.ResourcesStorage.Dialogs);

            return resumeDialog;
        }

        public IGameTurnSnapshot GetSnapshot()
        {
            return session.ToGameTurnSnapshot();
        }
    }
}
