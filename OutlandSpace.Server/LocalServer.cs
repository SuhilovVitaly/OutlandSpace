using System;
using OutlandSpace.Server.Engine;
using OutlandSpace.Server.Engine.Dialog;
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
        private protected DialogsStorage dialogStorage;
        private protected Health health;

        public LocalServer(string dataFolder = "Data")
        {
            api = new Api();
            health = new Health();
            session = new GameSession();
            dialogStorage = new DialogFactory().Initialize(dataFolder);
        }

        public IGameTurnSnapshot Initialization()
        {
            // TODO: Init
            throw new NotImplementedException();
        }

        public IGameTurnSnapshot TurnExecute(int count = 1)
        {

            return null;
        }


        public IDialog GetDialog(Guid id) => api.GetDialog(id, dialogStorage);

        public int HealthSystemDialogsCount() => health.DialogsCount(dialogStorage);
    }
}
