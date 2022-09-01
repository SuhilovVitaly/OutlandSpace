using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Universe.Engine
{
    public interface IGameServer
    {
        IGameTurnSnapshot Initialization();

        IGameTurnSnapshot TurnExecute(int count = 1);
    }
}
