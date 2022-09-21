using System;
namespace OutlandSpace.Universe.Engine
{
    public interface IServerMetrics
    {
        int TickCounter { get; }
        int TurnCounter { get; }

        void IncreaseTick();
        void IncreaseTurn();
    }
}
