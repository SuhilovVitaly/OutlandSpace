using OutlandSpace.Universe.Engine.Session;
using System;

namespace OutlandSpace.Controller
{
    public interface IGameEvents
    {
        event Action<IGameTurnSnapshot> OnStartGame;
        event Action<IGameTurnSnapshot> OnEndTurn;
        event Action<IGameTurnSnapshot, int> OnEndTurnStep;
        event Action<IGameTurnSnapshot> OnRefreshLocations;
        event Action<IGameTurnSnapshot, int> OnChangeChangeActiveObject;
        event Action<IGameTurnSnapshot, int> OnChangeChangeSelectedObject;
    }
}
