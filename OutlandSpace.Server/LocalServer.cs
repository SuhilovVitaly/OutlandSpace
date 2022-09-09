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

        public IGameTurnSnapshot Initialization()
        {
            // TODO: Init
            throw new NotImplementedException();
        }

        public IGameTurnSnapshot TurnExecute(IGameSession session, int count = 1)
        {
            dictionaryLock.EnterWriteLock();

            var turnSnapshot = TurnCalculate.Execute(session, dialogsStorage);

            return turnSnapshot;
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

        
    }
}
