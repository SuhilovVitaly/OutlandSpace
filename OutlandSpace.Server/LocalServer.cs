using System;
using System.Reflection;
using System.Threading;
using log4net;
using OutlandSpace.Server.Engine;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Tools;

namespace OutlandSpace.Server
{
    public class LocalServer : IGameServer
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private const int TurnMilliseconds = 100;

        private protected GameSession session;
        private protected Api api;
        private protected DialogsStorage dialogsStorage;
        private protected Health health;

        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();

        public IServerMetrics Metrics { get; private set; } 

        public LocalServer(string dataFolder = "Data")
        {
            api = new Api();
            health = new Health();

            dialogsStorage = new DialogFactory().Initialize(dataFolder);
        }

        public IGameTurnSnapshot Initialization(string scenarioId, string source = "TestsData")
        {
            dictionaryLock.EnterWriteLock();

            Metrics = new ServerMetrics();

            IScenario scenario = new Scenario(scenarioId, source);

            session = new GameSession(scenario);

            dictionaryLock.ExitWriteLock();

            var turnSnapshot = session.ToGameTurnSnapshot();

            Scheduler.Instance.ScheduleTask(50, TurnMilliseconds, ExecuteTurnCalculation, null);

            return turnSnapshot;
        }

        public void ResumeSession()
        {
            session.Resume();
            _logger.Info($"[ResumeSession] Succeeded.");
        }

        public void PauseSession()
        {
            session.Pause();
            _logger.Info($"[PauseSession] Succeeded.");
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
                _logger.Error(ex.Message);
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

        public IDialog GetDialog(string id) => api.GetDialog(id, dialogsStorage);

        public int HealthSystemDialogsCount() => health.DialogsCount(dialogsStorage);

        public IDialog DialogResponse(string dialogId)
        {
            var resumeDialog = api.GetDialog(dialogId, dialogsStorage);

            return resumeDialog;
        }

        public IGameTurnSnapshot GetSnapshot()
        {
            return session.ToGameTurnSnapshot();
        }
    }
}
