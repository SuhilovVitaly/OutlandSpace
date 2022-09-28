using System.Collections.Immutable;
using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;
using OutlandSpace.Universe.Engine.Session.Commands;

namespace OutlandSpace.Universe.Engine
{
    public interface IGameServer
    {
        IServerMetrics Metrics { get; }

        IGameTurnSnapshot Initialization(string scenarioId, string source = "Data");

        IGameTurnSnapshot GetSnapshot();

        IGameTurnSnapshot TurnExecute(IGameSession session);

        IGameTurnSnapshot TurnExecute(int count = 1);

        IDialog DialogResponse(string dialogId);

        void ResumeSession();

        void PauseSession();

        IExecuteMetrics SessionMetrics();

        void Command(ICommand command);

        ImmutableArray<ICommand> GetUnexecutedCommands();
    }
}
