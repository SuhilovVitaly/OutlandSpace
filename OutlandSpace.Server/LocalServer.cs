using System;
using System.Threading;
using OutlandSpace.Server.Engine;
using OutlandSpace.Server.Engine.Dialog;
using OutlandSpace.Server.Engine.Execution;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Server
{
    public class LocalServer : IGameServer
    {
        private protected GameSession session;
        private protected Api api;
        private protected DialogsStorage dialogsStorage;
        private protected Health health;

        private readonly ReaderWriterLockSlim dictionaryLock = new ReaderWriterLockSlim();

        public LocalServer(string dataFolder = "Data")
        {
            api = new Api();
            health = new Health();
            session = new GameSession();
            dialogsStorage = new DialogFactory().Initialize(dataFolder);
        }

        public IGameTurnSnapshot Initialization(string scenarioId)
        {
            dictionaryLock.EnterWriteLock();

            IScenario scenario = new Scenario(scenarioId, "TestsData");

            session = TurnCalculate.Initialization(scenario, dialogsStorage);

            dictionaryLock.ExitWriteLock();

            return ConvertGameSessionToGameTurnSnapshot(session);
        }

        public IGameTurnSnapshot TurnExecute(IGameSession session, int count = 1)
        {
            dictionaryLock.EnterWriteLock();

            session = TurnCalculate.Execute(session, dialogsStorage);

            dictionaryLock.ExitWriteLock();

            return ConvertGameSessionToGameTurnSnapshot(session);
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
