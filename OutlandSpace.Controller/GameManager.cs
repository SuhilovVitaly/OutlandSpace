using System;
using System.Reflection;
using log4net;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Controller
{
    public class GameManager: IGameEvents
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        public event Action<IGameTurnSnapshot> OnStartGame;
        public event Action<IGameTurnSnapshot> OnEndTurn;
        public event Action<IGameTurnSnapshot> OnReceivedDialog;
        public event Action<IGameTurnSnapshot> OnRefreshLocations;

        private readonly Worker _worker;


        public GameManager(Worker worker)
        {
            _worker = worker;

            _worker.OnStartGame += Event_StartGame;
            _worker.OnEndTurn += Event_EndTurn;
            _worker.OnReceivedDialog += Event_ReceiveDialog;
        }

        private void Event_ReceiveDialog(IGameTurnSnapshot snapshot)
        {
            OnReceivedDialog?.Invoke(snapshot);
        }

        private void Event_EndTurn(IGameTurnSnapshot snapshot)
        {
            OnEndTurn?.Invoke(snapshot);
        }

        public void StartGameSession()
        {
            const string newGameDefaultScenario = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

            Logger.Info($"New game started wit scenario name is '{newGameDefaultScenario}'");

            _worker.StartNewGameSession(newGameDefaultScenario);
        }

        private void Event_StartGame(IGameTurnSnapshot session)
        {
            OnStartGame?.Invoke(session);
        }

        public void ResumeSession()
        {
            // TODO: Add game session Id
            Logger.Info("Resume game session");

            _worker.SessionResume();
        }
    }
}