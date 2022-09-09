using OutlandSpace.Universe.Engine.Dialogs;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Universe.Engine
{
    public interface IGameServer
    {
        IGameTurnSnapshot Initialization();

        IGameTurnSnapshot TurnExecute(IGameSession session, int count = 1);

        IGameTurnSnapshot TurnExecute(int count = 1);

        IDialog DialogResponse(string dialogId);
    }
}
