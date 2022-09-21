using OutlandSpace.Universe.Engine;

namespace OutlandSpace.Server.Engine
{
    public class ServerMetrics: IServerMetrics
    {
        public ServerMetrics()
        {
        }

        public int TickCounter { get; private set; }

        public int TurnCounter { get; private set; }

        public void IncreaseTick()
        {
            TickCounter++;
        }

        public void IncreaseTurn()
        {
            TurnCounter++;
        }
    }
}
