using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Universe.Engine
{
    public interface IGameServer
    {
        IGameTurnSnapshot Initialization();
    }
}
