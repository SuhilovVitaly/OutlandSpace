using System;
using System.Reflection;
using System.Threading;
using log4net;
using OutlandSpace.Server.Engine;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution;
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


        private protected GameSession session;
        private protected Api api;
        private protected DialogsStorage dialogsStorage;
        private protected Health health;

        private long _serverTickCounter;
        private long _serverTurnCounter;

        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();
        private readonly ReaderWriterLockSlim tickTurnExecuteLock = new ReaderWriterLockSlim();

        public LocalServer(string dataFolder = "Data")
        {
            api = new Api();
            health = new Health();
            session = new GameSession();
            dialogsStorage = new DialogFactory().Initialize(dataFolder);
        }

        public IGameTurnSnapshot Initialization(string scenarioId, string source = "TestsData")
        {
            dictionaryLock.EnterWriteLock();

            IScenario scenario = new Scenario(scenarioId, source);

            session = TurnCalculate.Initialization(scenario, dialogsStorage);

            dictionaryLock.ExitWriteLock();

            var turnSnapshot = ConvertGameSessionToGameTurnSnapshot(session);

            Scheduler.Instance.ScheduleTask(50, 50, ExecuteTurnCalculation, null);

            return turnSnapshot;
        }

        public long GetServerTick()
        {
            return _serverTickCounter;
        }

        public long GetServerTurnExecutionCount()
        {
            return _serverTurnCounter;
        }
        

        private bool _commandResume = false;
        public void ResumeSession()
        {
            _commandResume = true;
            _logger.Info($"[ResumeSession] Succeeded.");
        }

        private bool _commandPause = false;
        public void PauseSession()
        {
            _commandPause = true;
            _logger.Info($"[PauseSession] Succeeded.");
        }

        private bool isDebug;
        private bool _executionInProgress = false;
        private void ExecuteTurnCalculation()
        {
            //if (isDebug) return;
            //isDebug = true;

            if (_executionInProgress) return;
            _executionInProgress = true;


            _serverTickCounter++;

            if (_commandResume)
            {
                try
                {
                    session.Resume();
                    _commandResume = false;
                }
                catch (Exception ex)
                {
                    _commandResume = false;
                }
                
            }

            if (_commandPause)
            {
                session.Pause();
                _commandPause = false;
            }

            if (session.IsPause)
            {
                _executionInProgress = false;
                return;
            }

            try
            {
                TurnExecute(session);
            }
            catch (Exception ex)
            {
                _executionInProgress = false;
            }
            

            _executionInProgress = false;
            isDebug = false;
        }

        public IGameTurnSnapshot TurnExecute(IGameSession sessionForExecute, int count = 1)
        {
            _serverTurnCounter++;
            try
            {
                session = UpdateSession(TurnCalculate.Execute(sessionForExecute, dialogsStorage), sessionForExecute);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            

            return ConvertGameSessionToGameTurnSnapshot(session);
        }

        private GameSession UpdateSession(GameSession rebuildedSession, IGameSession coreSession)
        {
            var objects = rebuildedSession.GetCelestialObjects().DeepClone();
            var dialogs = rebuildedSession.Dialogs.DeepClone();


            var endTurnSession = new GameSession(objects, dialogs);

            if(coreSession.IsPause)
            {
                endTurnSession.Pause();
            }
            else
            {
                endTurnSession.Resume();
            }

            endTurnSession.UpdateTurn(rebuildedSession.GetCelestialObjects(), 1);

            return endTurnSession;
        }

        private IGameTurnSnapshot ConvertGameSessionToGameTurnSnapshot(IGameSession session)
        {
            return new GameTurnSnapshot(
                session.Dialogs, 
                session.CelestialObjects, 
                session.Id, 
                session.Turn, 
                session.IsPause, 
                session.IsDebug);
        }

        public IGameTurnSnapshot TurnExecute(int count = 1)
        {
            return TurnExecute(session);
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
            var result = new GameTurnSnapshot(session.Dialogs, session.CelestialObjects, session.Id, session.Turn, session.IsPause, session.IsDebug);

            return result;
        }
    }
}
