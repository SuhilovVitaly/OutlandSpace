using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Universe.Engine
{
    public interface IGameServer
    {
        IGameTurnSnapshot Initialization(string scenarioId, string source = "Data");

        IGameTurnSnapshot GetSnapshot();

        IGameTurnSnapshot TurnExecute(IGameSession session);

        IGameTurnSnapshot TurnExecute(int count = 1);

        long GetServerTick();

        IDialog DialogResponse(string dialogId);

        void ResumeSession();

        void PauseSession();

        IExecuteMetrics SessionMetrics();
    }
}
