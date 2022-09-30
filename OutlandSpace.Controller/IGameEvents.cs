using OutlandSpace.Universe.Engine.Session;
using System;

namespace OutlandSpace.Controller
{
    public interface IGameEvents
    {
        event Action<IGameTurnSnapshot> OnStartGame;
        event Action<IGameTurnSnapshot> OnEndTurn;
        event Action<IGameTurnSnapshot> OnReceivedDialog;
        event Action<IGameTurnSnapshot> OnRefreshLocations;
    }
}
