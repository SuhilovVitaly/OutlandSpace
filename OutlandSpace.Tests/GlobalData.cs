using System;
using OutlandSpace.Server;
using OutlandSpace.Server.Engine.Session;
using OutlandSpace.Universe.Engine.Session;

namespace OutlandSpace.Tests
{
    public static class GlobalData
    {
        public static int DialogsCountInTests { get; set; } = 7;

        public static int DialogsCount { get; set; } = 1;

        public static string TestsDataFolder { get; set; } = "TestsData";

        public static string MainScenarioId { get; } = "7045d54c-412b-429e-b1ed-43e62dcc10e6";

        private static readonly Lazy<LocalServer> LocalServer = new Lazy<LocalServer>(() => new LocalServer(TestsDataFolder));


        public static IGameSession GameSessionWithMainScenarioId
        {
            get
            {
                return new GameSession(new Scenario(MainScenarioId, TestsDataFolder));
            }
            
        }

        public static LocalServer LocalServerWithTestData
        {
            get
            {
                LocalServer.Value.Initialization(MainScenarioId);
                return LocalServer.Value;
            }
        }
    }
}
